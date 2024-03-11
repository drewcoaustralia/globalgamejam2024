using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManager : MonoBehaviour
{
    public GameObject spawnPoint;
    private Vector3 spawnPosition;
    public GameObject childPrefab;
    public float childSpawnDelayMin = 4f;
    public float childSpawnDelayMax = 10f;
    public int childSpawnCountMax = 3;
    private float childSpawnNextTime;
    private int childCount = 0;

    void Start()
    {
        spawnPosition = spawnPoint.transform.position;
        ResetSpawnTimer();
        //Spawn();
    }

    void ResetSpawnTimer()
    {
        childSpawnNextTime = Time.timeSinceLevelLoad + Random.Range(childSpawnDelayMin, childSpawnDelayMax);
    }

    void Spawn(int num = -1)
    {
        if (num == -1) num = Random.Range(1, childSpawnCountMax + 1);
        for (int i=0; i<num; i++)
        {
            GameObject newChild = GameObject.Instantiate(childPrefab, spawnPosition, Quaternion.identity);
            newChild.name = "Child " + ++childCount;
        }
        ResetSpawnTimer();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= childSpawnNextTime || Input.GetKeyDown(KeyCode.Backspace)) Spawn();
    }
}

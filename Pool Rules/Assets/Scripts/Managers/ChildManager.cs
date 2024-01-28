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

    void Start()
    {
        spawnPosition = spawnPoint.transform.position;
        ResetSpawnTimer();
        //Spawn();
    }

    void ResetSpawnTimer()
    {
        childSpawnNextTime = Time.time + Random.Range(childSpawnDelayMin, childSpawnDelayMax);
    }

    void Spawn(int num = -1)
    {
        if (num == -1) num = Random.Range(1, childSpawnCountMax + 1);
        for (int i=0; i<num; i++)
        {
            GameObject.Instantiate(childPrefab, spawnPosition, Quaternion.identity);
        }
        ResetSpawnTimer();
    }

    void Update()
    {
        if (Time.time >= childSpawnNextTime || Input.GetKeyDown(KeyCode.Backspace)) Spawn();
    }
}

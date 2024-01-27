using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManager : MonoBehaviour
{
    public GameObject childPrefab;
    public float childSpawnDelayMin = 4f;
    public float childSpawnDelayMax = 10f;
    public int childSpawnCountMax = 3;
    private float childSpawnNextTime;

    void Start()
    {
        ResetSpawnTimer();
        Spawn(3);
    }

    void ResetSpawnTimer()
    {
        childSpawnNextTime = Time.time + Random.Range(childSpawnDelayMin, childSpawnDelayMax);
    }

    void Spawn(int num = 1)
    {
        for (int i=0; i<num; i++)
        {
            Vector3 position = new Vector3(Random.Range(-5f, 5f), 1f, Random.Range(-5f, 5f));
            GameObject.Instantiate(childPrefab, position, Quaternion.identity);
        }
        ResetSpawnTimer();
    }

    void Update()
    {
        if (Time.time >= childSpawnNextTime || Input.GetKeyDown(KeyCode.Backspace)) Spawn(Random.Range(1, childSpawnCountMax+1));
    }
}

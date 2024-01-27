using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject childPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Vector3 position = new Vector3(Random.Range(-5f, 5f), 1f, Random.Range(-5f, 5f));
            GameObject.Instantiate(childPrefab, position, Quaternion.identity);
        }
    }
}

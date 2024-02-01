using System.Collections.Generic;
using UnityEngine;

public class StartNodeManager : Singleton<StartNodeManager>
{
    public GameObject startNode;
    public List<GameObject> secondNodes;

    public GameObject GetRandomNode()
    {
        if (secondNodes.Count > 0)
        {
            int randomIndex = Random.Range(0, secondNodes.Count);
            return secondNodes[randomIndex];
        }
        else
        {
            Debug.LogWarning("could not get random node because secondNodes list is not populated");
            return null;
        }
    }
}

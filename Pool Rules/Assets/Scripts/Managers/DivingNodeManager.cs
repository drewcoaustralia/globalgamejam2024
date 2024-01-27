using System.Collections.Generic;
using UnityEngine;

public class DivingNodeManager : Singleton<DivingNodeManager>
{
    [SerializeField] List<GameObject> divingNodes = new List<GameObject>();

    public GameObject FindClosestNode(Vector3 position)
    {
        GameObject closestNode = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject node in divingNodes)
        {
            float distance = Vector3.Distance(node.transform.position, position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestNode = node;
            }
        }

        return closestNode;
    }
}

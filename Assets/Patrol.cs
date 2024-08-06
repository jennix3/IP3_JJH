using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] float range = 10f;
    Vector3 destPoint;
    bool walkpointSet;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SearchForDest();
    }

    void Update()
    {
        GhostPatrol();
    }

    void GhostPatrol()
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 1f) walkpointSet = false;
    }

    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, 100f, groundLayer))
        {
            walkpointSet = true;
        }
    }
}

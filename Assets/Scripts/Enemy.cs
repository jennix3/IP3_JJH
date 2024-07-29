using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public Transform target;

    public NavMeshAgent myAgent;

    // Update is called once per frame
    void Update()
    {
        if(myAgent != null || target != null)
        {
            myAgent.SetDestination(target.position);
        }
    }
}

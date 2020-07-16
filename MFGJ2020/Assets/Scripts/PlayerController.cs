using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public NavMeshAgent agent;
    private Vector3 target= new Vector3(15f, 1f, 13f);
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target);
    }
}

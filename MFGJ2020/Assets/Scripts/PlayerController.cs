using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{

    public NavMeshAgent agent;
    private Vector3 target= new Vector3(15f, 1f, 13f);
    
    [SerializeField]
    private float movementSpeed = 3;
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target);
        Move();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * movementSpeed * Time.deltaTime;
        agent.Move(movement);
    }
}

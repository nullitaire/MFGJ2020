using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    private Vector3 target= new Vector3(0f, 1f, 0f);
    
    [SerializeField]
    private float movementSpeed = 3;
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target);
        PathTrace();
    }

    /// <summary>
    /// constantly moves character in forwards direction towards destination
    /// TO DO: Look into making it go faster over time.
    /// </summary>
    private void PathTrace()
    {
        Vector3 movement = transform.forward * movementSpeed * Time.deltaTime;
        agent.Move(movement);
    }

}

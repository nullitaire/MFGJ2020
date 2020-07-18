using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CURRENTLY NOT IN USE
/// TO DO: ORGANIZE CODE TO USE THIS MAYBE
/// </summary>
public class InputHandler : MonoBehaviour
{ 
    float horizontal;
    float vertical;

    StateManager states;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponent<StateManager>();
        //states.Init();
    }

    void FixedUpdate()
    {
        GetInput();
        UpdateStates();
    }

    void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void UpdateStates()
    {
        states.horizontal = horizontal;
        states.vertical = vertical;
    }
}

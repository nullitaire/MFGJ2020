using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{ 
    float horizontal;
    float vertical;

    StateManager states;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponent<StateManager>();
        states.Init();
    }

    void FixedUpdate()
    {
        GetInput();
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

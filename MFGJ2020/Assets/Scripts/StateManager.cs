using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace SA
public class StateManager : MonoBehaviour
{
    public float horizontal;
    public float vertical;

    public GameObject player;

    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public Rigidbody rb;

    public void Init()
    {
        SetupAnimator();
        rb = GetComponent<Rigidbody>();

    }


    void SetupAnimator()
    {
        if (player == null)
        {
            anim = GetComponentInChildren<Animator>();
            if (anim == null)
            {
                Debug.Log("No model found");
            }
            else
            {
                player = anim.gameObject;
            }
        }
        if (anim == null)
        {
            anim = player.GetComponent<Animator>();
        }

        anim.applyRootMotion = false;
    }

}

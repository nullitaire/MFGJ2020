﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//recognize waypoints to direct player's movement
public class PathManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 2f;
    private int waypointIndex = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

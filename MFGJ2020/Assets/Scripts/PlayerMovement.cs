using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public float speed;
    readonly float regSpeed = 10f;
    readonly float dashSpeed = 25f;
    
    float h_multiplier = 5f;
    float v_multiplier = 5f;

    bool canMove = true;
    int line = 0;
    int targetLine = 0;
    int level = 0;
    int targetLevel = 0;

    private void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        CheckMove();
    }

    private void CheckInput()
    {
        SetSpeed();
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && canMove && line > -1)
        {
            targetLine--;
            canMove = false;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && canMove && line < 1)
        {
            targetLine++;
            canMove = false;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && canMove && level < 1)
        {
            targetLevel++;
            canMove = false;
            
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && canMove && level > 1)
        {
            targetLevel--;
            canMove = false;
        }
    }

    private void CheckMove()
    {
        Vector3 pos = gameObject.transform.localPosition;
        if (!line.Equals(targetLine))
        {
            if (targetLine == -1 && pos.x > -h_multiplier)
            {
                Move(Vector3.left);
            }
            else if (targetLine == 0 && pos.x != 0)
            {
                if (line == -1 && pos.x < 0)
                {
                    Move(Vector3.right);
                }
                else if (line == 1 && pos.x > 0)
                {
                    Move(Vector3.left);
                }
            }
            else if (targetLine == 1 && pos.x < h_multiplier)
            {
                Move(Vector3.right);
            }

        }
        if (!level.Equals(targetLevel))
        {
            if (targetLevel == -1 && pos.y > -v_multiplier)
            {
                Move(Vector3.down);
            }
            else if (targetLevel == 0 && pos.y != 0)
            {
                if (level == -1 && pos.y < 0)
                {
                    Move(Vector3.up);
                }
                else if (level == 1 && pos.y > 0)
                {
                    Move(Vector3.down);
                }
            }
            if (targetLevel == 1 && pos.y < v_multiplier)
            {
                Move(Vector3.up);
            }
        }
    }
    void SetSpeed()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed = dashSpeed;
        }
        else
        {
            speed = regSpeed;
        }
    }

    IEnumerator MoveTo(Vector3 direction)
    {
        Vector3 destination = transform.localPosition + direction * 5;
        while(transform.localPosition != destination)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, speed*Time.deltaTime);
            yield return null;
        }
    }

    private void Move(Vector3 direction)
    {
        StartCoroutine(MoveTo(direction));
        if (direction.x != 0)
        {
            line = targetLine;
        }
        else
        {
            level = targetLevel;
        }
        canMove = true;
    }
}

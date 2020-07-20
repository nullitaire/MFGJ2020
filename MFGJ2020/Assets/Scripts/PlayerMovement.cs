using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{ 
    public float speed;
    float regSpeed = 3f;
    float dashSpeed = 10f;
    
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
        CheckMove();
    }

    private void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            speed = dashSpeed;
        }
        else
        {
            speed = regSpeed;
        }

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
            if (targetLevel == -1 && pos.y > -5)
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
            if (targetLevel == 1 && pos.y < 5)
            {
                Move(Vector3.up);
            }
        }
    }

    IEnumerator SmoothMove(Vector3 direction)
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position + direction * speed;
        float duration = .5f;
        float spentTime = 0;
        float interval = .1f;

        while(start != end && duration-spentTime > 0)
        {
            spentTime += interval;
            float move = Mathf.Lerp(0, 5, .2f);
            Debug.Log("Time Spent: "+ spentTime + ", Moved: " + move);
            //put move into vector form and add its value to current position
            transform.position += direction * move;
            yield return null;
        }
    }

    private void Move(Vector3 direction)
    {
        StartCoroutine(SmoothMove(direction));
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

using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    Vector3 movement = Vector3.zero;

    float h_dimension = 5f;
    float v_dimension = 5f;

    bool canMove = true;
    int line = 0;
    int targetLine = 0;
    int level = 0;
    int targetLevel = 0;

    private void Update()
    {
        Vector3 pos = gameObject.transform.localPosition;
 
        if (!line.Equals(targetLine))
        {
            if(targetLine == -1 && pos.x > -h_dimension)
            {
                gameObject.transform.localPosition = new Vector3(-h_dimension, pos.y, pos.z);
                line = targetLine;
                canMove = true;
                movement.x = 0;
            }
            else if (targetLine == 0 && pos.x != 0)
            {
                if (line == -1 && pos.x < 0)
                {
                    gameObject.transform.localPosition = new Vector3(0, pos.y, pos.z);
                    line = targetLine;
                    canMove = true;
                    movement.x = 0;
                }
                else if (line == 1 && pos.x > 0)
                {
                    gameObject.transform.localPosition = new Vector3(0, pos.y, pos.z);
                    line = targetLine;
                    canMove = true;
                    movement.x = 0;
                }
            }
            else if (targetLine == 1 && pos.x < h_dimension)
            {
                gameObject.transform.localPosition = new Vector3(h_dimension, pos.y, pos.z);
                line = targetLine;
                canMove = true;
                movement.x = 0;
            }
        }
        if (!level.Equals(targetLevel))
        {
            if (targetLevel == -1 && pos.y > -v_dimension)
            {
                gameObject.transform.position = new Vector3(pos.x, -v_dimension, pos.z);
                level = targetLevel;
                canMove = true;
                movement.y = 0;
            }
            else if (targetLevel == 0 && pos.y != 0)
            {
                if (level == -1 && pos.y < 0)
                {
                    gameObject.transform.position = new Vector3(pos.x, 0, pos.z);
                    level = targetLevel;
                    canMove = true;
                    movement.y = 0;
                }
                else if (level == 1 && pos.y > 0)
                {
                    gameObject.transform.position = new Vector3(pos.x, 0, pos.z);
                    level = targetLevel;
                    canMove = true;
                    movement.y = 0;
                }
            }
            if (targetLevel == 1 && pos.y < v_dimension)
            {
                gameObject.transform.position = new Vector3(pos.x, v_dimension, pos.z);
                level = targetLevel;
                canMove = true;
                movement.y = 0;
            }
        }

        checkInput();
    }

    void checkInput()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && canMove && line > -1)
        {
            targetLine--;
            canMove = false;
            movement.x = h_dimension * targetLine;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && canMove && line < 1)
        {
            targetLine++;
            canMove = false;
            movement.x = h_dimension * targetLine;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && canMove && level < 1)
        {
            targetLevel++;
            canMove = false;
            movement.y = h_dimension  * targetLine;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && canMove && level > 1)
        {
            targetLevel--;
            canMove = false;
            movement.y = h_dimension * targetLine;
        }
    }
}

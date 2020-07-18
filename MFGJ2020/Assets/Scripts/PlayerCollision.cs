using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    [SerializeField] PlayerController pc;
    [SerializeField] GameManager game;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            pc.enabled = false;
            movement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}

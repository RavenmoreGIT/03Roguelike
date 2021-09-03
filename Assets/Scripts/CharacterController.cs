using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(MovementCheck(Vector3.left)) transform.position += Vector3.left;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (MovementCheck(Vector3.right)) transform.position += Vector3.right;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (MovementCheck(Vector3.up)) transform.position += Vector3.up;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            if (MovementCheck(Vector3.down)) transform.position += Vector3.down;
        }

        
    }

    private bool MovementCheck(Vector3 direction)
    {
        if (Physics2D.Raycast(transform.position + direction, Vector2.zero).collider == null) return true;
        else return false;
    }
}

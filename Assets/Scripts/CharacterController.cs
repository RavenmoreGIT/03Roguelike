using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject footprint;
    private bool isMoving = false;
    private Vector3 MoveTarget;
    // Start is called before the first frame update
    void Start()
    {
        MoveTarget = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving) { 
            if (Input.GetKey(KeyCode.A))
            {
                if (CanMove(Vector3.left) && !isMoving) StartCoroutine(MoveTo(transform.position + Vector3.left));
            }

            if (Input.GetKey(KeyCode.D) && !isMoving)
            {
                if (CanMove(Vector3.right)) StartCoroutine(MoveTo(transform.position + Vector3.right));
            }

            if (Input.GetKey(KeyCode.W) && !isMoving)
            {
                if (CanMove(Vector3.up)) StartCoroutine(MoveTo(transform.position + Vector3.up));
            }

            if (Input.GetKey(KeyCode.S) && !isMoving)
            {

                if (CanMove(Vector3.down)) StartCoroutine(MoveTo(transform.position + Vector3.down));
            }
        }


    }

    private IEnumerator MoveTo(Vector3 target)
    {
        Instantiate(footprint, transform.position, Quaternion.identity);
        isMoving = true;

        while(Vector3.Distance(transform.position, target) > 0.001)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime*35);
            yield return null;
            
        }
        isMoving = false;
        transform.position = target;
        yield return null;
    }

    private bool CanMove(Vector3 direction)
    {
        if (Physics2D.Raycast(transform.position + direction, Vector2.zero).collider == null) return true;
        else return false;
    }
}

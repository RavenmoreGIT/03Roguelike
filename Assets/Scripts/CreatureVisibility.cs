using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CreatureVisibility : MonoBehaviour
{

    private GameObject player;
    private LayerMask LayerMask;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Protagonist");
        LayerMask = LayerMask.GetMask("Walls");
    }

    // Update is called once per frame
    void Update()
    {
        if (HasLineOfSight())
        {
            transform.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
    }
    
    private bool HasLineOfSight()
    {
        Vector3 RaycastDirection = player.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position,RaycastDirection.normalized,Vector3.Distance(transform.position,player.transform.position),LayerMask);
        //Debug.DrawRay(transform.position, RaycastDirection,Color.green,1);

        if (hit) return false;
        else return true;
    }
}
    
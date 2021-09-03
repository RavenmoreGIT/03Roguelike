using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetFollower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MoveTarget;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Slerp(this.transform.position, MoveTarget.transform.position,Time.deltaTime*10);
    }
}

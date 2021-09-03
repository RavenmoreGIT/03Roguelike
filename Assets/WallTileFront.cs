using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTileFront : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer WallFrontSprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < transform.position.y)
        {
            WallFrontSprite.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("Visible", true);
        }
        else
        {
            WallFrontSprite.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("Visible", false);
        }
    }


}

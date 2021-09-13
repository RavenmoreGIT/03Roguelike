using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallTile : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite WallDefault;
    public Sprite WallTop;
    public Sprite WallVerticalMid;
    public Sprite WallVerticalTop;
    public Sprite WallVerticalBottom;
    public Sprite WallHorizontalMid;
    public Sprite WallHorizontalLeft;
    public Sprite WallHorizontalRight;

    public GameObject WallTileFront;
    public Sprite WallTileFrontMidSprite;
    public Sprite WallTileFrontLeftSprite;
    public Sprite WallTileFrontRightSprite;

    public SpriteRenderer sprite;
    public SpriteRenderer frontSprite;

    public Animator wallAnimator;
    public GameObject player;
    public SpriteRenderer WallFrontSprite;

    private int bitmask=0;
    void Start()
    {
        /*
         * Get the player object, used for changing WallTileFront sprite based on the players' position.
         */
        player = GameObject.Find("Protagonist");

        /*
         * Calculate the bit mask based on surroundings, then change the sprite based on the bitmask value
         */
        WallTileFront.SetActive(false);
        if (Physics2D.Raycast(transform.position + Vector3.up, Vector2.zero).collider != null) bitmask += 1;
        if (Physics2D.Raycast(transform.position + Vector3.left, Vector2.zero).collider != null) bitmask += 2;
        if (Physics2D.Raycast(transform.position + Vector3.right, Vector2.zero).collider != null) bitmask += 4;
        if (Physics2D.Raycast(transform.position + Vector3.down, Vector2.zero).collider != null) bitmask += 8;
        switch (bitmask)
        {
            case 1: 
                sprite.sprite = WallVerticalBottom;
                break;
            case 2:
                sprite.sprite = WallHorizontalRight;
                WallTileFront.SetActive(true);
                frontSprite.sprite = WallTileFrontRightSprite;
                break;
            case 4:
                sprite.sprite = WallHorizontalLeft;
                WallTileFront.SetActive(true);
                frontSprite.sprite = WallTileFrontLeftSprite;
                break;
            case 6:
            case 7:
                sprite.sprite = WallHorizontalMid;
                WallTileFront.SetActive(true);
                frontSprite.sprite = WallTileFrontMidSprite;
                break;
            case 9:
                sprite.sprite = WallVerticalMid;
                break;
            case 8:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
                sprite.sprite = WallVerticalTop;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < transform.position.y)
        {
            wallAnimator.SetBool("Visible", true);
        }
        else
        {
            wallAnimator.SetBool("Visible", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpCheckRight : MonoBehaviour
{
    PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            player.ableToWallJumpRight = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            player.ableToWallJumpRight = false;
        }
    }
}

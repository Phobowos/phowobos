using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WallJumpCheckRight : MonoBehaviour
{
    PlayerScript player;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        view = player.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && view.IsMine)
        {
            player.ableToWallJumpRight = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && view.IsMine)
        {
            player.ableToWallJumpRight = false;
        }
    }
}

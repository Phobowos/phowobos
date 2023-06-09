using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WallJumpCheckRight : MonoBehaviour
{
    GameObject player;
    PlayerScript playerScript;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
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
            playerScript.ableToWallJumpRight = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && view.IsMine)
        {
            playerScript.ableToWallJumpRight = false;
        }
    }
}

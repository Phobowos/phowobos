using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public GameObject alternateCameraPos;
    public bool followPlayer = false;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        view = player.GetComponent<PhotonView>();
        Vector3 offset = new Vector3(0, 0, -10);

        if (view.IsMine)
        {
            if (followPlayer)
            {
                transform.position = player.transform.position + offset;
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    followPlayer = false;
                }
            }
            else if (!followPlayer)
            {
                transform.position = alternateCameraPos.transform.position;
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    followPlayer = true;
                }
            }
        }
    }
}

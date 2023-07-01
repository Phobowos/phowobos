using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GunScript : MonoBehaviour
{
    // Variables
    private SpriteRenderer spriteRenderer;
    Transform rotatePoint;
    public GameObject player;
    public GameObject[] bullets;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = player.GetComponent<PhotonView>();
        rotatePoint = gameObject.transform.parent;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            // Get pivot point z value
            float pivotPointZ = transform.parent.rotation.eulerAngles.z;

            // If the z value is above 90 or below -90, flip the gun about the y axis
            if (pivotPointZ > 90 & pivotPointZ < 270)
            {
                spriteRenderer.flipY = true;
            }
            else if (pivotPointZ <= 90 | pivotPointZ >= 270)
            {
                spriteRenderer.flipY = false;
            }

            // Shooting 

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(bullets[0], transform.position, transform.rotation);
            }
        }
    }
}

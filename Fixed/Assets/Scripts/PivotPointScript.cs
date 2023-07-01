using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PivotPointScript : MonoBehaviour
{
    Camera mainCamera;
    Vector3 mousePosition;
    public GameObject player;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = player.GetComponent<PhotonView>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            Vector3 rotation = mousePosition - transform.position;

            float zValue = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, zValue);
        
        }
            
    }
}

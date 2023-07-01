using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{   
    public GameObject spawnPos;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 spawn = spawnPos.transform.position;
        PhotonNetwork.Instantiate(player.name, spawn, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

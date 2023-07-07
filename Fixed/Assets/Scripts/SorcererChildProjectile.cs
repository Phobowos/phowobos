using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererChildProjectile : MonoBehaviour
{
    public PlayerScript playerScript;
    public GameObject[] sorcererProjectileDeath;
    public float damage = 2;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerScript.health -= damage;
            Instantiate(sorcererProjectileDeath[0], transform.position, sorcererProjectileDeath[0].transform.rotation);
        }
    }
}

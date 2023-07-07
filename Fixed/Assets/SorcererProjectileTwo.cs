using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererProjectileTwo : MonoBehaviour
{
    PlayerScript playerScript;
    public float moveSpeed;
    public float damage = 5;
    public GameObject[] sorcererProjectileDeath;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
    private void OnDestroy()
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

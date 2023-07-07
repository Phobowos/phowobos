using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererProjectileExplosion : MonoBehaviour
{
    PlayerScript playerScript;
    public float startTime;
    public float lifeTime;
    public float damage = 10;
    public int numberOfHits = 0;
    public int maxAmountOfHits = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime + lifeTime < Time.time)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && numberOfHits < maxAmountOfHits)
        {
            playerScript.health -= damage;
            numberOfHits += 1;
        }
    }
}

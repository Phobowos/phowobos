using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererProjectileMist : MonoBehaviour
{
    public PlayerScript playerScript;
    public float startTime;
    public float lifeTime = 5;
    public float mistDamage = 0.1f;
    public int numberOfHits = 0;
    public int maxAmountOfHits = 100;
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
            numberOfHits += 1;
            playerScript.health -= mistDamage;
        }
    }
}

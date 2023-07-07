using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererProjectileOne : MonoBehaviour
{
    public float moveSpeed;
    public float startTime;
    public float lifeTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime + lifeTime < Time.time)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}

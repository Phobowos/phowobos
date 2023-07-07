using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArcherScript : MonoBehaviour
{

    public float moveSpeed;
    public float health;
    public bool attacking;
    public bool inRange = false;
    public float attackTime;
    public float attackCooldownTime;
    public bool gotAttackTime = false;
    public float attackDuration = 2;
    public float startAttackTime;
    public bool gotStartAttackTime = false;
    public bool ableToAttack = false;
    public GameObject[] arrows;
    public float standingDistanceFromPlayer;
    GameObject player;
    Transform targetLocation;
    PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        targetLocation = player.transform;

        if (targetLocation.position.x - transform.position.x > standingDistanceFromPlayer && !attacking)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            inRange = false;
        }
        else if (targetLocation.position.x - transform.position.x < -standingDistanceFromPlayer && !attacking)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            inRange = false;
        }
        else
        {
            inRange = true;
        }

        if (ableToAttack)
        {
            if (inRange)
            {
                if (!gotStartAttackTime)
                {
                    attacking = true;
                    startAttackTime = Time.time;
                    gotStartAttackTime = true;
                }
                if (startAttackTime + attackDuration < Time.time)
                {
                    attacking = false;
                    gotStartAttackTime = false;
                    Attack();
                    ableToAttack = false;
                }
            }
        }
        else if (!ableToAttack)
        {

            if (!gotAttackTime)
            {
                attackCooldownTime = Random.Range(1, 3);
                attackTime = Time.time;
                gotAttackTime = true;
            }
            if (attackTime + attackCooldownTime < Time.time)
            {
                ableToAttack = true;
                gotAttackTime = false;
            }
        }

        // If the enemy has no health, it dies.

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Attack()
    {
        Vector3 rotation = targetLocation.position - transform.position;

        float zAngle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        int roll = Random.Range(0, 100);

        if (roll <= 70)
        {
            Instantiate(arrows[0], transform.position, Quaternion.Euler(0, 0, zAngle));
        }
        else if (roll > 70 && roll < 90)
        {
            Instantiate(arrows[1], transform.position, Quaternion.Euler(0, 0, zAngle));
        }
        else
        {
            Instantiate(arrows[2], transform.position, Quaternion.Euler(0, 0, zAngle));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health -= playerScript.bulletDamage;
        }
    }
}

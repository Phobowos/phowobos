using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererScript : MonoBehaviour
{
    GameObject player;
    PlayerScript playerScript;
    public float moveSpeed;
    public float health;
    public float contactDamage;
    public GameObject[] sorcererProjectiles;
    public float shieldHealth;
    public float maxShieldHealth;
    public bool barrierUp = true;
    public bool attacking = false;
    public bool ableToAttack = false;
    public float attackTime;
    public float attackCooldownTime;
    public bool gotAttackTime = false;
    public float attackDuration = 2;
    public float startAttackTime;
    public bool gotStartAttackTime = false;
    Transform targetLocation;
    // Start is called before the first frame update
    void Start()
    {
        maxShieldHealth = shieldHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        targetLocation = player.transform;

        
        // Checking if the enemy has a barrier.

        if (shieldHealth > 0)
        {
            barrierUp = true;
        }
        else
        {
            barrierUp = false;
        }

        // If the enemy has no health, it dies.

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        // The chunk of code is supposed to make the enemy run away when the player gets within 15 units. It does not work right now.

        if (-1 * (targetLocation.position.x - transform.position.x) <= 15 && !attacking)
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
        else if (-1 * (targetLocation.position.x - transform.position.x)  < 15 && !attacking)
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }



        if (ableToAttack)
        {
            
            int attackNumber = Random.Range(0, 3);
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
                Attack(attackNumber);
                ableToAttack = false;
            }
        }
        else if (!ableToAttack)
        {
            
            if (!gotAttackTime)
            {
                attackCooldownTime = Random.Range(5, 10);
                attackTime = Time.time;
                gotAttackTime = true;
            }
            if (attackTime + attackCooldownTime < Time.time)
            {
                ableToAttack = true;
                gotAttackTime = false;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (barrierUp)
            {
                if (playerScript.bulletDamage <= shieldHealth)
                {
                    shieldHealth -= playerScript.bulletDamage;
                }
                else if (playerScript.bulletDamage > shieldHealth)
                {
                    float incomingDamage = playerScript.bulletDamage;
                    incomingDamage -= shieldHealth;
                    shieldHealth = 0;
                    health -= incomingDamage;
                }
            }
            else if (!barrierUp)
            {
                health -= playerScript.bulletDamage;
            }
        }
    }
    private void Attack(int attackNumber)
    {
        Vector3 rotation = targetLocation.position - transform.position;

        float zAngle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        if (attackNumber == 0)
        {
            if (shieldHealth <= 0)
            {
                shieldHealth = maxShieldHealth;
            }
            else
            {
                Instantiate(sorcererProjectiles[0], transform.position, Quaternion.Euler(0, 0, zAngle));
            }
        }
        else if (attackNumber == 1)
        {
            Instantiate(sorcererProjectiles[0], transform.position, Quaternion.Euler(0,0, zAngle));
        }
        else if (attackNumber == 2)
        {
            Instantiate(sorcererProjectiles[1], transform.position, Quaternion.Euler(0, 0, zAngle));
        }
    }
}

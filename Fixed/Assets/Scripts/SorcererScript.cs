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
    public bool ableToAttack = true;
    public float attackTime;
    public float attackCooldownTime = 5;
    public bool gotAttackTime = false;
    public float attackDuration = 2;
    public float startAttackTime;
    public bool gotStartAttackTime = false;
    Transform targetLocation;
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

        

        if (shieldHealth > 0)
        {
            barrierUp = true;
        }
        else
        {
            barrierUp = false;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (-1 * (targetLocation.position.x - transform.position.x) <= -5 && !attacking)
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
        else if (-1 * (targetLocation.position.x - transform.position.x)  < 5 && !attacking)
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }

        if (ableToAttack)
        {
            int attackChance = Random.Range(0, 100);
            if (attackChance <= 5)
            {
                ableToAttack = false;
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
                }
            }
            
        }
        else if (!ableToAttack)
        {
            
            if (!gotAttackTime)
            {
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
                if (playerScript.bulletDamage < shieldHealth)
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
                attackNumber += 1;
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

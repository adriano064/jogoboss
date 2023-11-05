using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public int healthBoss = 100;

    public GameObject deathEffect;
    public bool isInvulnerable = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)

            return;

        healthBoss -= damage;

        if (healthBoss <= 50)
        {
            GetComponent<Animator>().SetBool("attack2", true);
        }

        if (healthBoss <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

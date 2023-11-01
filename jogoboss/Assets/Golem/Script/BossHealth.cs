using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    [SerializeField] int maxHealth = 400;
    
    public int health = 400;

    public GameObject deathEffect;

    public bool isInvulnerable = false;

    [SerializeField] FloatingHealthBar healthBar;

    public Animator anim;


    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    public void TakeDamage(int damage)
    {

        if (isInvulnerable)
            return;

        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);

        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (health == 0)
        {
            EnemyDead();
        }
    }

    private void EnemyDead()
    {
        health = 0;
        anim.SetTrigger("Death_golem");
        Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
        Destroy(transform.gameObject.GetComponent<Rigidbody2D>());
        Destroy(this);
    }

}

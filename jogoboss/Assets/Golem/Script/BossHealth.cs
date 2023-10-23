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

        if (health <= 0)
        {
            GetComponent<Animator>().SetBool("Death_golem", true);
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}

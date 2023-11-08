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

    [SerializeField] private AudioSource deathSoundEffect;

    public bool IsDead;
    
    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    private void Update()
    {
        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
            GetComponent<Animator>().SetBool("Stage1", false);
        }
        if (IsDead == false)
        {
            EnemyDead();
        }
    }

    public void TakeDamage(int damage)
    {

        if (isInvulnerable)
            return;

        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        
        
    }

    private void EnemyDead()
    {
        if (health <=0)
        {
            IsDead = true;
            deathSoundEffect.Play();
            health = 0;
            anim.SetTrigger("Death");
            Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
            Destroy(transform.gameObject.GetComponent<Rigidbody2D>());
            Destroy(this);
        }
    }

}

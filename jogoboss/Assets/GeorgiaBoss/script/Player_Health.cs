using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;

    private SpriteRenderer spriteRenderer;

    public void TakeDamage(int Damage)
    {
        health -= Damage;

        StartCoroutine(DamageFlashing());
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator DamageFlashing()
    {
        

        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(1f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public int health = 100;

    
    public bool isInvulnerable = false;
    private Animator anim;

    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void Damage(int dmg)
    {

        health -= dmg;
        anim.SetTrigger("hurt");

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


   

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Bateu");
            coll.gameObject.GetComponent<Teste>().Damage(damage);
        }
    }

}


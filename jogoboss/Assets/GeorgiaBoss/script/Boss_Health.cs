using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public int health = 180;
    private Rigidbody2D rig;
    private Animator anim;

    public int damage = 5 ;

    [SerializeField]
    private BarraVida barraVida;

    private float s = 2;
  
    

    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        this.barraVida.HealthMax = this.health;
        this.barraVida.Health = this.health;

    }

    // Update is called once per frame
    void Update()
    {
        s = GetComponent<Boss_Walk>().speedBoss;
    }

    
    public void Damage(int dmg)
    {

        health -= dmg;
        anim.SetTrigger("hurt");

        this.barraVida.Health = this.health;

        if (health <= 40)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(10.0f * s, 0.0f);
            damage = 7;
        }

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
            coll.gameObject.GetComponent<player>().Damage(damage);
        }

        if (coll.gameObject.tag == "combo")
        {
            Debug.Log("Bateu");
            coll.gameObject.GetComponent<player>().Damage(damage);
        }
        
        if (coll.gameObject.tag == "raio")
        {
            Debug.Log("Bateu");
            coll.gameObject.GetComponent<player>().Damage(damage);
        }
        
        if (coll.gameObject.tag == "simples")
        {
            Debug.Log("Bateu");
            coll.gameObject.GetComponent<player>().Damage(damage);
        }
        
        if (coll.gameObject.tag == "bala")
        {
            Debug.Log("Bateu");
            coll.gameObject.GetComponent<player>().Damage(damage);
        }
    }
    
    

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public int health = 100;
    
    private Animator anim;

    public int damage = 20;

    [SerializeField]
    private BarraVida barraVida;

    

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
       

    }

    public void Damage(int dmg)
    {

        health -= dmg;
        anim.SetTrigger("hurt");

        this.barraVida.Health = this.health;

        if (health <= 70)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(5.0f , 0.0f);
            damage = 30;
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
            coll.gameObject.GetComponent<Teste>().Damage(damage);
        }
    }
    
    

}

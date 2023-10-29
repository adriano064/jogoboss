using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rig;
    public float walkTime;
    private float timer;
    public bool walkRight = true;


    public int attackDamage = 10;
    private Animator anim;

    private int currentHealth;
    

    public int health = 3;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
       
    }


    void Update()
    {


    }




// Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;


        if (timer >= walkTime)
        {
            walkRight = !walkRight;
            timer = 0f;
        }


        if (walkRight)
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.velocity = Vector2.left * speed;
        }
    }

   public void TakeDamage(int dmge)
    {
        health -= dmge;
         if( transform.rotation.y == 0)
         {
             transform.position += new Vector3(-1, 0, 0);
         }
         if(transform.rotation.y == 180)
         {
             transform.position += new Vector3(1, 0, 0);
         }
        
        
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }















}


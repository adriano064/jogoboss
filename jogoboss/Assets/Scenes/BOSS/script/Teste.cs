using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teste : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rig;
    public float walkTime;
    private float timer;
    public bool walkRight = true;

    
    public int health;
    
    
    


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

    public void Damage(int dmg)
    {
        health -= dmg;
        
        if(transform.rotation.y == 0)
        {
            transform.position += new Vector3(-3, 0, 0);
        }
        if(transform.rotation.y == 180)
        {
            transform.position += new Vector3(3, 0, 0);
        }
        if( health <= 0)
        {
           
            GameController1.instance.GameOver();
            Debug.Log("Morreu");
        }

    }
    
    
      












}


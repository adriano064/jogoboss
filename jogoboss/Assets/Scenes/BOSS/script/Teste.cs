using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teste : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rig;
    public float walkTime;
    private float timer;
    public bool walkRight = true;
    
    


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

  












}


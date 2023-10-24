using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int vl;
    public int fp;

    public GameObject bola;
    public Transform firipoint;


    private bool isjump;
    private Animator anim;
    private Rigidbody2D rig;
    private bool isfiri, olhandoDireita;
    public bool atackuno;

    public float movimento;

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

        Mover();
        Jump();
        Magia();
        atack1();
        atack2();
        atack3();
    }

    void Mover()
    {
         movimento = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movimento * vl, rig.velocity.y);

        if (movimento > 0 && !isjump && !atackuno)
        { 
            anim.SetInteger("transition", 1);
            transform.eulerAngles = new Vector3(0, 0, 0);
            olhandoDireita = true;
        }

        if (movimento < 0 && !isjump  && !atackuno)
        {
            anim.SetInteger("transition", 1);
            transform.eulerAngles = new Vector3(0, 180, 0);
            olhandoDireita = false;
        }

        if (movimento == 0 && !isjump && !isfiri && !atackuno)
        {
            anim.SetInteger("transition", 0);
        }
    }
    void Jump()
    {

        if (Input.GetButtonDown("Jump"))
        {
            if(!isjump)
            {
                anim.SetInteger("transition", 2);
                rig.AddForce(new Vector2(0, fp), ForceMode2D.Impulse);
                isjump = true;
            
            }
           
        }
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 6 )
        {
            isjump = false;

        }
    }


    void Magia()
    {
        {
            StartCoroutine("Fire");
        }
    }


    IEnumerator Fire()
    {
        
        
            if (Input.GetKeyDown(KeyCode.Z)) 
            {
                isfiri = true;
                anim.SetInteger("transition", 6);
                GameObject clone = Instantiate(bola, firipoint.position, firipoint.rotation);

           
                clone.GetComponent<bola>().isRight = olhandoDireita;
            

            

                yield return new WaitForSeconds(0.4f);
                isfiri = false;
                anim.SetInteger("transition", 0);
            }
        
    }

    void atack1()
    {
        {
            StartCoroutine("Fire1");
        }
    }
    
    IEnumerator Fire1()
    {
        
        
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            atackuno = true;
            anim.SetInteger("transition", 3);
            
            yield return new WaitForSeconds(1f);
            atackuno = false;
            anim.SetInteger("transition", 0);
        }
        
    }
    
    

    void atack2()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetInteger("transition", 4);
        }
    }

    void atack3()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            anim.SetInteger("transition", 5);
        }
    }
}

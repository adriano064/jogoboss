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
    private bool isfiri;

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

        if (movimento > 0 && !isjump)
        { 
            anim.SetInteger("transition", 1);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (movimento < 0 && !isjump)
        {
            anim.SetInteger("transition", 1);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (movimento == 0 && !isjump && !isfiri)
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
                Instantiate(bola, firipoint.position, firipoint.rotation);

            if(transform.rotation.y == 0)
            {
                bola.GetComponent<bola>().isRight = true;
            }

            if(transform.rotation.y == 180)
            {
                bola.GetComponent<bola>().isRight = false;
            }

            yield return new WaitForSeconds(0.4f);
            isfiri = false;
            anim.SetInteger("transition", 0);
            }
        
    }

    void atack1()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetInteger("transition", 3);
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

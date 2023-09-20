using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int vl;
    public int fp;


    private bool isjump;
    private Animator anim;
    private Rigidbody2D rig;

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
        atack();
    }

    void Mover()
    {
        float movimento = Input.GetAxis("Horizontal");
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

        if (movimento == 0 && !isjump)
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

    void atack()
    {
        if (Input.GetMouseButton(0))
        {
            anim.SetInteger("transition", 4);
        }
    }
}

 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int vida = 10;
    public int vl;
    public int fp;
    public AudioClip[] audios;
    public AudioSource Source;

    public GameObject bola;
    public Transform firipoint;
    public GameObject spadaSimples;
    public GameObject raio;
    public GameObject combolateral;


    private bool isjump;
    private Animator anim;
    private Rigidbody2D rig;
    private bool isfiri, olhandoDireita;
    public bool atackuno;
    public bool atackduo;
    public bool atacktri;
    public bool atackqua;

    public float movimento;

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        gamerControler.instance.UpdateVidas(vida);
        Source = GetComponent<AudioSource>();


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

       if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Play(0);
        }

        if (movimento > 0 && !isjump && !atackuno && !atackduo && !atacktri)
        { 
            anim.SetInteger("transition", 1);
            transform.eulerAngles = new Vector3(0, 0, 0);
            
            olhandoDireita = true;
           
        }

        if (movimento < 0 && !isjump  && !atackuno && !atackduo && !atacktri)
        {
            anim.SetInteger("transition", 1);
            transform.eulerAngles = new Vector3(0, 180, 0);
            olhandoDireita = false;
           
        }

        if (movimento == 0 && !isjump && !isfiri && !atackuno && !atackduo && !atacktri)
        {
            anim.SetInteger("transition", 0);
            Source.Stop();
        }
    }
    void Jump()
    {

        
        if (Input.GetButtonDown("Jump"))
        {
            


            if (!isjump)
            {
             
                anim.SetInteger("transition", 2);
                rig.AddForce(new Vector2(0, fp), ForceMode2D.Impulse);
                isjump = true;
                Play(3);
                


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
                Play(2);
                anim.SetInteger("transition", 6);
                GameObject clone = Instantiate(bola, firipoint.position, firipoint.rotation);
              
                clone.GetComponent<bola>().isRight = olhandoDireita;
        
                yield return new WaitForSeconds(0.4f);
                isfiri = false;
                anim.SetInteger("transition", 0);
                Source.Stop();
                StopCoroutine(nameof(Fire));





        }

    }

    void atack1()
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            Play(1);
            StartCoroutine("Fire1");
        }
    }
    
    IEnumerator Fire1()
    {
        atackuno = true;
            anim.SetInteger("transition", 3);
            yield return new WaitForSeconds(0.8f);
            GameObject spadaSimples = Instantiate(this.spadaSimples, this.firipoint.position, Quaternion.identity);
          


        yield return new WaitForSeconds(0.2f);
            atackuno = false;
            anim.SetInteger("transition", 0);
        Source.Stop();
        StopCoroutine(nameof(Fire1));
    }
    
    
    void atack2()
    {
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            Play(2);
            StartCoroutine("Fire2");
        }
    }
    
    IEnumerator Fire2()
    {
        atackduo = true;
            anim.SetInteger("transition", 5);
            yield return new WaitForSeconds(0.6f);
            GameObject raio = Instantiate(this.raio, this.firipoint.position, Quaternion.identity);

            
            yield return new WaitForSeconds(0.5f);
            atackduo = false;
            anim.SetInteger("transition", 0);
        Source.Stop();
        StopCoroutine(nameof(Fire2));
        }



    void atack3()
    {   if (Input.GetKeyDown(KeyCode.V)) 
        {
           
            StartCoroutine("Fire3");
        }
    }
    
    
    IEnumerator Fire3()
    {
        
            atacktri = true;
        Play(1);
        anim.SetInteger("transition", 4);
            yield return new WaitForSeconds(0.8f);
            Play(1);
            GameObject combolateral = Instantiate(this.combolateral, this.firipoint.position, Quaternion.identity);

            
            yield return new WaitForSeconds(0.5f);
          
            atacktri = false;
            anim.SetInteger("transition", 0);
            Source.Stop();
            StopCoroutine(nameof(Fire3));
    }

   public void Damage ( int dmg)
    {
        vida -= dmg;
        gamerControler.instance.UpdateVidas(vida);

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

   void Play(int valor)
   {
       if (valor >= 0 && valor < audios.Length)
       {
           Source.clip = audios[valor];
           Source.Play();
       }
   }
}

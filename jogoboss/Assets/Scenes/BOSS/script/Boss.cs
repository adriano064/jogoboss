using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public Transform alvo;


    private Rigidbody2D rig;
    private float timer;
    public bool walkRight = true;


    public int health;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


        if (Vector2.Distance(transform.position, alvo.position) > stoppingDistance)
        {
            alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        }

    }

    void Update()
    {



    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;




        if (timer >= (Vector2.Distance(transform.position, alvo.position)))
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

// Update is called once per frame

   





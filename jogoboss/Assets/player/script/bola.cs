using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{

    private Rigidbody2D rig;
    public float speed;
    public int demager;

    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isRight)
        {
          rig.velocity = Vector2.right * speed;
        }
        else
        {
          rig.velocity = Vector2.left * speed;
        }
          
    }


    public void OnTriggerEnter2D(Collider2D ccollision)
    {
        if (ccollision.gameObject.tag == "inimigo") ///usar a tag do inimigo
        {
            ccollision.GetComponent<inimigo>().dano(demager);
            Destroy(gameObject);
        }
    }
}

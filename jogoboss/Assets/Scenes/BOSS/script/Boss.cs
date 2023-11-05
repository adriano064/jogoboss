using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    public Transform posPlayer;

    public float speedBoss;

    public bool wasInverted = false;

    public int damage = 1;

    





    // Start is called before the first frame update
    void Start()
    {
        posPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Seguir();
    }

    private void Seguir()
    {
        if (posPlayer.gameObject != null)
        {
            transform.position =
                Vector2.MoveTowards(transform.position, posPlayer.position, speedBoss * Time.deltaTime);
        }
    }

    public void LookAtPlayer()
    {
        Vector3 inverted = transform.localScale;
        inverted.z *= -1f;

        if (transform.position.x > posPlayer.position.x && wasInverted)
        {
            transform.localScale = inverted;
            transform.Rotate(0f, 180f, 0f);
            wasInverted = false;
        }
        else if (transform.position.x < posPlayer.position.x && !wasInverted)
        {
            transform.localScale = inverted;
            transform.Rotate(0f, 180f, 0f);
            wasInverted = true;
        }
    }
   
}



// Update is called once per frame

   






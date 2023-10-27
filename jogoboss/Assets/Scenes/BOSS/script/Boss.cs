using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : MonoBehaviour
{
    private Transform posPlayer;

    public float speedBoss;

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
}

// Update is called once per frame

   






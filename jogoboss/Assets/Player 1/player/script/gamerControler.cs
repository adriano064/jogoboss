using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamerControler : MonoBehaviour
{

    public Text vidatext;
    public static gamerControler instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVidas(int value)
    {
        vidatext.text = "x " + value.ToString();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raios : MonoBehaviour

{
    public float tempodevida;
    public int demage;
    public GameObject raio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D ccollision)
    {
        if (ccollision.gameObject.tag == "Boss1") ///usar a tag do inimigo
        {
            ccollision.GetComponent<Boss_Health>().Damage(demage);
        }
        if (ccollision.gameObject.tag == "Golem") ///usar a tag do inimigo
        {
            ccollision.GetComponent<BossHealth>().TakeDamage(demage); /// nome do script e do metodo
        }
    }
    
    void Update()
    {
        tempodevida -= Time.deltaTime;
        if (tempodevida <= 0) Destroy(gameObject);
    }
}

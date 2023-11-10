using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portaldefases : MonoBehaviour
{
    public string nomedafase;
    public BossHealth bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int healthDoBoss = bossHealth.health;

        if (healthDoBoss <= 0)
        {
            CarregarNovaFasse();
        }
    }

    
    public void CarregarNovaFasse()
    {
        SceneManager.LoadScene(nomedafase);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    // Start is called before the first frame update

    public int attackDamage = 20;


    public Vector3 attackOffSet;
    public float attackRange = 1f;
    public LayerMask attackMask;

    
   

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffSet.x;
        pos += transform.up * attackOffSet.y;

        Collider2D col = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (col != null)
        {
            col.GetComponent<Teste>().Damage(attackDamage);
        }


    }

   

    private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffSet.x;
        pos += transform.up * attackOffSet.y;
        
        Gizmos.DrawWireSphere(pos, attackRange);
      
    }
}

   

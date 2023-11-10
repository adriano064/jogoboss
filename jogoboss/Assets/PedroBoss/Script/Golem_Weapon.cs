using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Weapon : MonoBehaviour
{
    public int attackDamage = 1;
    public int enragedAttackDamage = 2;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    
    [SerializeField] private AudioSource EnragedAttackSoundEffect;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        // Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
       // if (colInfo.gameObject.tag == "Player")
       // {
       //     colInfo.GetComponent<player>().TakeDamage(attackDamage);
       // }
    }
    

    public void EnragedAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        
        EnragedAttackSoundEffect.Play();

        //Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        //if (colInfo != null)
        //{
        //    colInfo.GetComponent<PlayerHealth>().TakeDamage(enragedAttackDamage);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<player>().Damage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}

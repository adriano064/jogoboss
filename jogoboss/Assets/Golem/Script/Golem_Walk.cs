using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Walk : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    
    Transform player;
    Rigidbody2D rig;
    Golem golem;

    [SerializeField] private AudioSource walkSound;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rig = animator.GetComponent<Rigidbody2D>();
        golem = animator.GetComponent<Golem>();
        walkSound = golem.walkSound;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        golem.LookAtPlayer();
        
        Vector2 target = new Vector2(player.position.x, rig.position.y);
        Vector2 newPos = Vector2.MoveTowards(rig.position, target, speed * Time.fixedDeltaTime);
        rig.MovePosition(newPos);

        if (!walkSound.isPlaying)
        {
            walkSound.Play();
        }

        if (Vector2.Distance(player.position, rig.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
            if (attackRange > 3)
            {
                animator.SetBool("Stage1", false);
            }
            if(attackRange < 3)
            {
                animator.SetBool("Stage1", true);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        walkSound.Stop();
    }

    
}

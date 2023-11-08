using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Walk : StateMachineBehaviour
{

    private Transform posPlayer;
    private Rigidbody2D rig;
    public float speedBoss = 2.5f;

    private Boss boss;

    public float attackRange= 3f;
    private AudioSource audio;


    

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       posPlayer = GameObject.FindGameObjectWithTag("Player").transform;
       rig = animator.GetComponent<Rigidbody2D>();
       boss = animator.GetComponent<Boss>();
       audio = animator.GetComponent<AudioSource>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        Vector2 target = new Vector2(posPlayer.position.x, rig.position.x);
        Vector2 newPos = Vector2.MoveTowards(rig.position, target, speedBoss * Time.fixedDeltaTime);
        rig.MovePosition(newPos);

        if (Vector2.Distance(posPlayer.position, rig.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
            audio.Play();
        }
    }




    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("Attack");
       
    }

}

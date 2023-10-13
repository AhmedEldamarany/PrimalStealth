using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingState : StateMachineBehaviour
{
    private const string IS_ATTACKING = "isAttacking";
    private const string IS_CHASING = "isChasing";

    private NavMeshAgent agent;
    private Transform player;
    private float attackingDistance = 2.5f;
    private float chasingDistance = 5f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameReferences.Instance.GetPlayerRef().transform;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        float attackingDistance = Vector3.Distance(animator.transform.position, player.position);
        if (attackingDistance < this.attackingDistance)
        {
            animator.SetBool("isChasing", false);
            animator.SetBool(IS_ATTACKING, true);
        }
        else if (attackingDistance > chasingDistance)
        {
            animator.SetBool(IS_CHASING, false);
            animator.SetBool(IS_ATTACKING, false);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

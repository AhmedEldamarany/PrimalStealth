using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : StateMachineBehaviour
{
    private float waitingTime = 5f;
    private const string IS_CHASING = "isChasing";
    private const string IS_WALKING = "isWalking";
    private const string IS_EATING = "isEating";
    private const string IS_DRINKING = "isDrinking";
    private float timer;
    private float timeForEating = 20f;
    private float timeForDrinking = 30f;
    private string[] playRandomState = { IS_WALKING, IS_EATING, IS_DRINKING };
    private string currentState;

    private Transform player;
    private float chaseDistance = 20;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameReferences.Instance.GetPlayerRef().transform;
        timer = 0;
        currentState = playRandomState[Random.Range(0, playRandomState.Length)];
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            animator.SetBool(currentState, true);
        }
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < chaseDistance)
        {
            animator.SetBool(IS_CHASING, true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
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

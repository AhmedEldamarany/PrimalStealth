using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToDrink : StateMachineBehaviour
{
    private const string IS_DRINKING = "isDrinking";
    private const string DRINKING_STATE = "DrinkingState";
    private const string IS_CHASING = "isChasing";

    private NavMeshAgent agent;
    private List<GameObject> water = new List<GameObject>();
    private Vector3 finalDestination;
    private float waitingTime = 4f;
    private float timer;

    private Transform player;
    private float chaseDistance = 20;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameReferences.Instance.GetPlayerRef().transform;

        timer = 0;
        water = GameReferences.Instance.GetWaterPosList();
        Vector3 randomFoodPos = water[Random.Range(0, water.Count)].transform.position;
        finalDestination = randomFoodPos;
        agent = animator.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        float distance = agent.remainingDistance;

        agent.SetDestination(finalDestination);
        if (distance <= 0.0002f)
        {
            animator.SetBool(IS_DRINKING, false);
        }
        float chacingDistance = Vector3.Distance(animator.transform.position, player.position);
        if (chacingDistance < chaseDistance)
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

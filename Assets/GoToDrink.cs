using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToDrink : StateMachineBehaviour
{
    private const string IS_DRINKING = "isDrinking";
    private const string DRINKING_STATE = "DrinkingState";

    private NavMeshAgent agent;
    private List<GameObject> water = new List<GameObject>();
    private Vector3 finalDestination;
    private float waitingTime = 4f;
    private float timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
        agent.SetDestination(finalDestination);
        if (agent.remainingDistance <= 0.02f)
        {
            animator.SetBool(IS_DRINKING, false);
            animator.SetBool(DRINKING_STATE, true);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToEat : StateMachineBehaviour
{
    private const string IS_EATING = "isEating";
    private const string EATING_STATE = "EatingState";
    private NavMeshAgent agent;
    private List<GameObject> food = new List<GameObject>();
    private Vector3 finalDestination;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        food = GameReferences.Instance.GetFoodList();
        Vector3 randomFoodPos = food[Random.Range(0, food.Count)].transform.position;
        finalDestination = randomFoodPos;
        agent = animator.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = agent.remainingDistance;
        agent.SetDestination(finalDestination);
        if (distance <= 0.02f)
        {
            animator.SetBool(IS_EATING, false);
        }
        //if (distance <= agent.stoppingDistance)
        //{
        //    animator.SetBool(EATING_STATE, true);

        //}
        
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

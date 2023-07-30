
using UnityEngine;
using UnityEngine.AI;
using Panda;
public class RabbitBrain : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    
    Vector3 randomPoint;
    Vector3 randomDirection;
    NavMeshHit hit;
    Vector3 finalPosition;
    [Task]
    public void GOTORandomPoint()
    {
        randomPoint = RandomNavmeshLocation(5);
        if (randomPoint == Vector3.zero)
        {
            ThisTask.Fail();
        }
        else
        {
            agent.SetDestination(randomPoint);

        }
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
         randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
         finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}

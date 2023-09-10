using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UtilsClass : MonoBehaviour
{
    static Vector3 randomDirection;
    static NavMeshHit hit;
    static Vector3 finalPosition;
    static Vector3 randomPoint;

    public static UtilsClass Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public static Vector3 GetRandomDir()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    public static Vector3 GetRandomPosition(Vector3 startingPosition)
    {
        return startingPosition + GetRandomDir() * Random.Range(10f, 50f);
    }
    public static Vector3 RandomNavmeshLocation(float radius,Vector3 position)
    {
        randomDirection = Random.insideUnitSphere * radius;
        randomDirection += position;
        finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}

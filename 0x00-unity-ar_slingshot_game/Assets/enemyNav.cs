using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyNav : MonoBehaviour
{
    private NavMeshAgent enemy;
    private Vector3 targetPosition;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }
    void Update()
    {
        if (!enemy.pathPending && enemy.remainingDistance < 0.1f)
            SetRandomDestination();
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitCircle * 2; //max range, max distance - placeholder becuz you have to move within mesh bounds
        randomDirection += transform.position;
        NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, 2, NavMesh.AllAreas);
        targetPosition = hit.position;
        enemy.SetDestination(targetPosition);
    }
}

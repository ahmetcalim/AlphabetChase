using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Vector3 currentDestination;
    public bool move;
    private Player player;
    public virtual void Start()
    {
        player = GetComponent<Player>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentDestination = GetRandomPoint(transform.position, 30f);
    }
    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsGameRunning())
        {
            Stop();
            return;
        }
        if (move)
        {
            player.animationSpeed = navMeshAgent.velocity.magnitude;
            navMeshAgent.SetDestination(currentDestination);
            if (navMeshAgent.remainingDistance > 2f)
            {
                Debug.Log("Running");

            }
            else
            {
                Debug.Log("Finding");
                currentDestination = GetRandomPoint(transform.position, 30f);
            }
        }
        
    }

    // Get Random Point on a Navmesh surface
    public static Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;

        NavMeshHit hit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);

        return hit.position;
    }
    public void Stop()
    {
        move = false;
        navMeshAgent.enabled = false;
    }
    public void StartMoving()
    {
        move = true;

        navMeshAgent.enabled = true;
    }
}

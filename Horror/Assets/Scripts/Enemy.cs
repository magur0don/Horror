using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform TargetPlayer;

    private NavMeshAgent navMeshAgent;

    public Animator Animator;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        navMeshAgent.SetDestination(TargetPlayer.transform.position);

        Animator.SetFloat("VelocitySpeed",navMeshAgent.desiredVelocity.magnitude);
    }
}

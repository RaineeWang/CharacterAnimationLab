using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class YBotController : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;

    int isWalkingHash;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        isWalkingHash = Animator.StringToHash("isWalking");
    }

    private void Update()
    {
        bool isMoving = agent.velocity.magnitude > 0.01f && agent.remainingDistance > agent.radius;///once the remaining distance is witin the radius, we reached the target

        animator.SetBool("isWalking", isMoving);
    }
}

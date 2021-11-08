using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class YBotController : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;

    int isWalkingHash;
    int velocityZHash;
    int velocityXHash;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        isWalkingHash = Animator.StringToHash("isWalking");
        velocityXHash = Animator.StringToHash("velocityX");
        velocityZHash = Animator.StringToHash("velocityZ");


        
    }

    private void Update()
    {
        Vector3 velocity = agent.velocity;////the 2D Simple Directional, from blending tree
        bool isMoving = agent.velocity.magnitude > 0.01f && agent.remainingDistance > agent.radius;///once the remaining distance is witin the radius, we reached the target

        animator.SetBool("isWalking", isMoving);

        ///transform the velocity, make the velocity LOCAL
        velocity = transform.InverseTransformVector(velocity);
        
        animator.SetFloat("velocityXHash", velocity.x);
        animator.SetFloat("velocityZHash", velocity.z);////if we jump, we will use velocity.y


    }
}

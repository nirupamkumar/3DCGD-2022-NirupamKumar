using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrisonerIdleStateBehaviour : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private AudioSource audioSource;

    private Transform playerLookat;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        playerLookat = GameObject.Find("Lookat").transform;

        agent.isStopped = true;

        AudioManager.SingletonManager.PlaySfx(SfxClip.Idle, true, animator.gameObject, 1, 15);
        Debug.Log("Prisoner idle sfx 3d sound is active");

        audioSource = animator.GetComponent<AudioSource>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(playerLookat);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.isStopped = false;
        audioSource.loop = false;
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

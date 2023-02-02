using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineController : MonoBehaviour
{
    public Animator animator;
    private Transform target;

    private void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        animator.SetFloat("distanceFromPlayer", distance);
    }
}

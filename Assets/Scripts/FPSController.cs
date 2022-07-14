using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    private CharacterController characterController;

    //Move
    [SerializeField] private float _moveSpeed;

    //Jump
    [SerializeField] private float _jumpPower;
    private bool _isGround;
    public LayerMask groundLayer;

    //dash
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashTime;

    public Vector3 _moveDirection;
   
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
        Jump();

        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(Dash());
        }
    }

    void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, 0, moveZ);

        characterController.Move(move * _moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

    IEnumerator Dash()
    {
        //characterController.Move( move direction * dashspeed * Time.deltaTime);
        yield return null;
    }
}

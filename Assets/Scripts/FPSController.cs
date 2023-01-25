using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    #region properties

    private CharacterController characterController;

    [Header("--Player Movement--")]
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _sprintSpeed = 8f;


    [Header("--Dash--")]
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashTime;
    

    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode dashKey = KeyCode.F;

    public Vector3 _moveDirection;

    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
        Sprint();

        if (Input.GetKeyDown(dashKey))
        {
            StartCoroutine(Dash());
        }

    }

    void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        //Vector3 move = new Vector3(moveX, 0, moveZ);
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        characterController.Move(move * _moveSpeed * Time.deltaTime);

        _moveDirection = move;
    }

    void Sprint()
    {
        if(Input.GetKey(sprintKey))
        {
            _moveSpeed= _sprintSpeed;
        }
        else
        {
            _moveSpeed = 4f;
        }
    }

    
    IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + _dashTime)
        {
            characterController.Move(_moveDirection * _dashSpeed * Time.deltaTime);
            yield return null;
        }
    }
}

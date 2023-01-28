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
    

    private KeyCode sprintKey = KeyCode.LeftShift;
    private KeyCode dashKey = KeyCode.F;

    public Vector3 _moveDirection;

    private float _gravity = -9.81f;
    private float _gravityMultiplier = 3f;
    private float _velocity;

    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        AudioManager.SingletonManager.PlayMusic(MusicClip.Background);
        AudioManager.SingletonManager.PlaySfx(SfxClip.Walk);
    }

    void Update()
    {
        Movement();
        Sprint();
        ApplyGravity();

        if (Input.GetKeyDown(dashKey))
        {
            StartCoroutine(Dash());
        }
    }

    void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
       
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * _moveSpeed * Time.deltaTime);

        _moveDirection = move;
        //_moveDirection = new Vector3(move.x, 0f, move.z);
    }

    void ApplyGravity()
    {
        if(IsGrounded() && _velocity < 0f)
        {
            _velocity = -1f;
        }
        else
        {
            _velocity += _gravity * _gravityMultiplier * Time.deltaTime;
        }

        _moveDirection.y = _velocity;
    }

    private bool IsGrounded() => characterController.isGrounded;

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

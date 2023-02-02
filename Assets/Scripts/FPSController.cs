using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    #region properties

    private CharacterController characterController;

    [Header("Player Movement")]
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _sprintSpeed = 8f;


    [Header("Dash")]
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashTime;
    

    private KeyCode sprintKey = KeyCode.LeftShift;
    private KeyCode dashKey = KeyCode.F;

    public Vector3 _moveDirection;

    private float _gravity = -9.81f;
    private float _gravityMultiplier = 20f;

    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //AudioManager.SingletonManager.PlayMusic(MusicClip.Background);
    }

    void Update()
    {
        Movement();
        Sprint();
       

        if (Input.GetKeyDown(dashKey))
        {
            StartCoroutine(Dash());
            AudioManager.SingletonManager.PlaySfx(SfxClip.Dash);
        }

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    AudioManager.SingletonManager.PlaySfx(SfxClip.Walk);
        //}
    }

    void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
       
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        move.y += _gravity* _gravityMultiplier * Time.deltaTime;
        characterController.Move(move * _moveSpeed * Time.deltaTime);

        
        _moveDirection = move;
        //_moveDirection = new Vector3(move.x, 0f, move.z);
    }

    

    private bool IsGrounded() => characterController.isGrounded;

    void Sprint()
    {
        if(Input.GetKey(sprintKey))
        {
            _moveSpeed= _sprintSpeed;
            //AudioManager.SingletonManager.PlaySfx(SfxClip.Sprint, true);
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

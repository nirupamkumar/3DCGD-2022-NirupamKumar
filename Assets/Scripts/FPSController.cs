using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    #region properties

    private CharacterController characterController;
    public AudioSource audioSource;

    [Header("--Player Movement--")]
    [SerializeField] private float _moveSpeed = 12f;
    public AudioClip footSteps;

    [Header("--Gravity--")]
    public float gravity = -9.81f;
    private Vector3 velocity;

    [Header("--Jump--")]
    [SerializeField] private float _jumpPower;
    private bool _isGround;
    public LayerMask groundLayer;

    [Header("--Dash--")]
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashTime;

    public Vector3 _moveDirection;

    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        if (Input.GetKeyDown(KeyCode.F))
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

        if(Input.GetKeyDown(KeyCode.W))
            audioSource.PlayOneShot(footSteps);
    }


    #region Jump
    void Jump()
    {
        
    }
    void GroundCheck()
    {

    }
    #endregion


    IEnumerator Dash()
    {
        //characterController.Move( move direction * dashspeed * Time.deltaTime);
        yield return null;
    }
}

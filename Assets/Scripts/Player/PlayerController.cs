using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement variables")] 
    [SerializeField]
    private float speed;
    [SerializeField]
    private float checkRadius; // 0,3
    [SerializeField]
    private float jumpTime; //0,33
    [SerializeField]
    private float fallMultiplier; //1,25
    [SerializeField]
    private LayerMask whatIsGround; //Ground
    [SerializeField]
    private float jumpForce;

    private Animator animator;
    private float _moveInput;
    private float _jumpTimeCounter;
    private Rigidbody2D _rb;
    private Transform groundCheck;
    private bool _facingRight = true;
    private bool _isGrounded;
    private bool _isStanding;
    private bool _isRunning;
    private bool _isJumping;
    private bool _isFalling;

    private void Awake()
    {
        groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
       // animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
     //   animator.SetFloat("Velocity", Mathf.Abs(_moveInput));

        #region Movement horizontally

        if(_moveInput != 0 && _isGrounded)
        {
            _isRunning = true;
        }
        else
        {
            _isRunning = false;
        }

        if(_moveInput == 0 && _isGrounded && !_isJumping && !_isFalling)
        {
            _isStanding = true;
        }
        else
        {
            _isStanding = false;
        }

        #endregion
        #region Jump

        if (_isJumping) Jump();

        Fall();

        #endregion
        #region Flip character
        
        bool CheckIfGoingRight() => (_moveInput > 0 && !_facingRight);
        bool CheckIfGoingLeft() => (_moveInput < 0 && _facingRight);
        if(CheckIfGoingRight())
        {
            Flip();
        }

        else if (CheckIfGoingLeft())
        {
            Flip();
        }

        #endregion
    }

    public void StartJump()
    {
        if (_isGrounded)
        {
            _isJumping = true;
            _jumpTimeCounter = jumpTime;
            _rb.velocity = Vector3.up * jumpForce;
        }
    }

    private void Jump()
    {
        if (_isJumping)
            if (_jumpTimeCounter > 0)
            {
                _rb.velocity = Vector3.up * jumpForce;
                _jumpTimeCounter -= Time.fixedDeltaTime;
            }
    }

    public void EndJump()
    {
        _isJumping = false;
    }

    private void UpdateMovement()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector3(_moveInput * speed, _rb.velocity.y, 0f);
    }

    private void Fall()
    {
        if (_rb.velocity.y < 0 && !_isGrounded)
        {
            _isFalling = true;
            _rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }
        else
        {
            _isFalling = false;
        }
    }
    private void Flip()
    {
        Debug.Log("huj");
        _facingRight = !_facingRight;
        var rotation = transform.rotation;
        rotation.y += 180f;
        transform.Rotate(0f, 180f, 0f);
    }

    public void DisableController()
    {
        _rb.simulated = false;
    }
}
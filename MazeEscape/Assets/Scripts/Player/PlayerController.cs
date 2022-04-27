using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    private PlayerStat _stat;
    private PlayerSound _playerSound;
    //private Rigidbody _rigidbody;
    private CharacterController _characterController;
    private Animator _animator;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundMask;
    private Vector3 velocity;

    [SerializeField]
    private float gravity;
    [SerializeField]
    private float groundDistance;
    private float mouseSensitivity;
    private float currentCamXRotation;

    private bool isGrounded;
    private bool isCamControl;

    void Start()
    {
        _stat = GetComponent<PlayerStat>();
        _playerSound = GetComponent<PlayerSound>();
        //_rigidbody = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraConrtol();
        CursorVisible();
        Gravity();
        GroundCheck();
        TryJump();
    }

    private void Move()
    {
        //플레이어 움직임 물리값 받아오기
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _characterController.Move(move * _stat.MoveSpeed *Time.deltaTime);
        //_rigidbody.MovePosition(transform.position + move * Time.deltaTime);

        //플레이어 움직임 애니메이션
        _animator.SetFloat("X", x);
        _animator.SetFloat("Z", z);

        //플레이어 발걸음 사운드
        if (isGrounded && !_playerSound.playerAudioSource.isPlaying && _characterController.velocity.magnitude > 1f)
        {
            _playerSound.FootStepSound();
        }
    }

    private void CameraConrtol()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");

        if (isCamControl)
        {
            float mouseX = Input.GetAxisRaw("Mouse Y"); //마우스 상하 제어
            float mouseY = Input.GetAxisRaw("Mouse X"); //마우스 좌우 제어
            float xRotation = mouseX * mouseSensitivity;

            currentCamXRotation -= xRotation;
            currentCamXRotation = Mathf.Clamp(currentCamXRotation, -80f, 80f);

            _camera.transform.localEulerAngles = new Vector3(currentCamXRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseY * mouseSensitivity);
        }
    }

    private void CursorVisible()
    {
        if (GameManager.Instance.UIState != eUIState.None || GameManager.Instance.GameState != eGameState.Play)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isCamControl = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isCamControl = true;
        }
    }

    private void Gravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        _characterController.Move(velocity * Time.deltaTime);
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, _capsuleCollider.bounds.extents.y + 0.1f);

        //땅에 닿아있으면 점프 애니메이션 bool값을 false로.
        if (isGrounded)
        {
            _animator.SetBool("Jump", false);
        }
        //땅에 닿아있지 않으면 점프 애니메이션 bool값을 true로.
        else
        {
            _animator.SetBool("Jump", true);
        }
    }

    private void TryJump()
    {
        //지면에 닿은 상태에서 점프를 했는가
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(_stat.JumpHeight * -2f * gravity);
        //_rigidbody.velocity = transform.up * _stat.JumpHeight;
        //playerAnimator.Play("JUMP00", -1, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            GameManager.Instance.CurrentGameState(eGameState.Clear);
        }
        if (other.CompareTag("Trap"))
        {
            Debug.Log("함정에 걸렸습니다.");
        }
    }
}

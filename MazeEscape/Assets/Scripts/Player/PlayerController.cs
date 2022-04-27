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
        //�÷��̾� ������ ������ �޾ƿ���
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _characterController.Move(move * _stat.MoveSpeed *Time.deltaTime);
        //_rigidbody.MovePosition(transform.position + move * Time.deltaTime);

        //�÷��̾� ������ �ִϸ��̼�
        _animator.SetFloat("X", x);
        _animator.SetFloat("Z", z);

        //�÷��̾� �߰��� ����
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
            float mouseX = Input.GetAxisRaw("Mouse Y"); //���콺 ���� ����
            float mouseY = Input.GetAxisRaw("Mouse X"); //���콺 �¿� ����
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

        //���� ��������� ���� �ִϸ��̼� bool���� false��.
        if (isGrounded)
        {
            _animator.SetBool("Jump", false);
        }
        //���� ������� ������ ���� �ִϸ��̼� bool���� true��.
        else
        {
            _animator.SetBool("Jump", true);
        }
    }

    private void TryJump()
    {
        //���鿡 ���� ���¿��� ������ �ߴ°�
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
            Debug.Log("������ �ɷȽ��ϴ�.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private EnemyState _enemyState;
    private EnemyStat _enemyStat;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    private NavMeshAgent _navMeshAgent;

    [SerializeField]
    private LayerMask enemy_LayerMask;      // Ÿ�� ���̾��ũ ����
    [SerializeField]
    private float enemy_ViewingAngle;       // ���� �þ߰�
    [SerializeField]
    private float enemy_ViewingDistance;    // ���� �þ߰Ÿ�

    // Start is called before the first frame update
    void Start()
    {
        _enemyState = gameObject.AddComponent<EnemyState>();
        _enemyStat = GetComponent<EnemyStat>();
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        enemy_ViewingAngle = 45;
        enemy_ViewingDistance = 10;

        _enemyState.randomTarget = target;
        _enemyState.enemyStat = _enemyStat;
        _enemyState.animator = _animator;
        _enemyState.navMeshAgent = _navMeshAgent;
        _enemyState.enemy_LayerMask = enemy_LayerMask;
        _enemyState.enemy_ViewingAngle = enemy_ViewingAngle;
        _enemyState.enemy_ViewingDistance = enemy_ViewingDistance;
        _enemyState.SetState(new Enemy_Idle());
    }

    void FixedUpdate()
    {
        FreezeVelocity();
    }

    // �������� ������ �̵��� �������� �ʵ��� �ϴ� �Լ�
    private void FreezeVelocity()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        _enemyState.Operate();
    }
}

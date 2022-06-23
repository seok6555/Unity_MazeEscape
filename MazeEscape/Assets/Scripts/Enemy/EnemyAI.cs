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
    private LayerMask enemy_LayerMask;      // 타겟 레이어마스크 검출
    [SerializeField]
    private float enemy_ViewingAngle;       // 적의 시야각
    [SerializeField]
    private float enemy_ViewingDistance;    // 적의 시야거리

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

    // 물리력이 몬스터의 이동을 방해하지 않도록 하는 함수
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

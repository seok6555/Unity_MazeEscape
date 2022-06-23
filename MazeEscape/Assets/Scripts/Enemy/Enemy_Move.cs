using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Move : IState
{
    float currentTime = 5f;

    public void Enter(EnemyState enemyState)
    {
        Debug.Log("Enemy_Move");
        enemyState.animator.SetBool("Walking", true);

        if (enemyState.currentTarget == null)
        {
            enemyState.currentTarget = enemyState.randomTarget;
        }
    }

    public void Execute(EnemyState enemyState)
    {
        RandomState(enemyState);
        enemyState.navMeshAgent.speed = enemyState.enemyStat.MoveSpeed;
        enemyState.navMeshAgent.SetDestination(enemyState.currentTarget.position);

        // false면 경로의 계산을 완료함.
        if (!enemyState.navMeshAgent.pathPending)
        {
            // 목표 지점에 도달하면 실행.
            if (enemyState.navMeshAgent.remainingDistance <= enemyState.navMeshAgent.stoppingDistance)
            {
                // 몬스터가 이동중인지 체크.
                if (enemyState.navMeshAgent.velocity.sqrMagnitude >= 0.2f * 0.2f)
                {
                    // 현재 타겟이 랜덤타겟일때만 실행.
                    if (enemyState.currentTarget == enemyState.randomTarget)
                    {
                        // 목표지점에 도달하면 Enemy_Idle 상태로.
                        enemyState.SetState(new Enemy_Idle());
                    }
                }
            }
        }
    }

    public void Exit(EnemyState enemyState)
    {
        enemyState.animator.SetBool("Walking", false);
        currentTime = 5f;
    }

    // 랜덤한 상태 부여 함수
    private void RandomState(EnemyState enemyState)
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            int _random = Random.Range(0, 2);

            switch (_random)
            {
                case 0: // 추적
                    enemyState.SetState(new Enemy_RandomPosition());
                    break;
                case 1: // 대기
                    enemyState.SetState(new Enemy_Idle());
                    break;
                default:
                    Debug.Log("잘못된 인수");
                    break;
            }
        }
    }
}

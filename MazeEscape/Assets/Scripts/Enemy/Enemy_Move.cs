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

        // false�� ����� ����� �Ϸ���.
        if (!enemyState.navMeshAgent.pathPending)
        {
            // ��ǥ ������ �����ϸ� ����.
            if (enemyState.navMeshAgent.remainingDistance <= enemyState.navMeshAgent.stoppingDistance)
            {
                // ���Ͱ� �̵������� üũ.
                if (enemyState.navMeshAgent.velocity.sqrMagnitude >= 0.2f * 0.2f)
                {
                    // ���� Ÿ���� ����Ÿ���϶��� ����.
                    if (enemyState.currentTarget == enemyState.randomTarget)
                    {
                        // ��ǥ������ �����ϸ� Enemy_Idle ���·�.
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

    // ������ ���� �ο� �Լ�
    private void RandomState(EnemyState enemyState)
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            int _random = Random.Range(0, 2);

            switch (_random)
            {
                case 0: // ����
                    enemyState.SetState(new Enemy_RandomPosition());
                    break;
                case 1: // ���
                    enemyState.SetState(new Enemy_Idle());
                    break;
                default:
                    Debug.Log("�߸��� �μ�");
                    break;
            }
        }
    }
}

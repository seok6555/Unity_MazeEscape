using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Idle : IState
{
    float currentTime = 5f;

    public void Enter(EnemyState enemyState)
    {
        Debug.Log("Enemy_Idle");
        enemyState.animator.SetBool("Walking", false);
        enemyState.navMeshAgent.enabled = false;
    }

    public void Execute(EnemyState enemyState)
    {
        RandomState(enemyState);

        if (enemyState.currentTarget != null)
        {
            if (enemyState.currentTarget.name == "Player")
            {
                enemyState.SetState(new Enemy_Move());
            }
        }
    }

    public void Exit(EnemyState enemyState)
    {
        currentTime = 5f;
        enemyState.navMeshAgent.enabled = true;
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
                case 0: // ���� ��ġ ����
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

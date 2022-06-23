using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_RandomPosition : IState
{
    public void Enter(EnemyState enemyState)
    {
        Debug.Log("Enemy_RandomPosition");
    }

    public void Execute(EnemyState enemyState)
    {
        if (RandomPosition(enemyState.transform.position, 10, out Vector3 point))
        {
            enemyState.randomTarget.position = point;
            enemyState.SetState(new Enemy_Move());
        }
    }

    public void Exit(EnemyState enemyState)
    {
        
    }

    // ������ ��ġ ���� �Լ�. (���� ��ġ ���� center, ���� ��ġ ���� range, ��ȯ�� ���� ��ġ�� result)
    private bool RandomPosition(Vector3 center, float range, out Vector3 result)
    {
        // �׺���̼� �޽ð� ������ �ȵ� ������ ��ġ���� �������� ���� ����Ͽ� for������ 30���� �ݺ�.
        for (int i = 0; i < 30; i++)
        {
            // center�� �������� range ��ŭ�� ��ü ���� ���� ���� ��ġ���� ����.
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            // RaycastHit�� ����� NavMesh�� ����� ���� �����̳�.
            NavMeshHit hit;
            // randomPoint ��ġ�� �׺���̼� �޽ð� �����ϴ��� üũ.
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                // �����ϸ� hit�� ��ġ���� result�� ����.
                result = hit.position;
                // true ��ȯ.
                return true;
            }
        }
        // �׺���̼� �޽ð� ������ ������ ã�� ������ �� ��ȯ.
        result = Vector3.zero;
        return false;
    }
}

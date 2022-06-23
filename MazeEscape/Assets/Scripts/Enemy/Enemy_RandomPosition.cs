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

    // 랜덤한 위치 지정 함수. (랜덤 위치 기준 center, 랜덤 위치 범위 range, 반환할 랜덤 위치값 result)
    private bool RandomPosition(Vector3 center, float range, out Vector3 result)
    {
        // 네비게이션 메시가 생성이 안된 지역의 위치값을 가져왔을 때를 대비하여 for문으로 30번을 반복.
        for (int i = 0; i < 30; i++)
        {
            // center를 기준으로 range 만큼의 구체 범위 내의 랜덤 위치값을 지정.
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            // RaycastHit과 비슷한 NavMesh의 결과를 담을 컨테이너.
            NavMeshHit hit;
            // randomPoint 위치에 네비게이션 메시가 존재하는지 체크.
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                // 존재하면 hit의 위치값을 result에 대입.
                result = hit.position;
                // true 반환.
                return true;
            }
        }
        // 네비게이션 메시가 생성된 지역을 찾지 못했을 때 반환.
        result = Vector3.zero;
        return false;
    }
}

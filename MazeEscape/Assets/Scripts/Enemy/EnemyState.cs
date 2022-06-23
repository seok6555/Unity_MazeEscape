using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState : MonoBehaviour
{
    // 현재 상태
    private IState CurrentState;

    public Transform randomTarget;
    public Transform currentTarget;
    public EnemyStat enemyStat;
    public Animator animator;
    public NavMeshAgent navMeshAgent;

    public LayerMask enemy_LayerMask;      // 타겟 레이어마스크 검출
    public float enemy_ViewingAngle;       // 적의 시야각
    public float enemy_ViewingDistance;    // 적의 시야거리

    // 새로운 상태 세팅 함수
    public void SetState(IState newState)
    {
        if (CurrentState != null)
        {
            //상태가 바뀌기 전에, 이전 상태의 Exit를 호출한다.
            CurrentState.Exit(this);
        }

        //상태 교체.
        CurrentState = newState;

        //새 상태의 Enter를 호출한다.
        CurrentState.Enter(this);
    }

    // 현재 상태의 동작 호출 함수
    public void Operate()
    {
        CurrentState.Execute(this);
        Sight();
    }

    // 몬스터의 시야각 구현
    private void Sight()
    {
        // 주변에 있는 특정 콜라이더(플레이어) 검출.
        Collider[] target_Colliders = Physics.OverlapSphere(transform.position, enemy_ViewingDistance, enemy_LayerMask);

        // 검출되었다면 실행
        if (target_Colliders.Length > 0)
        {
            // 플레이어의 Transform 정보를 받아옴. 플레이어는 1명뿐이라 배열 인덱스는 0.
            Transform target_Player = target_Colliders[0].transform;
            // 몬스터와 플레이어 사이의 방향을 구함.
            Vector3 target_Direction = (target_Player.position - transform.position).normalized;
            // 몬스터의 방향과 플레이어 방향간의 각도차이를 구함.
            float target_Angle = Vector3.Angle(target_Direction, transform.forward);
            // 각도차이가 설정해둔 몬스터의 시야각에 들어왔다면 실행
            // 정면을 기준으로 왼쪽 시야 + 오른쪽 시야 = 전체 시야임으로 * 0.5f해줌.
            if (target_Angle < enemy_ViewingAngle * 0.5f)
            {
                // 레이케스트를 쏴서 검출되는게 있는지 체크
                if (Physics.Raycast(transform.position, target_Direction, out RaycastHit targetHit, enemy_ViewingDistance, 1 << LayerMask.NameToLayer("Player")))
                {
                    // 플레이어 추적
                    currentTarget = targetHit.transform;
                    SetState(new Enemy_Move());
                }
                else
                {
                    // 추적을 놓치면 원래 추적하던 랜덤 타겟으로 바꿈.
                    currentTarget = randomTarget;
                }
            }
        }
    }
}

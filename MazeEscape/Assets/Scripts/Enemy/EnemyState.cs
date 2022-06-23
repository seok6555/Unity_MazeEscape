using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState : MonoBehaviour
{
    // ���� ����
    private IState CurrentState;

    public Transform randomTarget;
    public Transform currentTarget;
    public EnemyStat enemyStat;
    public Animator animator;
    public NavMeshAgent navMeshAgent;

    public LayerMask enemy_LayerMask;      // Ÿ�� ���̾��ũ ����
    public float enemy_ViewingAngle;       // ���� �þ߰�
    public float enemy_ViewingDistance;    // ���� �þ߰Ÿ�

    // ���ο� ���� ���� �Լ�
    public void SetState(IState newState)
    {
        if (CurrentState != null)
        {
            //���°� �ٲ�� ����, ���� ������ Exit�� ȣ���Ѵ�.
            CurrentState.Exit(this);
        }

        //���� ��ü.
        CurrentState = newState;

        //�� ������ Enter�� ȣ���Ѵ�.
        CurrentState.Enter(this);
    }

    // ���� ������ ���� ȣ�� �Լ�
    public void Operate()
    {
        CurrentState.Execute(this);
        Sight();
    }

    // ������ �þ߰� ����
    private void Sight()
    {
        // �ֺ��� �ִ� Ư�� �ݶ��̴�(�÷��̾�) ����.
        Collider[] target_Colliders = Physics.OverlapSphere(transform.position, enemy_ViewingDistance, enemy_LayerMask);

        // ����Ǿ��ٸ� ����
        if (target_Colliders.Length > 0)
        {
            // �÷��̾��� Transform ������ �޾ƿ�. �÷��̾�� 1����̶� �迭 �ε����� 0.
            Transform target_Player = target_Colliders[0].transform;
            // ���Ϳ� �÷��̾� ������ ������ ����.
            Vector3 target_Direction = (target_Player.position - transform.position).normalized;
            // ������ ����� �÷��̾� ���Ⱓ�� �������̸� ����.
            float target_Angle = Vector3.Angle(target_Direction, transform.forward);
            // �������̰� �����ص� ������ �þ߰��� ���Դٸ� ����
            // ������ �������� ���� �þ� + ������ �þ� = ��ü �þ������� * 0.5f����.
            if (target_Angle < enemy_ViewingAngle * 0.5f)
            {
                // �����ɽ�Ʈ�� ���� ����Ǵ°� �ִ��� üũ
                if (Physics.Raycast(transform.position, target_Direction, out RaycastHit targetHit, enemy_ViewingDistance, 1 << LayerMask.NameToLayer("Player")))
                {
                    // �÷��̾� ����
                    currentTarget = targetHit.transform;
                    SetState(new Enemy_Move());
                }
                else
                {
                    // ������ ��ġ�� ���� �����ϴ� ���� Ÿ������ �ٲ�.
                    currentTarget = randomTarget;
                }
            }
        }
    }
}

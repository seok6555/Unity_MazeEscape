public interface IState
{
    void Enter(EnemyState enemyState);      // ���� ȣ��� ����.
    void Execute(EnemyState enemyState);    // �� �����Ӹ��� ����.
    void Exit(EnemyState enemyState);       // �������ö� ����.
}

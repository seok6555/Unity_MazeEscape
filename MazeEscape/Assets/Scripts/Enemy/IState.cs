public interface IState
{
    void Enter(EnemyState enemyState);      // 최초 호출시 실행.
    void Execute(EnemyState enemyState);    // 매 프레임마다 실행.
    void Exit(EnemyState enemyState);       // 빠져나올때 실행.
}

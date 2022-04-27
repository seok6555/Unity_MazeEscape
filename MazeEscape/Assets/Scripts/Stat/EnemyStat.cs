using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : Stat
{
    // Start is called before the first frame update
    void Start()
    {
        //초기 ID값을 세팅.
        //몬스터의 스탯 데이터는 레벨 2.
        _level = 2;

        SetStat(_level);
    }

    private void SetStat(int level)
    {
        Dictionary<int, Data.Stat> dict = GameManager.Instance.Data.StatDict;
        Data.Stat stat = dict[level];

        Hp = stat.hp;
        MaxHP = stat.hp;
        MoveSpeed = stat.moveSpeed;
        JumpHeight = stat.jumpHeight;
    }
}

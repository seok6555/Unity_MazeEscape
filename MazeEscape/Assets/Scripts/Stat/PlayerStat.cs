using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    private void Start()
    {
        //초기 ID값을 세팅.
        //플레이어의 스탯 데이터는 레벨 1.
        _level = 1;

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

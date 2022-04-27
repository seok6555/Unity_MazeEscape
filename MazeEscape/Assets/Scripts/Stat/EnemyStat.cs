using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : Stat
{
    // Start is called before the first frame update
    void Start()
    {
        //�ʱ� ID���� ����.
        //������ ���� �����ʹ� ���� 2.
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

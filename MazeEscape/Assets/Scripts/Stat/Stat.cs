using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ������ ��� �͵��� ���������� ������ �Ӽ���.
public class Stat : MonoBehaviour
{
    [SerializeField]
    protected int _level;
    [SerializeField]
    protected int _maxHP;
    [SerializeField]
    protected int _hp;
    [SerializeField]
    protected float _moveSpeed;
    [SerializeField]
    protected float _jumpHeight;

    public int Level { get { return _level; } set { _level = value; } }
    public int MaxHP { get { return _maxHP; } set { _maxHP = value; } }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public float JumpHeight { get { return _jumpHeight; } set { _jumpHeight = value; } }
}
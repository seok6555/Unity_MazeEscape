using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    protected int _totalKeyCount = 0;

    public int TotalKeyCount { get { return _totalKeyCount; } set { _totalKeyCount = value; } }

    public void AddKeyCount(int count = 1)
    {
        TotalKeyCount += count;
        TrapOn(TotalKeyCount);
    }

    public void TrapOn(int trapLevel)
    {
        switch (trapLevel)
        {
            case 1:
                break;
            case 2:
                Debug.Log(trapLevel + "���� ���� �۵�");
                break;
            case 3:
                Debug.Log(trapLevel + "���� ���� �۵�");
                break;
            default:
                break;
        }
    }
}

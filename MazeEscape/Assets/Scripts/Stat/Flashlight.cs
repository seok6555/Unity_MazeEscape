using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    protected float _maxBattery; // 손전등의 최대 배터리 용량
    [SerializeField]
    protected float _battery; // 손전등의 현재 배터리 용량

    public float MaxBattery { get { return _maxBattery; } set { _maxBattery = value; } }
    public float Battery { get { return _battery; } set { _battery = value; } }

    private void Start()
    {
        SetBattery();
    }

    private void SetBattery()
    {
        MaxBattery = 100f;
        Battery = MaxBattery;
    }
}

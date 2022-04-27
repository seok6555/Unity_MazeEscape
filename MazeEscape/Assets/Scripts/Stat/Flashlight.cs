using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    protected float _maxBattery; // �������� �ִ� ���͸� �뷮
    [SerializeField]
    protected float _battery; // �������� ���� ���͸� �뷮

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

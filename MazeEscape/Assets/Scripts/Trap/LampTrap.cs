using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTrap : Trap
{
    [SerializeField]
    private GameObject lamp;

    private void OnTriggerEnter(Collider other)
    {
        TrapOffLamp();
    }

    public void TrapOffLamp()
    {
        lamp.SetActive(false);
    }
}

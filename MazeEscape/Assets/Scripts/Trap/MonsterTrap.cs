using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrap : MonoBehaviour
{
    [SerializeField]
    private GameObject monster;

    [SerializeField]
    private Door door;

    private void OnTriggerEnter(Collider other)
    {
        door.DoorOpen();
        monster.SetActive(true);
        this.gameObject.SetActive(false);
    }
}

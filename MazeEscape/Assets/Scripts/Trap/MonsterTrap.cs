using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrap : Trap
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrapMonster()
    {
        monster.transform.LookAt(player.transform);
        monster.transform.Translate(Vector3.forward * 5 * Time.deltaTime);
    }
}

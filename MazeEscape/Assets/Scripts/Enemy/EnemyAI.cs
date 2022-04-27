using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    EnemyStat _enemyStat;

    // Start is called before the first frame update
    void Start()
    {
        _enemyStat = GetComponent<EnemyStat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

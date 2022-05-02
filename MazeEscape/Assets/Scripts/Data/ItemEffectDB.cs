using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public string itemName; // 아이템의 이름 (키값)
    public string[] part;   // 부위
    public int[] num;       // 수치
}

public class ItemEffectDB : MonoBehaviour
{
    [SerializeField]
    private ItemEffect[] itemEffects;
}

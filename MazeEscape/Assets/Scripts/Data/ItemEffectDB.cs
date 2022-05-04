using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public string itemName; // �������� �̸� (Ű��)
    public string[] part;   // ����
    public int[] num;       // ��ġ
}

public class ItemEffectDB : MonoBehaviour
{
    [SerializeField]
    private ItemEffect[] itemEffects;
}

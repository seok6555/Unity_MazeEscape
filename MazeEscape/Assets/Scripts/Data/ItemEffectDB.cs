using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public string itemName; // �������� �̸� (Ű��)
    [Tooltip("Battery")]
    public string[] part;   // �������� ��� ����
    public int[] num;       // �������� ��� ��ġ
}

public class ItemEffectDB : MonoBehaviour
{
    [SerializeField]
    private ItemEffect[] itemEffects;
    [SerializeField]
    private FlashlightController _flashlightController;

    private const string Battery = "Battery";

    // ������ ���
    public void UseItem(Item _item)
    {
        // �Ѿ�� �������� Ÿ�� ��
        if (_item.ItemType == Item.eItemType.Used)
        {
            for (int i = 0; i < itemEffects.Length; i++)
            {
                // DB�� ������ �̸� (Ű��)�� �Ѿ�� �������� �̸� ��. �迭�� ���� DB�� �ִ� �������� ������ ������.
                if (itemEffects[i].itemName == _item.ItemName)
                {
                    for (int j = 0; j < itemEffects[i].part.Length; j++)
                    {
                        // ������ �������� ���� �� ��� ������ �°� �������� ���.
                        switch (itemEffects[i].part[j])
                        {
                            case Battery:
                                _flashlightController.ChargeBattery(itemEffects[i].num[j]);
                                break;
                            default:
                                Debug.Log("�߸��� ���� ���.");
                                break;
                        }
                    }
                    return;
                }
            }
            Debug.Log("������ DB�� ��ġ�ϴ� �������� �����ϴ�.");
        }
        else if (_item.ItemType == Item.eItemType.Ingredient)
        {

        }
    }
}

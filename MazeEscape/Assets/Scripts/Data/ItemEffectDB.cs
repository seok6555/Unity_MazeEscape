using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public string itemName; // 아이템의 이름 (키값)
    [Tooltip("Battery")]
    public string[] part;   // 아이템의 사용 부위
    public int[] num;       // 아이템의 사용 수치
}

public class ItemEffectDB : MonoBehaviour
{
    [SerializeField]
    private ItemEffect[] itemEffects;
    [SerializeField]
    private FlashlightController _flashlightController;

    private const string Battery = "Battery";

    // 아이템 사용
    public void UseItem(Item _item)
    {
        // 넘어온 아이템의 타입 비교
        if (_item.ItemType == Item.eItemType.Used)
        {
            for (int i = 0; i < itemEffects.Length; i++)
            {
                // DB의 아이템 이름 (키값)과 넘어온 아이템의 이름 비교. 배열을 돌며 DB에 있는 아이템의 정보를 가져옴.
                if (itemEffects[i].itemName == _item.ItemName)
                {
                    for (int j = 0; j < itemEffects[i].part.Length; j++)
                    {
                        // 가져온 아이템의 정보 중 사용 부위에 맞게 아이템을 사용.
                        switch (itemEffects[i].part[j])
                        {
                            case Battery:
                                _flashlightController.ChargeBattery(itemEffects[i].num[j]);
                                break;
                            default:
                                Debug.Log("잘못된 부위 사용.");
                                break;
                        }
                    }
                    return;
                }
            }
            Debug.Log("아이템 DB에 일치하는 아이템이 없습니다.");
        }
        else if (_item.ItemType == Item.eItemType.Ingredient)
        {

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectDB : MonoBehaviour
{
    [SerializeField]
    //private ItemEffect[] itemEffects;
    private FlashlightController _flashlightController;

    //public void UseItem(Item _item)
    //{
    //    if (_item.ItemType == Item.eItemType.Equipment)
    //    {

    //    }
    //    else if (_item.ItemType == Item.eItemType.Used)
    //    {
    //        for (int i = 0; i < itemEffects.Length; i++)
    //        {
    //            if (itemEffects[i].itemName == _item.ItemName)
    //            {
    //                for (int j = 0; j < itemEffects[i].part.Length; j++)
    //                {
    //                    switch (itemEffects[i].part[j])
    //                    {
    //                        case "Battery":
    //                            _flashlightController.ChargeBattery(itemEffects[i].num[j]);
    //                            break;
    //                        default:
    //                            Debug.Log("������ ������ �����ϴ�.");
    //                            break;
    //                    }
    //                }
    //                return;
    //            }
    //        }
    //        Debug.Log("������ DB�� �����ϴ�.");
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Item
{
    private void Start()
    {
        SetItemDB("Battery");
        //Debug.Log(this.name);
    }

    private void SetItemDB(string _itemName)
    {
        Dictionary<string, Data.ItemEffect> dict = GameManager.Instance.Data.ItemEffectDict;
        Data.ItemEffect a = dict[_itemName];

        ItemName = a.itemName;
        ItemType = a.itemType;
        Part = a.part;
        Num = a.num;
    }
}

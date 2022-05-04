using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ItemEffectData.json에서 불러온 아이템의 DB를 총괄. 아이템이 공통적으로 가지는 속성들.
public class Item : MonoBehaviour
{
    [SerializeField]
    protected string _itemName; // 아이템의 이름 (키값)
    [SerializeField]
    protected string _itemType; // 아이템의 타입 (Equipment - 장비, Used - 소모품, Ingredient - 재료, ETC - 기타
    [SerializeField]
    protected string _part;     // 아이템의 적용 부위
    [SerializeField]
    protected int _num;         // 아이템의 수치

    public string ItemName { get { return _itemName; } set { _itemName = value; } }
    public string ItemType { get { return _itemType; } set { _itemType = value; } }
    public string Part { get { return _part; } set { _part = value; } }
    public int Num { get { return _num; } set { _num = value; } }

    //[SerializeField]
    //protected Sprite itemImage;
    //[SerializeField]
    //protected GameObject itemPrefab;

    //public Sprite ItemImage { get { return itemImage; } }
    //public GameObject ItemPrefab { get { return itemPrefab; } }

    private void Start()
    {
        SetItemDB(this.name);
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

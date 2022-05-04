using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ItemEffectData.json���� �ҷ��� �������� DB�� �Ѱ�. �������� ���������� ������ �Ӽ���.
public class Item : MonoBehaviour
{
    [SerializeField]
    protected string _itemName; // �������� �̸� (Ű��)
    [SerializeField]
    protected string _itemType; // �������� Ÿ�� (Equipment - ���, Used - �Ҹ�ǰ, Ingredient - ���, ETC - ��Ÿ
    [SerializeField]
    protected string _part;     // �������� ���� ����
    [SerializeField]
    protected int _num;         // �������� ��ġ

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

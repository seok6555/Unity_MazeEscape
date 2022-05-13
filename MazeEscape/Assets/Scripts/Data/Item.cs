using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����, ���͸� ��� ���� �������� ����
[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item", order = int.MaxValue)]
public class Item : ScriptableObject
{
    public enum eItemType
    {
        Equipment,  // ���
        Used,       // �Ҹ�ǰ
        Ingredient, // ���
        ETC         // ��Ÿ
    }

    [SerializeField]
    protected string itemName;
    [TextArea]
    [SerializeField]
    protected string itemDesc;
    [SerializeField]
    protected eItemType itemType;
    [SerializeField]
    protected Sprite itemImage;
    [SerializeField]
    protected GameObject itemPrefab;

    public string ItemName { get { return itemName; } }
    public string ItemDesc { get { return itemDesc; } }
    public eItemType ItemType { get { return itemType; } }
    public Sprite ItemImage { get { return itemImage; } }
    public GameObject ItemPrefab { get { return itemPrefab; } }
}

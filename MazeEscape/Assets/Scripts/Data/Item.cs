using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 열쇠, 배터리 등과 같은 아이템의 정보
[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item", order = int.MaxValue)]
public class Item : ScriptableObject
{
    public enum eItemType
    {
        Equipment,  // 장비
        Used,       // 소모품
        Ingredient, // 재료
        ETC         // 기타
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

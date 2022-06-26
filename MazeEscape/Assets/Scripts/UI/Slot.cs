using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;               // 획득한 아이템
    public int itemCount;           // 획득한 아이템의 갯수
    public Image itemImage;         // 아이템의 이미지
    public Sprite emptySlotImage;   // 빈 슬롯 이미지

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    private ItemEffectDB _itemEffectDB;

    private void Start()
    {
        _itemEffectDB = FindObjectOfType<ItemEffectDB>();
        _itemEffectDB.HideToolTip();
    }

    // 아이템 획득.
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.ItemImage;

        if (item.ItemType != Item.eItemType.Equipment)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }
    }

    // 아이템 갯수 조절.
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            ClearSlot();
        }
    }

    // 슬롯 초기화.
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = emptySlotImage;

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    // 슬롯 아이템 클릭시 이벤트.
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null)
            {
                if (item.ItemType != Item.eItemType.Ingredient)
                {
                    _itemEffectDB.UseItem(item);
                    SetSlotCount(-1);
                }
            }
        }
    }

    // 슬롯 아이템 마우스 커서가 들어갈 때 이벤트.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            _itemEffectDB.ShowToolTip(item);
        }
    }

    // 슬롯 아이템 마우스 커서가 나올 때 이벤트.
    public void OnPointerExit(PointerEventData eventData)
    {
        _itemEffectDB.HideToolTip();
    }
}

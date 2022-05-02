using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Item item;               // »πµÊ«— æ∆¿Ã≈€
    public int itemCount;           // »πµÊ«— æ∆¿Ã≈€¿« ∞πºˆ
    public Image itemImage;         // æ∆¿Ã≈€¿« ¿ÃπÃ¡ˆ
    public Sprite emptySlotImage;   // ∫Û ΩΩ∑‘ ¿ÃπÃ¡ˆ

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    // æ∆¿Ã≈€ »πµÊ.
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

    // æ∆¿Ã≈€ ∞πºˆ ¡∂¿˝.
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            ClearSlot();
        }
    }

    //ΩΩ∑‘ √ ±‚»≠.
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = emptySlotImage;

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null)
            {
                if (item.ItemType == Item.eItemType.Used)
                {
                    SetSlotCount(-1);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;               // ȹ���� ������
    public int itemCount;           // ȹ���� �������� ����
    public Image itemImage;         // �������� �̹���
    public Sprite emptySlotImage;   // �� ���� �̹���

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

    // ������ ȹ��.
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

    // ������ ���� ����.
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            ClearSlot();
        }
    }

    // ���� �ʱ�ȭ.
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = emptySlotImage;

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    // ���� ������ Ŭ���� �̺�Ʈ.
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

    // ���� ������ ���콺 Ŀ���� �� �� �̺�Ʈ.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            _itemEffectDB.ShowToolTip(item);
        }
    }

    // ���� ������ ���콺 Ŀ���� ���� �� �̺�Ʈ.
    public void OnPointerExit(PointerEventData eventData)
    {
        _itemEffectDB.HideToolTip();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Item item;               // ȹ���� ������
    public int itemCount;           // ȹ���� �������� ����
    public Image itemImage;         // �������� �̹���
    public Sprite emptySlotImage;   // �� ���� �̹���

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

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

    //���� �ʱ�ȭ.
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

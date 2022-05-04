using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;       // ȹ���� ������
    public int itemCount;   // ȹ���� �������� ����
    public Image itemImage; // �������� �̹���

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

<<<<<<< HEAD
    private ItemEffectDB _itemEffectDB;
=======
    // �̹����� ���� ����.
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
>>>>>>> parent of db07ee3 (2022.05.02. UI 수정 작업)

    // ������ ȹ��.
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        //itemImage.sprite = item.ItemImage;

        if (item.ItemType != "Equipment")
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }
<<<<<<< HEAD
        Debug.Log(item);
=======

        SetColor(1);
>>>>>>> parent of db07ee3 (2022.05.02. UI 수정 작업)
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
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }
<<<<<<< HEAD

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null)
            {
                //_itemEffectDB.UseItem(item);
                SetSlotCount(-1);
            }
        }
    }
=======
>>>>>>> parent of db07ee3 (2022.05.02. UI 수정 작업)
}

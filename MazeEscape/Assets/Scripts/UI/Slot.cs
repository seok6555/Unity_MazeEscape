using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;       // È¹µæÇÑ ¾ÆÀÌÅÛ
    public int itemCount;   // È¹µæÇÑ ¾ÆÀÌÅÛÀÇ °¹¼ö
    public Image itemImage; // ¾ÆÀÌÅÛÀÇ ÀÌ¹ÌÁö

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

<<<<<<< HEAD
    private ItemEffectDB _itemEffectDB;
=======
    // ÀÌ¹ÌÁöÀÇ Åõ¸íµµ Á¶Àı.
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
>>>>>>> parent of db07ee3 (2022.05.02. UI ìˆ˜ì • ì‘ì—…)

    // ¾ÆÀÌÅÛ È¹µæ.
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
>>>>>>> parent of db07ee3 (2022.05.02. UI ìˆ˜ì • ì‘ì—…)
    }

    // ¾ÆÀÌÅÛ °¹¼ö Á¶Àı.
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            ClearSlot();
        }
    }

    //½½·Ô ÃÊ±âÈ­.
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
>>>>>>> parent of db07ee3 (2022.05.02. UI ìˆ˜ì • ì‘ì—…)
}

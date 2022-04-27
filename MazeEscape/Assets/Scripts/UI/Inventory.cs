using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;

    [SerializeField]
    private Text text_Count; // 아이템 갯수 텍스트
    private Item item; // 획득한 아이템

    private int itemCount; // 획득한 아이템 갯수

    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotParent;

    private Slot[] slots;

    private void Start()
    {
        slots = go_SlotParent.GetComponentsInChildren<Slot>();
    }

    private void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
    }

    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }

    public void AcquireItem(Item _item, int _count = 1)
    {
        if (Item.eItemType.Equipment != _item.ItemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].item.ItemName == _item.ItemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }

    public bool UseItem(int _count = 1)
    {
        if (itemCount <= 0)
        {
            Debug.Log("아이템이 없습니다.");
            return false;
        }
        else
        {
            Debug.Log("아이템 사용");
            itemCount -= _count;
            text_Count.text = itemCount.ToString();
            return true;
        }
    }
}

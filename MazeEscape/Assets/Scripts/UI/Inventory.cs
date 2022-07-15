using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotParent;

    private Slot[] slots;

    private void Start()
    {
        slots = go_SlotParent.GetComponentsInChildren<Slot>();
        CloseInventory();
    }

    private void Update()
    {
        TryOpenInventory();
    }

    // 인벤토리 열기 시도
    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (GameManager.Instance.UIState != eUIState.Inventory)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
    }

    // 인벤토리 열기
    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
        GameManager.Instance.CurrentUIState(eUIState.Inventory);
    }

    // 인벤토리 닫기
    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
        GameManager.Instance.CurrentUIState(eUIState.None);
    }

    // 아이템 획득
    public void AcquireItem(Item _item, int _count = 1)
    {
        // 획득한 아이템의 타입 비교. 장비 아이템을 제외한 갯수가 겹치는 아이템들은 해당 조건문을 거침.
        if (Item.eItemType.Equipment != _item.ItemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                // 슬롯 배열을 순회하여 비어있지 않은 곳 체크
                if (slots[i].item != null)
                {
                    // 슬롯중에 획득한 아이템과 같은 아이템이 존재하는 경우 체크
                    if (slots[i].item.ItemName == _item.ItemName)
                    {
                        // 해당 아이템의 갯수 증가
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            // 슬롯 배열을 순회하여 비어있는 곳 체크
            if (slots[i].item == null)
            {
                // 슬롯 클래스의 아이템 획득 함수(획득한 아이템, 갯수) 실행
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }

    // 인벤토리에 해당 아이템이 있는지 체크
    public bool CheckItem(string _itemName)
    {
        // 슬롯 배열을 순회
        for (int i = 0; i < slots.Length; i++)
        {
            // 슬롯이 비어있지 않으면 실행
            if (slots[i].item != null)
            {
                // 아이템중에 찾고자 하는 아이템이 있으면 true 반환
                if (slots[i].item.ItemName == _itemName)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

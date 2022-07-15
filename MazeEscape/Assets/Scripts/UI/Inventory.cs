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

    // �κ��丮 ���� �õ�
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

    // �κ��丮 ����
    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
        GameManager.Instance.CurrentUIState(eUIState.Inventory);
    }

    // �κ��丮 �ݱ�
    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
        GameManager.Instance.CurrentUIState(eUIState.None);
    }

    // ������ ȹ��
    public void AcquireItem(Item _item, int _count = 1)
    {
        // ȹ���� �������� Ÿ�� ��. ��� �������� ������ ������ ��ġ�� �����۵��� �ش� ���ǹ��� ��ħ.
        if (Item.eItemType.Equipment != _item.ItemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                // ���� �迭�� ��ȸ�Ͽ� ������� ���� �� üũ
                if (slots[i].item != null)
                {
                    // �����߿� ȹ���� �����۰� ���� �������� �����ϴ� ��� üũ
                    if (slots[i].item.ItemName == _item.ItemName)
                    {
                        // �ش� �������� ���� ����
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            // ���� �迭�� ��ȸ�Ͽ� ����ִ� �� üũ
            if (slots[i].item == null)
            {
                // ���� Ŭ������ ������ ȹ�� �Լ�(ȹ���� ������, ����) ����
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }

    // �κ��丮�� �ش� �������� �ִ��� üũ
    public bool CheckItem(string _itemName)
    {
        // ���� �迭�� ��ȸ
        for (int i = 0; i < slots.Length; i++)
        {
            // ������ ������� ������ ����
            if (slots[i].item != null)
            {
                // �������߿� ã���� �ϴ� �������� ������ true ��ȯ
                if (slots[i].item.ItemName == _itemName)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

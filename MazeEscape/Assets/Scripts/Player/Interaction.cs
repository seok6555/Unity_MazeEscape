using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    private Trap _trap = new Trap();

    [SerializeField]
    private Image crosshairUI;
    [SerializeField]
    private Text interactMessage;
    [SerializeField]
    private Inventory _inventory;

    // Ư�� ���̾�� �����ϵ��� ����
    // Item - ���͸�, ����
    // Door - ��
    [SerializeField]
    private LayerMask layerMaskInteract;
    private RaycastHit hitInfo;

    // ��ȣ�ۿ� ��Ÿ�
    [SerializeField]
    private int rayLength = 5;

    private bool isInteractionActivated = false;

    // Update is called once per frame
    void Update()
    {
        CheckObject();
        TryInteract();
    }

    // ũ�ν��� ��ȣ�ۿ� ������Ʈ�� �ִ��� üũ�ϴ� �Լ�
    private void CheckObject()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, rayLength, layerMaskInteract))
        {
            switch (hitInfo.transform.tag)
            {
                case "Item":
                    ObjectInfoAppear();
                    break;
                case "Door":
                    ObjectInfoAppear();
                    break;
            }
        }
        else
        {
            ObjectInfoDisappear();
        }
    }

    // E Ű�� ������ ��ȣ�ۿ��� �õ��ϴ� �Լ�
    private void TryInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckObject();
            CanInteract();
        }
    }

    // ��ȣ�ۿ� ������Ʈ�� �տ� ���� �� UI ǥ�� �Լ�
    private void ObjectInfoAppear()
    {
        isInteractionActivated = true;
        crosshairUI.color = Color.red;
        interactMessage.gameObject.SetActive(true);
        interactMessage.text = "(E)";
    }

    // ��ȣ�ۿ� ������Ʈ�� �տ� ���� �� UI ǥ�� �Լ�
    private void ObjectInfoDisappear()
    {
        isInteractionActivated = false;
        crosshairUI.color = Color.white;
        interactMessage.gameObject.SetActive(false);
    }

    // ��ȣ�ۿ� ���� �Լ�
    private void CanInteract()
    {
        if (isInteractionActivated)
        {
            if (hitInfo.transform != null)
            {
                if (hitInfo.transform.CompareTag("Item"))
                {
<<<<<<< HEAD
                    //_inventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    _inventory.AcquireItem(hitInfo.transform.GetComponent<Item>());
=======
                    string pickUpItemName = hitInfo.transform.GetComponent<ItemPickUp>().item.ItemName;

                    switch (pickUpItemName)
                    {
                        case "Battery":
                            // ���͸� ä���
                            _inventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                            _flashlightController.ChargeBattery(30f);
                            break;
                        case "Key":
                            // ���� ȹ��, UI�� ȹ���� ���� ���� ���.
                            _inventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                            _trap.AddKeyCount();
                            break;
                    }
>>>>>>> parent of db07ee3 (2022.05.02. UI 수정 작업)
                    Destroy(hitInfo.transform.gameObject);
                }

                if (hitInfo.transform.CompareTag("Door"))
                {
                    // �� ���� ��� ����.
                    //if (_inventory.UseItem())
                    //{
                    //    if (hitInfo.transform.TryGetComponent<Door>(out Door _door))
                    //    {
                    //        _door.DoorOpen();
                    //    }
                    //}
                    //else
                    //{
                    //    Debug.Log("���谡 ����");
                    //}
                }
                ObjectInfoDisappear();
            }
        }
    }
}

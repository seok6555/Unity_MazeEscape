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
    private FlashlightController _flashlightController;

    // 특정 레이어에만 반응하도록 설정
    // Item - 배터리, 열쇠
    // Door - 문
    [SerializeField]
    private LayerMask layerMaskInteract;
    private RaycastHit hitInfo;

    // 상호작용 사거리
    [SerializeField]
    private int rayLength = 5;

    private bool isInteractionActivated = false;

    private void Start()
    {
        _flashlightController = GetComponentInChildren<FlashlightController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckObject();
        TryInteract();
    }

    // 크로스헤어에 상호작용 오브젝트가 있는지 체크하는 함수
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

    // E 키를 눌러서 상호작용을 시도하는 함수
    private void TryInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckObject();
            CanInteract();
        }
    }

    // 상호작용 오브젝트가 앞에 있을 때 UI 표기 함수
    private void ObjectInfoAppear()
    {
        isInteractionActivated = true;
        crosshairUI.color = Color.red;
        interactMessage.gameObject.SetActive(true);
        interactMessage.text = "(E)";
    }

    // 상호작용 오브젝트가 앞에 없을 때 UI 표기 함수
    private void ObjectInfoDisappear()
    {
        isInteractionActivated = false;
        crosshairUI.color = Color.white;
        interactMessage.gameObject.SetActive(false);
    }

    // 상호작용 실행 함수
    private void CanInteract()
    {
        if (isInteractionActivated)
        {
            if (hitInfo.transform != null)
            {
                if (hitInfo.transform.CompareTag("Item"))
                {
                    string pickUpItemName = hitInfo.transform.GetComponent<ItemPickUp>().item.ItemName;

                    switch (pickUpItemName)
                    {
                        case "Battery":
                            // 배터리 채우기
                            _inventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                            _flashlightController.ChargeBattery(30f);
                            break;
                        case "Key":
                            // 열쇠 획득, UI에 획득한 열쇠 갯수 출력.
                            _inventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                            _trap.AddKeyCount();
                            break;
                    }
                    Destroy(hitInfo.transform.gameObject);
                }

                if (hitInfo.transform.CompareTag("Door"))
                {
                    // 문 여는 기능 구현.
                    if (_inventory.UseItem())
                    {
                        if (hitInfo.transform.TryGetComponent<Door>(out Door _door))
                        {
                            _door.DoorOpen();
                        }
                    }
                    else
                    {
                        Debug.Log("열쇠가 없음");
                    }
                }
                ObjectInfoDisappear();
            }
        }
    }
}

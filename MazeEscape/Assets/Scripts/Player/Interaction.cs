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

    // Æ¯Á¤ ·¹ÀÌ¾î¿¡¸¸ ¹ÝÀÀÇÏµµ·Ï ¼³Á¤
    // Item - ¹èÅÍ¸®, ¿­¼è
    // Door - ¹®
    [SerializeField]
    private LayerMask layerMaskInteract;
    private RaycastHit hitInfo;

    // »óÈ£ÀÛ¿ë »ç°Å¸®
    [SerializeField]
    private int rayLength = 5;

    private bool isInteractionActivated = false;

    // Update is called once per frame
    void Update()
    {
        CheckObject();
        TryInteract();
    }

    // Å©·Î½ºÇì¾î¿¡ »óÈ£ÀÛ¿ë ¿ÀºêÁ§Æ®°¡ ÀÖ´ÂÁö Ã¼Å©ÇÏ´Â ÇÔ¼ö
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

    // E Å°¸¦ ´­·¯¼­ »óÈ£ÀÛ¿ëÀ» ½ÃµµÇÏ´Â ÇÔ¼ö
    private void TryInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckObject();
            CanInteract();
        }
    }

    // »óÈ£ÀÛ¿ë ¿ÀºêÁ§Æ®°¡ ¾Õ¿¡ ÀÖÀ» ¶§ UI Ç¥±â ÇÔ¼ö
    private void ObjectInfoAppear()
    {
        isInteractionActivated = true;
        crosshairUI.color = Color.red;
        interactMessage.gameObject.SetActive(true);
        interactMessage.text = "(E)";
    }

    // »óÈ£ÀÛ¿ë ¿ÀºêÁ§Æ®°¡ ¾Õ¿¡ ¾øÀ» ¶§ UI Ç¥±â ÇÔ¼ö
    private void ObjectInfoDisappear()
    {
        isInteractionActivated = false;
        crosshairUI.color = Color.white;
        interactMessage.gameObject.SetActive(false);
    }

    // »óÈ£ÀÛ¿ë ½ÇÇà ÇÔ¼ö
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
                            // ¹èÅÍ¸® Ã¤¿ì±â
                            _inventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                            _flashlightController.ChargeBattery(30f);
                            break;
                        case "Key":
                            // ¿­¼è È¹µæ, UI¿¡ È¹µæÇÑ ¿­¼è °¹¼ö Ãâ·Â.
                            _inventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                            _trap.AddKeyCount();
                            break;
                    }
>>>>>>> parent of db07ee3 (2022.05.02. UI ìˆ˜ì • ìž‘ì—…)
                    Destroy(hitInfo.transform.gameObject);
                }

                if (hitInfo.transform.CompareTag("Door"))
                {
                    // ¹® ¿©´Â ±â´É ±¸Çö.
                    //if (_inventory.UseItem())
                    //{
                    //    if (hitInfo.transform.TryGetComponent<Door>(out Door _door))
                    //    {
                    //        _door.DoorOpen();
                    //    }
                    //}
                    //else
                    //{
                    //    Debug.Log("¿­¼è°¡ ¾øÀ½");
                    //}
                }
                ObjectInfoDisappear();
            }
        }
    }
}

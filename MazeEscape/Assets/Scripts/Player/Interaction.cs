using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private Image crosshairUI;
    [SerializeField]
    private Text interactMessage;
    [SerializeField]
    private Inventory _inventory;

    // 특정 레이어에만 반응하도록 설정
    // Item - 배터리, 열쇠
    // Door - 문
    [SerializeField]
    private LayerMask layerMaskInteract;
    private RaycastHit hitInfo;

    [SerializeField]
    private int rayLength = 2;  // 상호작용 사거리

    private bool isInteractionActivated = false;

    private Material outline;   // 외곽선 셰이더
    private Renderer renderers; // 현재 상호작용 가능한 오브젝트의 Renderer
    private List<Material> materialList = new List<Material>(); // renderers의 Material을 리스트로 받아옴.

    void Start()
    {
        outline = new Material(Shader.Find("Custom/OutlineShader"));
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
            if (hitInfo.transform != null)
            {
                ObjectInfoAppear(hitInfo.transform);
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
    private void ObjectInfoAppear(Transform _hitObject)
    {
        // 현재 상호작용이 가능한 오브젝트의 Renderer컴포넌트를 받아옴.
        renderers = _hitObject.GetComponent<Renderer>();
        // 외곽선 셰이더 Material의 중복 생성을 막기위해 if문으로 한번만 생성.
        if (!materialList.Contains(outline))
        {
            materialList.Clear();
            materialList.AddRange(renderers.sharedMaterials);
            materialList.Add(outline);
            renderers.materials = materialList.ToArray();
        }

        isInteractionActivated = true;
        crosshairUI.color = Color.red;
        interactMessage.gameObject.SetActive(true);
        interactMessage.text = "(E)";
    }

    // 상호작용 오브젝트가 앞에 없을 때 UI 표기 함수
    private void ObjectInfoDisappear()
    {
        // 초기에 상호작용 오브젝트가 없을 때의 오류를 막기위해 if문으로 Renderer가 있을때만 체크하여 셰이더 제거.
        if (renderers != null)
        {
            materialList.Clear();
            materialList.AddRange(renderers.sharedMaterials);
            materialList.Remove(outline);
            renderers.materials = materialList.ToArray();
            renderers = null;
        }

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
                    _inventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    Destroy(hitInfo.transform.gameObject);
                }

                if (hitInfo.transform.CompareTag("Door"))
                {
                    // 문 여는 기능 구현.
                    // 인벤토리에 열쇠가 있는지 없는지 체크하는 방식으로 구현 예정.
                    if (_inventory.CheckItem("Key"))
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

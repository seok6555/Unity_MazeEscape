using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    public GameObject lobbyMainUI;  // �κ� ȭ���� UI
    public GameObject pauseMenuUI;  // �ΰ����� ���� �޴� UI
    public GameObject optionUI;     // �ɼ� UI
    public GameObject clearUI;      // Ŭ���� ȭ�� UI
    public GameObject inventoryUI;  // �κ��丮 UI

    public Text clearText;

    // Start is called before the first frame update
    void Start()
    {
        optionUI.SetActive(false);
    }
}

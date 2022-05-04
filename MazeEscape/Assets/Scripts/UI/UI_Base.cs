using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    public GameObject lobbyMainUI;  // 로비 화면의 UI
    public GameObject pauseMenuUI;  // 인게임의 퍼즈 메뉴 UI
    public GameObject optionUI;     // 옵션 UI
    public GameObject clearUI;      // 클리어 화면 UI
    public GameObject inventoryUI;  // 인벤토리 UI

    public Text clearText;

    // Start is called before the first frame update
    void Start()
    {
        optionUI.SetActive(false);
    }
}

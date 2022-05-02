using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : UI_Base
{
    private void Update()
    {
        OnPauseMenu();
        ClearUIOpen();
    }

    private void OnPauseMenu()
    {
        if (GameManager.Instance.GameState == eGameState.Play)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                // 메뉴를 오픈할 때
                if (GameManager.Instance.UIState == eUIState.None)
                {
                    pauseMenuUI.SetActive(true);
                    GameManager.Instance.CurrentUIState(eUIState.Pause);
                    Time.timeScale = 0f;
                }
                // 메뉴를 닫을 때
                else
                {
                    // 추후에 stack으로 ui관리 구현해보기.
                    pauseMenuUI.SetActive(false);
                    optionUI.SetActive(false);
                    inventoryUI.SetActive(false);
                    GameManager.Instance.CurrentUIState(eUIState.None);
                    Time.timeScale = 1f;
                }
            }
        }
    }

    private void ClearUIOpen()
    {
        if (GameManager.Instance.GameState == eGameState.Dead || GameManager.Instance.GameState == eGameState.Clear)
        {
            clearUI.SetActive(true);

            switch (GameManager.Instance.GameState)
            {
                case eGameState.Clear:
                    clearText.text = "Congratulations!";
                    break;
                case eGameState.Dead:
                    clearText.text = "Dead";
                    break;
            }
            Time.timeScale = 0f;
        }
    }
}

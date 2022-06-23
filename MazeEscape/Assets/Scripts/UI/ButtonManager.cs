using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : UI_Base
{
    //Game Start ���� ���� ��ư
    public void OnStartButton()
    {
        SceneManager.LoadScene("Stage_1");
        Time.timeScale = 1f;
        GameManager.Instance.CurrentGameState(eGameState.Play);
    }

    //Option �ɼ� ��ư
    public void OnOptionButton()
    {
        optionUI.SetActive(true);
        GameManager.Instance.CurrentUIState(eUIState.Option);

        //switch (GameManager.Instance.GameState)
        //{
        //    case eGameState.Lobby:
        //        lobbyMainUI.SetActive(false);
        //        break;
        //    case eGameState.Play:
        //        pauseMenuUI.SetActive(false);
        //        break;
        //}
    }

    // Close �ݱ� ��ư
    public void OnCloseButton()
    {
        switch (GameManager.Instance.UIState)
        {
            case eUIState.Inventory:
                inventoryUI.SetActive(false);
                GameManager.Instance.CurrentUIState(eUIState.None);
                break;
            case eUIState.Option:
                optionUI.SetActive(false);
                GameManager.Instance.CurrentUIState(eUIState.Pause);
                break;
            case eUIState.Pause:
                pauseMenuUI.SetActive(false);
                GameManager.Instance.CurrentUIState(eUIState.None);
                Time.timeScale = 1f;
                break;
        }
    }

    //Exit Lobby �κ�� ������ ��ư
    public void OnExitLobbyButton()
    {
        GameManager.Instance.CurrentUIState(eUIState.None);
        GameManager.Instance.CurrentGameState(eGameState.Lobby);
        SceneManager.LoadScene("Lobby");
        Time.timeScale = 1f;
    }

    //Exit ���� ���� ��ư
    public void OnExitButton()
    {
        Application.Quit();
    }
}

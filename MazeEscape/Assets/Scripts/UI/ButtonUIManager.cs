using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonUIManager : MonoBehaviour
{
    public GameObject lobbyMainUI;
    public GameObject pauseMenuUI;
    public GameObject optionUI;
    public GameObject helpUI;
    public GameObject clearUI;

    public Text clearText;

    // Start is called before the first frame update
    void Start()
    {
        //pauseMenuUI.SetActive(false);
        optionUI.SetActive(false);
        helpUI.SetActive(false);
        //clearUI.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.GameState == eGameState.Play)
        {
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
            {
                MenuOpen();
            }
        }
        else if (GameManager.Instance.GameState == eGameState.Dead || GameManager.Instance.GameState == eGameState.Clear)
        {
            ClearUIOpen();
        }
    }

    private void MenuOpen()
    {
        //메뉴를 오픈할 때
        if (GameManager.Instance.UIState == eUIState.None)
        {
            pauseMenuUI.SetActive(true);
            GameManager.Instance.CurrentUIState(eUIState.Pause);
            Time.timeScale = 0f;
        }
        //메뉴를 닫을 때
        else if (GameManager.Instance.UIState != eUIState.None)
        {
            pauseMenuUI.SetActive(false);
            optionUI.SetActive(false);
            helpUI.SetActive(false);
            GameManager.Instance.CurrentUIState(eUIState.None);
            Time.timeScale = 1f;
        }
    }

    private void ClearUIOpen()
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

    //Game Start 게임 시작 버튼
    public void OnStartButton()
    {
        SceneManager.LoadScene("Stage_1");
        Time.timeScale = 1f;
    }

    //Resume 게임으로 돌아가기 버튼
    public void OnResumeButton()
    {
        MenuOpen();
    }

    //Option 옵션 버튼
    public void OnOptionButton()
    {
        optionUI.SetActive(true);
        GameManager.Instance.CurrentUIState(eUIState.Option);

        switch (GameManager.Instance.GameState)
        {
            case eGameState.Lobby:
                lobbyMainUI.SetActive(false);
                break;
            case eGameState.Play:
                pauseMenuUI.SetActive(false);
                break;
        }
    }

    //Help 도움말 버튼
    public void OnHelpButton()
    {
        helpUI.SetActive(true);
        GameManager.Instance.CurrentUIState(eUIState.Help);

        switch (GameManager.Instance.GameState)
        {
            case eGameState.Lobby:
                lobbyMainUI.SetActive(false);
                break;
            case eGameState.Play:
                pauseMenuUI.SetActive(false);
                break;
        }
    }

    //Back 뒤로가기 버튼
    public void OnBackButton()
    {
        optionUI.SetActive(false);
        helpUI.SetActive(false);

        switch (GameManager.Instance.GameState)
        {
            case eGameState.Lobby:
                lobbyMainUI.SetActive(true);
                GameManager.Instance.CurrentUIState(eUIState.None);
                break;
            case eGameState.Play:
                pauseMenuUI.SetActive(true);
                GameManager.Instance.CurrentUIState(eUIState.Pause);
                break;
        }
    }

    //Exit Lobby 로비로 나가기 버튼
    public void OnExitLobbyButton()
    {
        GameManager.Instance.CurrentUIState(eUIState.None);
        GameManager.Instance.CurrentGameState(eGameState.Lobby);
        SceneManager.LoadScene("Lobby");
        Time.timeScale = 1f;
    }

    //Exit 게임 종료 버튼
    public void OnExitButton()
    {
        Application.Quit();
    }
}

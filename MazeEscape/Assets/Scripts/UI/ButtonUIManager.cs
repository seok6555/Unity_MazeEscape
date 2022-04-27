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
        //�޴��� ������ ��
        if (GameManager.Instance.UIState == eUIState.None)
        {
            pauseMenuUI.SetActive(true);
            GameManager.Instance.CurrentUIState(eUIState.Pause);
            Time.timeScale = 0f;
        }
        //�޴��� ���� ��
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

    //Game Start ���� ���� ��ư
    public void OnStartButton()
    {
        SceneManager.LoadScene("Stage_1");
        Time.timeScale = 1f;
    }

    //Resume �������� ���ư��� ��ư
    public void OnResumeButton()
    {
        MenuOpen();
    }

    //Option �ɼ� ��ư
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

    //Help ���� ��ư
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

    //Back �ڷΰ��� ��ư
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

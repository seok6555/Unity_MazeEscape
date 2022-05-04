using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    private DataManager _data = new DataManager();

    public eGameState GameState { get; private set; } = eGameState.Lobby;
    public eUIState UIState { get; private set; } = eUIState.None;
    public DataManager Data { get { return instance._data; } }

    // ��ü ������ ���� ����.
    #region singleton
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Screen.SetResolution(1920, 1080, true);
            SceneManager.sceneLoaded += OnSceneLoaded;
            instance.Data.Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion singleton

    // public ������Ƽ�� ����, �ܺο��� private ��������� ���ٸ� �����ϵ��� ����.
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        switch (arg0.name)
        {
            case "Lobby":
                GameState = eGameState.Lobby;
                break;
            case "Stage_1":
                GameState = eGameState.Play;
                break;
        }
    }

    // ���� Game�� ���� enum�� ����.
    public void CurrentGameState(eGameState state)
    {
        GameState = state;
    }

    // ���� UI�� ���� enum�� ����.
    public void CurrentUIState(eUIState state)
    {
        UIState = state;
    }

    // Resources ������ path �̸��� ���� ���׸� Ÿ���� ���� ������ �ҷ����� ����.
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    // path �̸��� ���� GameObject Ÿ���� �������� �Ҵ�.
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        return Object.Instantiate(prefab, parent);
    }
}

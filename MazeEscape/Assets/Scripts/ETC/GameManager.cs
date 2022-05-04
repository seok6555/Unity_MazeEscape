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

    // 객체 생성시 최초 실행.
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

    // public 프로퍼티로 선언, 외부에서 private 멤버변수에 접근만 가능하도록 구현.
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

    // 현재 Game의 상태 enum을 변경.
    public void CurrentGameState(eGameState state)
    {
        GameState = state;
    }

    // 현재 UI의 상태 enum을 변경.
    public void CurrentUIState(eUIState state)
    {
        UIState = state;
    }

    // Resources 폴더에 path 이름을 가진 제네릭 타입의 에셋 파일을 불러오고 리턴.
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    // path 이름을 가진 GameObject 타입의 프리팹을 할당.
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

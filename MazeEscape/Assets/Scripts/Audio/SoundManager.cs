using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;

    public AudioSource bgmSource;
    public AudioMixer mixer;
    public AudioClip[] bgmList;

    #region singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion singleton

    public static SoundManager Instance
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

    //씬 로딩시 실행 함수.
    //씬의 이름과 같은 이름을 가진 배경음 클립을 실행.
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for (int i = 0; i < bgmList.Length; i++)
        {
            if (arg0.name == bgmList[i].name)
            {
                BGMPlay(bgmList[i]);
            }
        }
    }

    //배경음 재생 함수 (재생 클립)
    public void BGMPlay(AudioClip clip)
    {
        bgmSource.outputAudioMixerGroup = mixer.FindMatchingGroups("BGMSound")[0];
        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.volume = 1f;
        bgmSource.Play();
    }

    //배경음 볼륨 조절 함수 (볼륨의 값)
    public void BGMSoundVolume(float value)
    {
        mixer.SetFloat("BGMSoundVolume", Mathf.Log10(value) * 20);
    }

    //효과음 재생 함수 (효과음 이름, 재생 클립)
    //오디오 소스를 가지고 있는 오브젝트를 생성 후, 해당 오브젝트에서 사운드를 출력하고 파괴하는 방식.
    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);
    }

    //효과음 볼륨 조절 함수 (볼륨의 값)
    public void SFXVolume(float value)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
    }
}

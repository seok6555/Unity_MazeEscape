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

    //�� �ε��� ���� �Լ�.
    //���� �̸��� ���� �̸��� ���� ����� Ŭ���� ����.
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

    //����� ��� �Լ� (��� Ŭ��)
    public void BGMPlay(AudioClip clip)
    {
        bgmSource.outputAudioMixerGroup = mixer.FindMatchingGroups("BGMSound")[0];
        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.volume = 1f;
        bgmSource.Play();
    }

    //����� ���� ���� �Լ� (������ ��)
    public void BGMSoundVolume(float value)
    {
        mixer.SetFloat("BGMSoundVolume", Mathf.Log10(value) * 20);
    }

    //ȿ���� ��� �Լ� (ȿ���� �̸�, ��� Ŭ��)
    //����� �ҽ��� ������ �ִ� ������Ʈ�� ���� ��, �ش� ������Ʈ���� ���带 ����ϰ� �ı��ϴ� ���.
    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);
    }

    //ȿ���� ���� ���� �Լ� (������ ��)
    public void SFXVolume(float value)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
    }
}

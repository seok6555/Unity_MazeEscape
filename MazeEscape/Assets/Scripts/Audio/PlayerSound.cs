using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] footStepClip;
    public AudioSource playerAudioSource;

    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }

    //�߼Ҹ� ��� �Լ�.
    public void FootStepSound()
    {
        playerAudioSource.outputAudioMixerGroup = SoundManager.Instance.mixer.FindMatchingGroups("SFX")[0];
        AudioClip clip = GetRandomClip();
        playerAudioSource.PlayOneShot(clip);
    }

    //������ �߼Ҹ� Ŭ�� ��ȯ �Լ�.
    private AudioClip GetRandomClip()
    {
        return footStepClip[Random.Range(0, footStepClip.Length - 1)];
    }
}

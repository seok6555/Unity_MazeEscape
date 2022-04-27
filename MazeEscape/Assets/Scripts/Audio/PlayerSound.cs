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

    //발소리 출력 함수.
    public void FootStepSound()
    {
        playerAudioSource.outputAudioMixerGroup = SoundManager.Instance.mixer.FindMatchingGroups("SFX")[0];
        AudioClip clip = GetRandomClip();
        playerAudioSource.PlayOneShot(clip);
    }

    //랜덤한 발소리 클립 반환 함수.
    private AudioClip GetRandomClip()
    {
        return footStepClip[Random.Range(0, footStepClip.Length - 1)];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    [SerializeField]
    private Slider BGMSlider;
    [SerializeField]
    private Slider SFXSlider;
    [SerializeField]
    private Slider mouseSlider;
    [SerializeField]
    private Text sensitivityText;

    // Start is called before the first frame update
    void Start()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("BGMSoundVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        mouseSlider.value = PlayerPrefs.GetFloat("MouseSensitivity");
        sensitivityText.text = mouseSlider.value.ToString("N2");
    }

    //싱글톤으로는 씬 전환시 이벤트 연결이 끊겨버림.
    //그래서 따로 OptionCotroller 스크립트를 만들어서 각 슬라이더 조절을 관리하도록 함.
    //슬라이더 이벤트에 연결. SoundManger의 볼륨 조절 함수 사용.
    //슬라이더 변경 볼륨값을 매개변수로 전달.
    public void BGMSoundVolume(float value)
    {
        SoundManager.Instance.BGMSoundVolume(value);
        PlayerPrefs.SetFloat("BGMSoundVolume", value);
    }

    public void SFXVolume(float value)
    {
        SoundManager.Instance.SFXVolume(value);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void MouseSensitivity(float value)
    {
        sensitivityText.text = mouseSlider.value.ToString("N2");
        PlayerPrefs.SetFloat("MouseSensitivity", value);
    }
}

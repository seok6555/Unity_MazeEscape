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

    //�̱������δ� �� ��ȯ�� �̺�Ʈ ������ ���ܹ���.
    //�׷��� ���� OptionCotroller ��ũ��Ʈ�� ���� �� �����̴� ������ �����ϵ��� ��.
    //�����̴� �̺�Ʈ�� ����. SoundManger�� ���� ���� �Լ� ���.
    //�����̴� ���� �������� �Ű������� ����.
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

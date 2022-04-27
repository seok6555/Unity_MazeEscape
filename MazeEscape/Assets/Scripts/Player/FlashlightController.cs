using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightController : MonoBehaviour
{
    [SerializeField]
    private GameObject lightObject;
    [SerializeField]
    private Image batteryGauge;
    private Flashlight _flashlight;

    private bool isFlashOn = true; // �������� �¿��� ����

    // Start is called before the first frame update
    void Start()
    {
        _flashlight = GetComponent<Flashlight>();
    }

    // Update is called once per frame
    void Update()
    {
        TryFlashlight();
        BatteryGauge();
    }

    // ������ On/Off�� �õ��ϴ� �Լ�
    private void TryFlashlight()
    {
        // ���͸� �ܿ��� üũ. ���� ��
        if (_flashlight.Battery >= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q) && GameManager.Instance.GameState == eGameState.Play && GameManager.Instance.UIState == eUIState.None)
            {
                // �������� ���� ���¸� �ѱ�.
                if (!isFlashOn)
                {
                    FlashlightOn();
                }
                else
                {
                    FlashlightOff();
                }
            }
        }
        // ���͸� �ܿ����� ���� ��
        else
        {
            _flashlight.Battery = 0;
            FlashlightOff();
        }
    }

    // �������� �Ѵ� �Լ� (Off -> On)
    private void FlashlightOn()
    {
        isFlashOn = true;
        lightObject.SetActive(true);
    }

    // �������� ���� �Լ� (On -> Off)
    private void FlashlightOff()
    {
        isFlashOn = false;
        lightObject.SetActive(false);
    }

    // ���͸� �������� ��Ÿ���� �Լ�
    private void BatteryGauge()
    {
        if (isFlashOn)
        {
            _flashlight.Battery -= Time.deltaTime;
        }
        batteryGauge.fillAmount = _flashlight.Battery / _flashlight.MaxBattery;
    }

    // ���͸� ���� �Լ�
    public void ChargeBattery(float recharging)
    {
        _flashlight.Battery += recharging;
        if (_flashlight.Battery > _flashlight.MaxBattery)
        {
            _flashlight.Battery = _flashlight.MaxBattery;
        }
    }
}

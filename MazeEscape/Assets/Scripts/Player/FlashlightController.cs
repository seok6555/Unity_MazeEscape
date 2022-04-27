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

    private bool isFlashOn = true; // 손전등의 온오프 상태

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

    // 손전등 On/Off를 시도하는 함수
    private void TryFlashlight()
    {
        // 배터리 잔여량 체크. 있을 때
        if (_flashlight.Battery >= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q) && GameManager.Instance.GameState == eGameState.Play && GameManager.Instance.UIState == eUIState.None)
            {
                // 손전등이 꺼진 상태면 켜기.
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
        // 배터리 잔여량이 없을 때
        else
        {
            _flashlight.Battery = 0;
            FlashlightOff();
        }
    }

    // 손전등을 켜는 함수 (Off -> On)
    private void FlashlightOn()
    {
        isFlashOn = true;
        lightObject.SetActive(true);
    }

    // 손전등을 끄는 함수 (On -> Off)
    private void FlashlightOff()
    {
        isFlashOn = false;
        lightObject.SetActive(false);
    }

    // 배터리 게이지를 나타내는 함수
    private void BatteryGauge()
    {
        if (isFlashOn)
        {
            _flashlight.Battery -= Time.deltaTime;
        }
        batteryGauge.fillAmount = _flashlight.Battery / _flashlight.MaxBattery;
    }

    // 배터리 충전 함수
    public void ChargeBattery(float recharging)
    {
        _flashlight.Battery += recharging;
        if (_flashlight.Battery > _flashlight.MaxBattery)
        {
            _flashlight.Battery = _flashlight.MaxBattery;
        }
    }
}

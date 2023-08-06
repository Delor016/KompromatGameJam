using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
    public Light m_Light;
    public bool isOn;
    public GameObject image;
    public GameObject image1;
    public GameObject PC_On;
    public GameObject PC_Off;

    // Время, через которое свет выключится автоматически (в минутах)
    public float autoTurnOffTime = 1.5f;
    private bool isAutoTurnOffRunning = false;

    void Start()
    {
        m_Light.enabled = isOn;
        image1.SetActive(false);
    }

    public string GetDescription()
    {
        image.SetActive(true);
        image1.SetActive(false);
        if (isOn)
        {
            PC_On.SetActive(true);
            PC_Off.SetActive(false);
            return "";
        }
        else
        {
            PC_On.SetActive(false);
            PC_Off.SetActive(true);
            return "";
        }
    }

    public void Interact()
    {
        isOn = !isOn;
        m_Light.enabled = isOn;

        // Если свет включен, запустить автоматическое выключение
        if (isOn)
        {
            if (!isAutoTurnOffRunning)
            {
                StartCoroutine(AutoTurnOffCoroutine());
            }
        }
        else
        {
            // Если свет выключен, остановить автоматическое выключение
            if (isAutoTurnOffRunning)
            {
                StopCoroutine(AutoTurnOffCoroutine());
                isAutoTurnOffRunning = false;
            }
        }
    }

    // Корутина для автоматического выключения света через определенное время
    private IEnumerator AutoTurnOffCoroutine()
    {
        isAutoTurnOffRunning = true;
        yield return new WaitForSeconds(autoTurnOffTime * 60f); // Переводим минуты в секунды
        isOn = false;
        m_Light.enabled = false;
        PC_On.SetActive(false);
        PC_Off.SetActive(true);
        isAutoTurnOffRunning = false;
    }
}

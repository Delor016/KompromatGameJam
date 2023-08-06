using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInteraction : MonoBehaviour
{
    public GameObject phone; // Ссылка на GameObject с телефоном
    public GameObject imageObject; // Ссылка на GameObject с Image, который нужно включить
    public GameObject podskazka; // Ссылка на GameObject с Image, который нужно включить

    private bool canUsePhone = false;
    private PlayerController playerController; // Ссылка на скрипт PlayerController

    private void Start()
    {
        // Находим и сохраняем ссылку на скрипт PlayerController, прикрепленный к персонажу
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        // Проверяем, активен ли GameObject с телефоном
        if (phone.activeSelf)
        {
            canUsePhone = true;
        }
        else
        {
            canUsePhone = false;
        }

        // Если телефон активен и нажата клавиша "T", включаем Image и отключаем скрипт PlayerController
        if (canUsePhone && Input.GetKeyDown(KeyCode.T))
        {
            imageObject.SetActive(true);
            phone.SetActive(false);
            playerController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            podskazka.SetActive(false);
        }
    }
}

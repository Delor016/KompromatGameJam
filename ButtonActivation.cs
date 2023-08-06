using TMPro;
using UnityEngine;

public class ButtonActivation : MonoBehaviour
{
    public GameObject objectToActivate; // Ссылка на GameObject, который будет активирован при нажатии на кнопку
    public GameObject Inventary;
    public GameObject Player;
    public GameObject TextTwo;
    public GameObject Image;
    private void Start()
    {
        // Выключаем GameObject при запуске сцены (если он изначально включен)
        objectToActivate.SetActive(false);
    }

    public void ActivateObject()
    {
        // Вызывается при нажатии на кнопку, активирует GameObject
        objectToActivate.SetActive(true);
        Inventary.SetActive(false);
        Image.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; // Заблокировать движение курсора
        Cursor.visible = false; // Скрыть курсор
        Player.GetComponent<PlayerController>().enabled = true; // Включить движение персонажа
        TextTwo.SetActive(true);
    }
}

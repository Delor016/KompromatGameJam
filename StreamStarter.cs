using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StreamStarter : MonoBehaviour
{
    public GameObject Inventar;
    public GameObject Playr;
    public TMP_InputField streamNameInput; // Поле ввода названия стрима (TMP Input Field)
    public Button startStreamButton; // Кнопка запуска стрима
    public GameObject objectToDisable; // GameObject, который нужно выключить
    public Canvas canvasToEnable; // Canvas, который нужно включить

    public GameObject DoorOn;
    public GameObject DoorOff;

    private void Start()
    {
        // Назначаем обработчик события на изменение текста в поле ввода
        streamNameInput.onValueChanged.AddListener(OnStreamNameChanged);
        // Изначально делаем кнопку запуска неинтерактивной
        startStreamButton.interactable = false;
        // Назначаем обработчик события на нажатие кнопки запуска
        startStreamButton.onClick.AddListener(OnStartStreamButtonClicked);
        Inventar.GetComponent<Inventory>().enabled = false;
        Playr.GetComponent<PhoneInteraction>().enabled = false;
    }

    // Вызывается при изменении текста в поле ввода
    public void OnStreamNameChanged(string streamName)
    {
        // Проверяем, если поле ввода не пустое, делаем кнопку запуска интерактивной
        startStreamButton.interactable = !string.IsNullOrEmpty(streamName);
    }

    // Вызывается при нажатии на кнопку запуска стрима
    public void OnStartStreamButtonClicked()
    {
        // Здесь вы можете добавить логику для запуска стрима с указанным названием
        string streamName = streamNameInput.text;
        // Например, можно использовать Debug.Log для вывода названия стрима в консоль
        Debug.Log("Запуск стрима с названием: " + streamName);

        // Выключаем GameObject
        objectToDisable.SetActive(false);

        // Включаем Canvas
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canvasToEnable.gameObject.SetActive(true);
        Playr.GetComponent<PlayerController>().enabled = true;
        DoorOn.SetActive(true);
        DoorOff.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Canvas canvas;
    public GameObject player;
    public GameObject podskazka;


    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.enabled = !canvas.enabled;
            podskazka.SetActive(false);
            // Управление курсором и движением персонажа
            if (canvas.enabled)
            {
                Cursor.lockState = CursorLockMode.None; // Разрешить движение курсора
                Cursor.visible = true; // Показать курсор
                player.GetComponent<PlayerController>().enabled = false; // Отключить движение персонажа
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked; // Заблокировать движение курсора
                Cursor.visible = false; // Скрыть курсор
                player.GetComponent<PlayerController>().enabled = true; // Включить движение персонажа
            }
        }
    }
}

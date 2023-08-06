using UnityEngine;

public class win : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, что соприкоснулся объект с тегом "Player"
        {
            objectToActivate.SetActive(true); // Включаем GameObject при соприкосновении с триггером
            Cursor.lockState = CursorLockMode.None; // Разрешить движение курсора
            Cursor.visible = true; // Показать курсор
            player.GetComponent<PlayerController>().enabled = false; // Отключить движение персонажа
        }
    }
}

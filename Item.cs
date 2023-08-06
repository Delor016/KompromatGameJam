using TMPro;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public int index = 0;
    public bool isPlayerNearby = false; // Изменили на public
    public TextMeshProUGUI interactionText;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text1;
    public static int collectedItems = 0; // Изменили на public static
    public GameObject DoorCan;
    public GameObject DoorNoCan;


    public void Start()
    {
        interactionText.text = ""; // Очищаем текст при запуске сцены
    }

    public string GetDescription()
    {
        // Определяем текст, который будет отображаться при наведении на предмет
        return "";
    }

    public void Interact()
    {
        // Когда игрок взаимодействует с предметом (нажимает E), добавляем его в инвентарь и удаляем сцены
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Destroy(gameObject);
            DoorCan.SetActive(true);
            DoorNoCan.SetActive(false);
            text.text = "1/1";
            collectedItems++;
            if (collectedItems >= 1)
            {
                text1.text = "мне нужен хайп. Пойду собирать компроматы.";
            }
        }
    }

    /*void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactionText.text = GetDescription(); // При приближении игрока показываем текст
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionText.text = ""; // Когда игрок покидает область триггера, очищаем текст
        }
    }*/
}

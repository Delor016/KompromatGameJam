using UnityEngine;
using UnityEngine.SceneManagement;

public class Door1 : MonoBehaviour, IInteractable
{
    public string sceneToLoad; // Имя сцены для перехода

    public string GetDescription()
    {
        if (IsOpen()) return "Press [E] to <color=red>close</color> the door";
        return "Press [E] to <color=green>open</color> the door";
    }

    public void Interact()
    {
        if (IsOpen())
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    private bool IsOpen()
    {
        // Здесь вы можете добавить логику для определения, открыта ли дверь
        // Например, можно использовать переменную bool, чтобы хранить состояние двери
        return false; // Замените на свою логику проверки состояния двери
    }

    private void OpenDoor()
    {
        // Здесь вы можете добавить логику для открытия двери
        // Например, воспроизвести звук открытия двери или включить анимацию открытия
        // Однако, поскольку вы не хотите использовать аниматор, просто перейдите на другую сцену
        if (sceneToLoad != "")
        {
            // Загружаем указанную сцену
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void CloseDoor()
    {
        // Здесь вы можете добавить логику для закрытия двери
        // Например, воспроизвести звук закрытия двери или включить анимацию закрытия
        // В данном случае, если вы не хотите использовать аниматор, этот метод может быть пустым
    }
}

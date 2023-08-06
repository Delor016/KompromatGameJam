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
        return false;
    }

    private void OpenDoor()
    {
        if (sceneToLoad != "")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void CloseDoor()
    {
        //Потом
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithNote : MonoBehaviour, IInteractable
{
    public GameObject Zapiska;
    public bool isOn;
    public GameObject image;
    public ViewerControllerScript viewerController; // Ссылка на скрипт ViewerControllerScript
    public NoteCounterScript noteCounter; // Ссылка на скрипт NoteCounterScript

    void Start()
    {
        image.SetActive(true);
    }

    public string GetDescription()
    {
        image.SetActive(true);
        return "";
    }

    public void Interact()
    {
        Destroy(Zapiska);
        viewerController.AddViewers(100); // Увеличение числа зрителей на 100 при поднятии записки
        noteCounter.CollectNote(); // Увеличение количества поднятых записок
    }
}

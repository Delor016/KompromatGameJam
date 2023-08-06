using UnityEngine;

public class ViewerTrigger : MonoBehaviour
{
    public ViewerControllerScript viewerController;

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что соприкоснулся именно персонаж (можно использовать теги или слои)
        if (other.CompareTag("Player"))
        {
            // Активируем увеличение зрителей
            viewerController.ActivateViewersIncrease();
        }
    }
}

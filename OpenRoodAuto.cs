using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRoodAuto : MonoBehaviour
{
    public GameObject objectToEnable;
    public GameObject objectToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToEnable.SetActive(true);
            objectToDisable.SetActive(false);
        }
    }
}

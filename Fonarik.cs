using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fonarik : MonoBehaviour
{
    public Light FL;
    public GameObject podskazka;

    // Update is called once per frame
    void Start()
    {
        FL.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            podskazka.SetActive(false);
            if (FL.enabled ==false)
            {
                FL.enabled = true;
            }
            else
            {
                FL.enabled = false;
            }

        }
    }
}

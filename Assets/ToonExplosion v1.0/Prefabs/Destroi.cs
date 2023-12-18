using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroi : MonoBehaviour
{
    public float tempo;
    float temp;

    // Update is called once per frame
    void Update()
    {
        temp += Time.deltaTime;
        if (temp > tempo)
        {
            Destroy(gameObject);
        }

    }
}

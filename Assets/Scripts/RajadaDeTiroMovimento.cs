using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RajadaDeTiroMovimento : MonoBehaviour
{
    public float velocidade = 5.0f;  // Velocidade de movimento para a esquerda

    // Update is called once per frame
    void Update()
    {
        // Mova o objeto pai para a esquerda
        transform.Translate(Vector3.left * velocidade * Time.deltaTime);
    }
}

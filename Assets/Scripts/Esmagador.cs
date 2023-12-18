using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Esmagador : MonoBehaviour
{

    [SerializeField]
    public float velocidade;
    private bool colidiu = false, Pare;

    // Update is called once per frame
    void Update()
    {
        if (!Pare)
        {
            if (!colidiu)
            {
                float deslocamentoVertical = velocidade * Time.deltaTime;
                transform.Translate(Vector3.down * deslocamentoVertical);
            }
            else
            {
                float deslocamentoVertical = velocidade * Time.deltaTime;
                transform.Translate(Vector3.up * deslocamentoVertical);
            }
        }


        
    }

    private void Parar() {
        colidiu = true;
        Pare = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Jogador" e se o objeto ainda n�o come�ou a cair
        if (collision.gameObject.CompareTag("Chao"))
        {
            Pare= true; 
            Invoke("Parar", 2f);


        }

        if (collision.gameObject.CompareTag("Limite"))
        {
            colidiu = false;

        }
    }
}

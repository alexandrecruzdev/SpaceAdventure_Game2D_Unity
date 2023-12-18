using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetocaindo : MonoBehaviour
{

    public float delayAntesDeCair = 2.0f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Jogador" e se o objeto ainda n�o come�ou a cair
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("IniciarQueda", delayAntesDeCair);
            
        }

    }

    private void IniciarQueda()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }


}

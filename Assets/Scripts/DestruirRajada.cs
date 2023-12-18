using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirRajada : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 30f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Verifica se o objeto que colidiu tem a tag "Jogador" e se o objeto ainda n�o come�ou a cair
        if (collision.transform.name == "DeletarPassaroGelo")
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Jogador" e se o objeto ainda n�o come�ou a cair
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}

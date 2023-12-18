using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    [SerializeField]
    GameObject[] Coracao;
    public int contador_vida = 0;
    bool empurrar;
    float tempo;

    private void Start()
    {
        //contador_vida = PlayerPrefs.GetInt("Vida", 0);
        Coracao[0].SetActive(false);
        Coracao[contador_vida].SetActive(true);
    }

    public void OnDestroy()
    {
        //PlayerPrefs.SetInt("Vida", contador_vida);
    }

    private void Update()
    {
        if (empurrar)
        {
            if (!GetComponent<Player>().LadoDireito)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.1f, 0), ForceMode2D.Impulse);
            else
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.1f, 0), ForceMode2D.Impulse);
            tempo += Time.deltaTime;
            if (tempo >= 0.4)
            {
                empurrar= false;
                tempo= 0;
            }

        }


        if (contador_vida >= 3)
            SceneManager.LoadScene(0);

    }

    public void PerderVida()
    {
        if (contador_vida<3)
        {
            Coracao[contador_vida].SetActive(false);
            contador_vida++;
            Coracao[contador_vida].SetActive(true);
        }
    }

    public void AumentarVida()
    {
        if (contador_vida>0)
        {
            Coracao[contador_vida].SetActive(false);
            contador_vida--;
            Coracao[contador_vida].SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            PerderVida();
            empurrar = true;
            
        }
           
    }
}

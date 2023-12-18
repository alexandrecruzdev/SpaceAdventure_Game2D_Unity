using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RajadaGelo : MonoBehaviour
{
    public GameObject tiroPrefab;  // Prefab do pedaço de gelo
    public int numeroDeTiro = 10;  // Número de pedaços de gelo
    public float velocidade = 5.0f;  // Velocidade de movimento para a esquerda
    public bool ativar = true;
    public float posicaoInicial = 40;
    public float delay = 10f;
    public float altura = -2.90f;
    // Start is called before the first frame update
    void Start()
    {
        CriaRajadaTiro();
    }

    // Update is called once per frame
    void Update()
    {

        if (ativar)
        {
            Invoke("CriaRajadaTiro", delay);
            ativar = false;
        }
    }

    void CriaRajadaTiro()
    {
        for (int i = 0; i < numeroDeTiro; i++)
        {
            float posicaoTiro = posicaoInicial + (i * 1);
            Vector3 posicao = new Vector3(posicaoTiro, altura, 0);
            GameObject tiro = Instantiate(tiroPrefab, posicao, tiroPrefab.transform.rotation);

        }


        ativar = true;
    }
}

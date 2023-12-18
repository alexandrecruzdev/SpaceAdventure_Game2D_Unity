using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    [SerializeField]
    public float velocidade;
    public float distancia; 

    private Vector3 posicaoInicial;
    public int direcao = 1; // Come�a indo para cima

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Calcula o deslocamento vertical com base na dire��o
        float deslocamentoVertical = direcao * velocidade * Time.deltaTime;

        // Move o objeto na dire��o do deslocamento
        transform.Translate(Vector3.up * deslocamentoVertical);

        // Verifica se o objeto atingiu o limite superior ou inferior
        if (transform.position.y >= posicaoInicial.y + distancia)
        {
            direcao = -1; // Mudar a dire��o para descer
        }
        else if (transform.position.y <= posicaoInicial.y - distancia)
        {
            direcao = 1; // Mudar a dire��o para subir
        }
    }
}

using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    [SerializeField]
    public float velocidade;
    public float distancia; 

    private Vector3 posicaoInicial;
    public int direcao = 1; // Começa indo para cima

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Calcula o deslocamento vertical com base na direção
        float deslocamentoVertical = direcao * velocidade * Time.deltaTime;

        // Move o objeto na direção do deslocamento
        transform.Translate(Vector3.up * deslocamentoVertical);

        // Verifica se o objeto atingiu o limite superior ou inferior
        if (transform.position.y >= posicaoInicial.y + distancia)
        {
            direcao = -1; // Mudar a direção para descer
        }
        else if (transform.position.y <= posicaoInicial.y - distancia)
        {
            direcao = 1; // Mudar a direção para subir
        }
    }
}

using UnityEngine;

public class MovimentoPlataforma : MonoBehaviour
{
    public float velocidade = 2.0f; // Velocidade de movimento da plataforma
    public float amplitude = 5.0f; // Amplitude do movimento (distância da esquerda para a direita)

    private float tempoInicial;
    private Transform jogadorTransform; // Referência ao transform do jogador

    void Start()
    {
        tempoInicial = Time.time;

        // Obtém a referência ao transform do jogador (assumindo que o jogador é um GameObject separado)
        jogadorTransform = GameObject.FindGameObjectWithTag("Jogador").transform;

        // Torna o jogador um filho da plataforma
        jogadorTransform.parent = transform;
    }

    void Update()
    {
        // Calcula a posição da plataforma com base no tempo
        float tempoPassado = Time.time - tempoInicial;
        float deslocamentoHorizontal = Mathf.Sin(tempoPassado * velocidade) * amplitude;

        // Define a nova posição da plataforma
        Vector3 novaPosicao = new Vector3(deslocamentoHorizontal, transform.position.y, transform.position.z);
        transform.position = novaPosicao;
    }

    // Certifique-se de remover o jogador como filho da plataforma quando o script for desativado ou destruído
    void OnDestroy()
    {
        if (jogadorTransform != null)
        {
            jogadorTransform.parent = null;
        }
    }
}

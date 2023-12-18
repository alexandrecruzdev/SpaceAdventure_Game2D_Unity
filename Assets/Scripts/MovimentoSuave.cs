using UnityEngine;

public class MovimentoPlataforma : MonoBehaviour
{
    public float velocidade = 2.0f; // Velocidade de movimento da plataforma
    public float amplitude = 5.0f; // Amplitude do movimento (dist�ncia da esquerda para a direita)

    private float tempoInicial;
    private Transform jogadorTransform; // Refer�ncia ao transform do jogador

    void Start()
    {
        tempoInicial = Time.time;

        // Obt�m a refer�ncia ao transform do jogador (assumindo que o jogador � um GameObject separado)
        jogadorTransform = GameObject.FindGameObjectWithTag("Jogador").transform;

        // Torna o jogador um filho da plataforma
        jogadorTransform.parent = transform;
    }

    void Update()
    {
        // Calcula a posi��o da plataforma com base no tempo
        float tempoPassado = Time.time - tempoInicial;
        float deslocamentoHorizontal = Mathf.Sin(tempoPassado * velocidade) * amplitude;

        // Define a nova posi��o da plataforma
        Vector3 novaPosicao = new Vector3(deslocamentoHorizontal, transform.position.y, transform.position.z);
        transform.position = novaPosicao;
    }

    // Certifique-se de remover o jogador como filho da plataforma quando o script for desativado ou destru�do
    void OnDestroy()
    {
        if (jogadorTransform != null)
        {
            jogadorTransform.parent = null;
        }
    }
}

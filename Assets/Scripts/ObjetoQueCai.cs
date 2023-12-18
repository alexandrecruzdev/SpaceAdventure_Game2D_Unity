using UnityEngine;

public class ObjetoQueCai : MonoBehaviour
{
    private bool caindo = false; // Vari�vel para rastrear se o objeto come�ou a cair

    [SerializeField]
    public float velocidade;
    public float distancia;
    public float delayAntesDeCair = 2.0f; // Atraso em segundos antes de come�ar a cair

    private Vector3 posicaoInicial;
    public int direcao = 1; // Come�a indo para cima

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Verifica se o objeto est� caindo
        if (caindo)
        {
            // Move o objeto na dire��o do deslocamento
            float deslocamentoVertical = direcao * velocidade * Time.deltaTime;
            transform.Translate(Vector3.up * deslocamentoVertical);
        }
    }

    // Este m�todo � chamado quando um objeto colide com este objeto em 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Jogador" e se o objeto ainda n�o come�ou a cair
        if (collision.gameObject.CompareTag("Jogador") && !caindo)
        {
            // Escreve "colidiu" no console
            Debug.Log("Colidiu");

            // Agende o in�cio da queda ap�s um atraso
            Invoke("IniciarQueda", delayAntesDeCair);
        }
    }

    // Este m�todo � chamado ap�s o atraso definido para iniciar a queda
    private void IniciarQueda()
    {
        caindo = true; // Marca o objeto como come�ando a cair
    }
}

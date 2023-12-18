using UnityEngine;

public class EsticarObjetoY : MonoBehaviour
{
    public float esticarVelocidade = 1.0f;
    public float tamanhoMaximo = 2.0f; // Tamanho máximo no eixo Y
    public float tamanhoMinimo = 0.5f; // Tamanho mínimo no eixo Y

    private bool esticando = true;

    // Update is called once per frame
    void Update()
    {
        // Obtenha a escala atual do objeto
        Vector3 escalaAtual = transform.localScale;

        // Determine a direção com base no estado atual
        float direcao = esticando ? 1 : -1;

        // Aumente ou diminua a escala no eixo Y
        escalaAtual.y += direcao * esticarVelocidade * Time.deltaTime;

        // Limitar o tamanho no eixo Y entre tamanhoMinimo e tamanhoMaximo
        escalaAtual.y = Mathf.Clamp(escalaAtual.y, tamanhoMinimo, tamanhoMaximo);

        // Atribua a nova escala ao objeto
        transform.localScale = escalaAtual;

        // Inverta o estado se o tamanho máximo ou mínimo for atingido
        if (escalaAtual.y >= tamanhoMaximo || escalaAtual.y <= tamanhoMinimo)
        {
            esticando = !esticando;
        }
    }
}

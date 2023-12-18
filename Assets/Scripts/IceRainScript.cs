
using UnityEngine;

public class IceRainScript : MonoBehaviour
{
    public GameObject icePrefab;  // Prefab do pedaço de gelo
    public int numberOfIcePieces = 10;  // Número de pedaços de gelo
    public float rainDuration = 10.0f;

    void Start()
    {
        // Chame a função CreateIceRain para iniciar a chuva de gelo
        CreateIceRain();
    }

    void Update()
    {
        // Se necessário, adicione lógica de atualização aqui
    }

    void CreateIceRain()
    {
        // Instancie os pedaços de gelo
        GameObject iceRainParent = new GameObject("IceRainParent");

        for (int i = 0; i < numberOfIcePieces; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(22f, 24f), Random.Range(-12f, -11f), Random.Range(-10f, 10f));
            GameObject icePiece = Instantiate(icePrefab, randomPosition, icePrefab.transform.rotation);
            icePiece.transform.parent = iceRainParent.transform;  // Torne o pedaço de gelo filho do objeto pai
        }

        for (int i = 0; i < numberOfIcePieces; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(28f, 30f), Random.Range(-12f, -11f), Random.Range(-10f, 10f));
            GameObject icePiece = Instantiate(icePrefab, randomPosition,icePrefab.transform.rotation);
            icePiece.transform.parent = iceRainParent.transform;  // Torne o pedaço de gelo filho do objeto pai
        }

        for (int i = 0; i < numberOfIcePieces; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(32f, 34f), Random.Range(-12f, -11f), Random.Range(-10f, 10f));
            GameObject icePiece = Instantiate(icePrefab, randomPosition, icePrefab.transform.rotation);
            icePiece.transform.parent = iceRainParent.transform;  // Torne o pedaço de gelo filho do objeto pai
        }

        for (int i = 0; i < numberOfIcePieces; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(16f, 18f), Random.Range(-12f, -11f), Random.Range(-10f, 10f));
            GameObject icePiece = Instantiate(icePrefab, randomPosition, icePrefab.transform.rotation);
            icePiece.transform.parent = iceRainParent.transform;  // Torne o pedaço de gelo filho do objeto pai
        }


        for (int i = 0; i < numberOfIcePieces; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(22f, 24f), Random.Range(-12f, -11f), Random.Range(-10f, 10f));
            GameObject icePiece = Instantiate(icePrefab, randomPosition, icePrefab.transform.rotation);
            icePiece.transform.parent = iceRainParent.transform;  // Torne o pedaço de gelo filho do objeto pai
        }

        for (int i = 0; i < numberOfIcePieces; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(28f, 30f), Random.Range(-12f, -11f), Random.Range(-10f, 10f));
            GameObject icePiece = Instantiate(icePrefab, randomPosition, icePrefab.transform.rotation);
            icePiece.transform.parent = iceRainParent.transform;  // Torne o pedaço de gelo filho do objeto pai
        }






        // Agende a destruição da chuva de gelo após a duração especificada
        Invoke("DestroyIceRain", rainDuration);
    }

    void DestroyIceRain()
    {
        // Destrua o objeto pai, que contém todos os pedaços de gelo
        Destroy(GameObject.Find("IceRainParent"));

        // Chame a função CreateIceRain novamente para iniciar a próxima chuva de gelo
        CreateIceRain();
    }
}


using UnityEngine;

public class IceRainScript : MonoBehaviour
{
    public GameObject icePrefab;  // Prefab do peda�o de gelo
    public int numberOfIcePieces = 10;  // N�mero de peda�os de gelo
    public float rainDuration = 10.0f;

    void Start()
    {
        // Chame a fun��o CreateIceRain para iniciar a chuva de gelo
        CreateIceRain();
    }

    void Update()
    {
        // Se necess�rio, adicione l�gica de atualiza��o aqui
    }

    void CreateIceRain()
    {
        // Instancie os peda�os de gelo
        GameObject iceRainParent = new GameObject("IceRainParent");

        for (int i = 0; i < numberOfIcePieces; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(22f, 24f), Random.Range(-12f, -11f), Random.Range(-10f, 10f));
            GameObject icePiece = Instantiate(icePrefab, randomPosition, icePrefab.transform.rotation);
            icePiece.transform.parent = iceRainParent.transform;  // Torne o peda�o de gelo filho do objeto pai
        }

        for (int i = 0; i < numberOfIcePieces; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(28f, 30f), Random.Range(-12f, -11f), Random.Range(-10f, 10f));
            GameObject icePiece = Instantiate(icePrefab, randomPosition,icePrefab.transform.rotation);
            icePiece.transform.parent = iceRainParent.transform;  // Torne o peda�o de gelo filho do objeto pai
        }

        for (int i = 0; i < numberOfIcePieces; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(32f, 34f), Random.Range(-12f, -11f), Random.Range(-10f, 10f));
            GameObject icePiece = Instantiate(icePrefab, randomPosition, icePrefab.transform.rotation);
            icePiece.transform.parent = iceRainParent.transform;  // Torne o peda�o de gelo filho do objeto pai
        }

        for (int i = 0; i < numberOfIcePieces; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(16f, 18f), Random.Range(-12f, -11f), Random.Range(-10f, 10f));
            GameObject icePiece = Instantiate(icePrefab, randomPosition, icePrefab.transform.rotation);
            icePiece.transform.parent = iceRainParent.transform;  // Torne o peda�o de gelo filho do objeto pai
        }


        for (int i = 0; i < numberOfIcePieces; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(22f, 24f), Random.Range(-12f, -11f), Random.Range(-10f, 10f));
            GameObject icePiece = Instantiate(icePrefab, randomPosition, icePrefab.transform.rotation);
            icePiece.transform.parent = iceRainParent.transform;  // Torne o peda�o de gelo filho do objeto pai
        }

        for (int i = 0; i < numberOfIcePieces; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(28f, 30f), Random.Range(-12f, -11f), Random.Range(-10f, 10f));
            GameObject icePiece = Instantiate(icePrefab, randomPosition, icePrefab.transform.rotation);
            icePiece.transform.parent = iceRainParent.transform;  // Torne o peda�o de gelo filho do objeto pai
        }






        // Agende a destrui��o da chuva de gelo ap�s a dura��o especificada
        Invoke("DestroyIceRain", rainDuration);
    }

    void DestroyIceRain()
    {
        // Destrua o objeto pai, que cont�m todos os peda�os de gelo
        Destroy(GameObject.Find("IceRainParent"));

        // Chame a fun��o CreateIceRain novamente para iniciar a pr�xima chuva de gelo
        CreateIceRain();
    }
}

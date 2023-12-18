using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public GameObject Player;
    Vector3 personagem;
    float distancia;
    private void Start()
    {
        distancia =  gameObject.transform.position.x - Player.transform.position.x;
    }


    void Update()
    {
        personagem = new Vector3(Player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        personagem.x += distancia;
        gameObject.transform.position= personagem;
    }
}
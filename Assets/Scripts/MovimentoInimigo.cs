using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    public float DistanciaMin, DistanciaMax;
    float pos_x;
    public float vel;
    bool andar = false;
    bool LadoDireito;

    private void Start()
    {
        pos_x = gameObject.transform.localPosition.x;
        Virar();
    }

    // Update is called once per frame
    void Update()
    {
        if (andar)
        {
            pos_x += vel;
            gameObject.transform.localPosition = new Vector2(pos_x, gameObject.transform.localPosition.y);
            if (pos_x >= DistanciaMax)
            {
                andar = false;
                Virar();
            }
        }
        else
        {
            pos_x -= vel;
            gameObject.transform.localPosition = new Vector2(pos_x, gameObject.transform.localPosition.y);
            if (pos_x <= DistanciaMin)
            {
                andar = true;
                Virar();
            }
        }
    }


    private void Virar()
    {
        LadoDireito = !LadoDireito;
        Vector3 pos = transform.localScale;
        pos.x *= -1;
        transform.localScale = pos;
    }
}

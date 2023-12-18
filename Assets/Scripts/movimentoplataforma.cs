using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoplataforma : MonoBehaviour
{
    public float AlturaMin, AlturaMax;
    float pos_y;
    public float vel;
    bool subir = false;

    private void Start()
    {
        pos_y = gameObject.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (subir)
        {
            pos_y += vel;
            gameObject.transform.localPosition = new Vector2(gameObject.transform.localPosition.x, pos_y);
            if (pos_y >= AlturaMax)
                subir = false;
        }
        else {
            pos_y -= vel;
            gameObject.transform.localPosition = new Vector2(gameObject.transform.localPosition.x, pos_y);
            if (pos_y <= AlturaMin)
                subir = true;
        }
    }
}

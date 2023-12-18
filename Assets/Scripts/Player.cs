using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody2D p;
    public float vel;
    public bool LadoDireito;
    // Start is called before the first frame update
    private bool Pulo; // Nova variável para controlar o estado de pulo.
    bool andar;
    int x;
    public bool Teclado;
    bool Ataca;
    bool Chave = false;
    public int numfase;


    public float jumpForce = 10.0f; // Ajuste isso conforme necessário para controlar a força do pulo.

    float tempo = 0;

    public GameObject AnimExplodir, IconeChave;
    void Start()
    {
        anim = GetComponent<Animator>();
        p = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Teclado)
        {
            vel = Input.GetAxisRaw("Horizontal") * 40;
        }
        else
        {
            if (andar)
            {
                vel = x * 40;
            }
            else
                vel = 0;
        }
        //vel = Input.GetAxisRaw("Horizontal") * 40;
        //p.AddForce(new Vector2(vel * 0.3f,0f));

        if (!Pulo)
            p.velocity = new Vector2(vel * 0.03f, p.velocity.y);


        if (vel < 0 && !LadoDireito)
            Virar();
        else if (vel > 0 && LadoDireito)
            Virar();
        if (vel < 0)
            vel *= -1;
        anim.SetFloat("Velocidade", vel);

        if (Teclado)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !Pulo)
                Jump();
            if (Input.GetKeyDown(KeyCode.G) && !Ataca)
                Ataque();


        }

        if (Ataca)
        {
            tempo += Time.deltaTime;
            if (tempo > 0.4)
            {
                tempo = 0;
                Ataca  =  false;
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

    public void AndarE(bool a)
    {
        andar = a;
        x = -1;
    }

    public void AndarD(bool a)
    {
        andar = a;
        x = 1;
    }
    public void Pular()
    {
        if (!Pulo)
            Jump();
    }

    public void Atacar()
    {
        if (!Ataca)
            Atacar();
    }

    private void Jump()
    {
        // Aplicar uma força vertical para fazer o personagem pular.
        p.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        //p.velocity = new Vector2(vel * 0.03f, jumpForce);

        // Defina a variável de salto no Animator para acionar a animação de pulo.
        anim.SetTrigger("Pular");

        Pulo = true;
    }

    public void Ataque()
    {

        // Defina a variável do ataque no Animator para acionar a animação.
        anim.SetTrigger("Ataque");

        Ataca = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Reiniciar")
        {
            GetComponent<vida>().PerderVida();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.CompareTag("PegarChave"))
        {
            Destroy(collision.gameObject);
            IconeChave.SetActive(true);
            Chave = true;
        }


        if (collision.gameObject.CompareTag("Portal"))
        {
            if (Chave) 
            {
                SceneManager.LoadScene(numfase);

            }
            
        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Ataca)
        {
            if (collision.gameObject.CompareTag("Inimigo"))
            {
                Instantiate(AnimExplodir, collision.transform.position, collision.transform.rotation);
                Destroy(collision.gameObject);
            }
        }
        
    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (Pulo)
        {
            if (col.gameObject.CompareTag("Chao"))
            {
                Pulo = false;
            }
        }

        if (col.gameObject.CompareTag ("Reiniciar"))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }


}

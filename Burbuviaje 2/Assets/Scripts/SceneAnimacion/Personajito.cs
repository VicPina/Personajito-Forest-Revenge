using UnityEngine;

public class Personajito : MonoBehaviour
{
    private Rigidbody2D rg2d;
    private Animator animacion;

    public float speed = 1.0f;
    public float speed2 = 1.0f;
    public float maxAltura = 1.0f;

    private float posY = 0.0f;
    private float posX = 1.2f;

    private float velocidadFondo1 = 0.5f;
    private float velocidadFondo2 = 1.0f;
    private float velocidadFondo3 = 1.2f;
    private float velocidadFondo4 = 1.0f;
    private float velocidadFondo5 = 1.0f;
   // private float velocidadFondo6 = 0.0f;


    public GameObject fondo1;
    public GameObject fondo2;
    public GameObject fondo3;
    public GameObject fondo4;
    public GameObject fondo5;
    //public GameObject fondo6;



    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
        posY = rg2d.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.position.y > posY + maxAltura)
        {
            speed2 *= -1;
        }

        if (transform.position.y < posY - maxAltura)
        {
            speed2 *= -1;
        }

        
        transform.position += Vector3.up * speed2 * Time.deltaTime;

        if (transform.position.x < posX )
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            //Empizo a mover el fondo
            moverFondo();
        }
    }


    private void moverFondo()
    {
        //Cambio de animacion cuando pase la nube
        if (fondo4.transform.position.x < 1.1 && !animacion.GetBool("Cambio"))
        {
            animacion.SetBool("Cambio", true);
            Debug.Log("Cambio a el animator a CAMBIO");
        }
        if (fondo5.transform.position.x > 0)
        {
            fondo1.transform.position += Vector3.left * velocidadFondo1 * Time.deltaTime;
            fondo2.transform.position += Vector3.left * velocidadFondo2 * Time.deltaTime;
            fondo3.transform.position += Vector3.left * velocidadFondo3 * Time.deltaTime;
            fondo4.transform.position += Vector3.left * velocidadFondo4 * Time.deltaTime;
            fondo5.transform.position += Vector3.left * velocidadFondo5 * Time.deltaTime;

            //  fondo6.transform.position += Vector3.left * velocidadFondo6 * Time.deltaTime;
            //Debug.Log(fondo5.transform.position.x);
        }
        else
        {
            animacion.SetBool("Cambio", false);
            animacion.SetBool("Cayendo", true);
            rg2d.gravityScale = 2f;
            //Debug.Log("Cambio el animator a CAYENDO");



        }

    }
}

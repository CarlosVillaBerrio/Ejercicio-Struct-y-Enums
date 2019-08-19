using UnityEngine;

public class MyHero : MonoBehaviour
{
    //public GameObject cuboHeroe;
    //GameObject heroe;
    //public GameObject camaraHeroe;
    //GameObject camara;
    //Vector3 posHero;
    //Vector3 camPos;

    public GameStruct datosHeroe;
    GameStruct datosAldeano;
    GameStruct datosZombie;
    bool contactoZombi;
    bool contactoAldeano;

    public void Awake()
    {
        // VELOCIDAD DEL HEROE
        datosHeroe.velHeroe = Random.Range(0.8f, 2.5f);
    }

    void Update()
    {
        if (contactoAldeano)
        {
            Debug.Log(MensajeAldeano(datosAldeano));

            contactoAldeano = false;
        }

        if (contactoZombi)
        {
            Debug.Log(MensajeZombi(datosZombie));
            contactoZombi = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Aldeano")
        {
            contactoAldeano = true;
            datosAldeano = collision.gameObject.GetComponent<MyVillager>().datosAldeano;
        }

        if (collision.transform.name == "Zombie")
        {
            contactoZombi = true;
            datosZombie = collision.gameObject.GetComponent<MyZombie>().datosZombie; // Esto va en el colision de cada zombie o aldeano
        }
    }

    public string MensajeZombi(GameStruct datosZombie)
    {
        string mensajeZombi = "Waaaarrrr quiero comer " + datosZombie.gustoZombi;
        return mensajeZombi;
    }

    public string MensajeAldeano(GameStruct datosAldeano)
    {
        string mensajeAldeano = "Hola soy " + datosAldeano.nombreAldeano + " y tengo " + datosAldeano.edadAldeano + " años";
        return mensajeAldeano;
    }
}
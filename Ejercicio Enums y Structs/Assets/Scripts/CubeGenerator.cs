using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    int nEnemy, nAlly;
    public int limiteGenerado = 20;
    // HEROE VARIABLES Y FUNCION GENERADORA
    public GameObject cuboHeroe;
    GameObject heroe;
    public GameObject camaraHeroe;
    GameObject camara;
    Vector3 posHero;
    Vector3 camPos;
    public void CreacionHeroe()
    {
        // CREACION DEL HEROE
        posHero = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
        heroe = GameObject.Instantiate(cuboHeroe, posHero, Quaternion.identity);
        heroe.name = "Heroe";
        heroe.AddComponent<MyHero>();
        heroe.AddComponent<HeroMove>();


        // CREACION DE LA CAMARA QUE SIGUE AL HEROE
        camPos = new Vector3(heroe.transform.position.x, heroe.transform.position.y + 0.8f, heroe.transform.position.z);
        camara = Instantiate(camaraHeroe, camPos, Quaternion.identity);
        camara.AddComponent<HeroCam>();
        camara.name = "Camara Heroe";
    }
    // ZOMBIE VARIABLES Y FUNCION GENERADORA
    int colorZombie;
    public GameObject zombie;
    public void CreacionZombie()
    {
        zombie = GameObject.CreatePrimitive(PrimitiveType.Cube);
        zombie.name = "Zombie";
        zombie.AddComponent<MyZombie>();
        Vector3 posZombi = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
        zombie.transform.position = posZombi;

        switch (zombie.GetComponent<MyZombie>().datosZombie.colorZombi)
        {
            case 0:
                zombie.GetComponent<Renderer>().material.color = Color.cyan;
                break;
            case 1:
                zombie.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 2:
                zombie.GetComponent<Renderer>().material.color = Color.magenta;
                break;
        }
        zombie.AddComponent<Rigidbody>();
        zombie.GetComponent<Rigidbody>().freezeRotation = true;
    }
    // ALDEANO VARIABLES Y FUNCION GENERADORA
    public GameObject aldeano;
    public void CreacionAldeano()
    {
        aldeano = GameObject.CreatePrimitive(PrimitiveType.Cube); // CREA LA FIGURA SOLICITADA
        Vector3 posAldeano = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f)); // ELIGE UNA POSICION ALEATORIA
        aldeano.transform.position = posAldeano; // ASIGNA LA POSICION A UNA VARIABLE
        aldeano.GetComponent<Renderer>().material.color = Color.black; // ASIGNACION DE UN COLOR AL ALDEANO
        aldeano.GetComponent<Transform>().localScale = new Vector3(1.0f, 3.0f, 1.0f); // ASIGNA UN COLOR PARA IDENTIFICAR A LOS ALDEANOS
        aldeano.AddComponent<Rigidbody>().freezeRotation = true; // AÑADE CUERPO SOLIDO AL ZOMBIE Y CONGELA LA ROTACION 
        aldeano.name = "Aldeano"; // NOMBRE DEL ALDEANO EN LA JERARQUIA
        aldeano.AddComponent<MyVillager>();
    }

    void Start()
    {
        nEnemy = Random.Range(10, limiteGenerado);
        nAlly = limiteGenerado - nEnemy;
        nAlly = Random.Range(0, nAlly);



        // CREACION DE LOS ZOMBIS
        for (int i = 0; i < nEnemy; i++) // CICLO QUE CREA UN ZOMBIE POR CADA ITERACION
        {
            CreacionZombie();
        }

        // CREACION DE LOS ALDEANOS
        for (int i = 0; i < nAlly; i++) // CICLO QUE CREA UN ALDEANO POR CADA ITERACION
        {
            CreacionAldeano();
        }

        // CREACION DEL HEROE
        CreacionHeroe();
    }

    void Update()
    {
        // SEGUIMIENTO DE LA CAMARA EN PRIMERA PERSONA
        camPos = new Vector3(heroe.transform.position.x, heroe.transform.position.y + 0.8f, heroe.transform.position.z);
        camara.GetComponent<HeroCam>().transform.position = camPos;
    }
}
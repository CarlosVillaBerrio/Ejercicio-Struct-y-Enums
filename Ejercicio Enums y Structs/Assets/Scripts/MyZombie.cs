using UnityEngine;
using System.Collections;
public class MyZombie : MonoBehaviour
{
    public GameStruct datosZombie;
    public bool seMueve;
    public void Awake()
    {
        datosZombie.gustoZombi = (GameStruct.gustosZombi)Random.Range(0, 5);
        datosZombie.colorZombi = Random.Range(0, 3);
    }
    void Start()
    {
        StartCoroutine(ComportamientoZombie(datosZombie));
    }
    IEnumerator ComportamientoZombie(GameStruct gameStruct)
    {
        while (true)
        {
            gameStruct.estadoZombi = (GameStruct.estadosZombi)Random.Range(0, 2);
            switch (gameStruct.estadoZombi)
            {
                case GameStruct.estadosZombi.Idle:
                    seMueve = false;
                    break;
                case GameStruct.estadosZombi.Moving:
                    seMueve = true;
                    break;
            }
            yield return new WaitForSeconds(5.0f);
        }
    }

    void Update()
    {
        if(seMueve) // moving
        {
            transform.position += transform.forward * 0.7f * Time.deltaTime;
        }
        else // idle
        {
            transform.eulerAngles += new Vector3 (0, Random.Range(10f, 150f) * Time.deltaTime, 0);
        }
    }
}

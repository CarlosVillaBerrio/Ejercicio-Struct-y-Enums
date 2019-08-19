using UnityEngine;

public class MyVillager : MonoBehaviour
{
    public GameStruct datosAldeano;
    void Awake()
    {
        datosAldeano.nombreAldeano = (GameStruct.nombresAldeano)Random.Range(0, 21); // SELECTOR DE NOMBRES
        datosAldeano.edadAldeano = Random.Range(15, 101); // SELECTOR DE EDAD
    }
}
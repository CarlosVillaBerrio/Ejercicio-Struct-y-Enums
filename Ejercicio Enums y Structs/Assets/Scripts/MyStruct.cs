// GLOBAL STRUCT
public struct GameStruct
{
    // Datos del Heroe
    public float velHeroe;
    // Datos del zombi
    public int colorZombi;
    public enum gustosZombi { cerebro, corazon, higado, nariz, lengua };
    public gustosZombi gustoZombi;
    public enum estadosZombi { Idle, Moving };
    public estadosZombi estadoZombi;
    // Datos del aldeano
    public enum nombresAldeano
    {
        Alex, Bernardo, Carlos, David, Fernando, Gustavo, Jose, Maria, Jesus, Pedro,
        Camilo, Alberto, Leon, John, Camila, Layla, Emily, Claire, Marta, Sofia
    };
    public nombresAldeano nombreAldeano;
    public int edadAldeano;
}
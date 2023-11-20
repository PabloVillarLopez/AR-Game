using Unity.VisualScripting;
using UnityEngine.UIElements;

[System.Serializable]
public class SaveData
{
    //Este script es nuestro contenedor de datos, son los datos que vamos a guardar cuando lo deseemos
    //Variables genericas del juego 
    public static int generalPoints;

    //Contructor desde donde llamaremos para pasar los datos que se guarden
    public SaveData(dartSpawner dartSpawner, moleSpawner moleSpawner)
    {
        generalPoints = dartSpawner.points + moleSpawner.points;
    }
}

using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoadMethods
{
    //Metodo para guardar los datos
    public static void SaveAllData(dartSpawner dartSpawner, moleSpawner moleSpawner)
    {
        //Instancias de los contructores de SaveData para recoger los datos a guardar
        SaveData saveData = new SaveData(dartSpawner, moleSpawner);

        //Ruta guardado
        string dataPath = Application.persistentDataPath + "/savedata.save";

        //Definicion de la operacion de guardado con FileStream (manejo de archivos)
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        //Serializador binario (conversion de datos en binario para guardar)
        BinaryFormatter binaryFormatter = new BinaryFormatter(); //Se crea variable tipo
        binaryFormatter.Serialize(fileStream, saveData); //Se convierten los datos en binario
        fileStream.Close(); //Se cierra el archivo
    }

    //Metodo para cargar los datos
    public static SaveData LoadAllData()
    {
        //Ruta de carga
        string dataPath = Application.persistentDataPath + "/savedata.save";

        //Comprobacion de exixtencia de archivo
        if (File.Exists(dataPath))
        {
            //Definicion de la operacion de carga con FileStream (manejo de archivos)
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            //Serializador binario (conversion de datos en binario para cargar)
            BinaryFormatter binaryFormatter = new BinaryFormatter(); //Se crea variable tipo
            SaveData saveData = (SaveData)binaryFormatter.Deserialize(fileStream); //Se convierten los datos de binario a json y se guarda en una variable del dipo del script de datso
            fileStream.Close(); //Se cierra el archivo
            return saveData;
        }
        else
        {
            Debug.LogError("No se guardó ningun archivo de SaveData");
            return null;
        }
    }
}

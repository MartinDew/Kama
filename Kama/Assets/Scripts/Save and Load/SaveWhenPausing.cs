using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveWhenPausing
{
    public static string path = Application.persistentDataPath + "/temp.txt";
    public static bool LoadOnUnpause;
    public static void TempSave(PlayerComponent player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        TempData data = new TempData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static TempData TempLoad()
    {

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TempData data = formatter.Deserialize(stream) as TempData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}

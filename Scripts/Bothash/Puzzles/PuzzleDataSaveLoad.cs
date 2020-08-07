using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public class PuzzleDataSaveLoad : MonoBehaviour
{

    public static PuzzleDataSaveLoad instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            instance = this;
        }
    }

    public void Save(PuzzleSaveSO theSO, string filename)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/PuzzlesData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/PuzzlesData");
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + string.Format("/PuzzlesData/{0}",filename));
        var json = JsonUtility.ToJson(theSO);
        bf.Serialize(file, json);
        file.Close();
    }

    public PuzzleSaveSO Load(PuzzleSaveSO theSO ,string filename)
    {
        Debug.Log("load");
        BinaryFormatter b = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + string.Format("/PuzzlesData/{0}",filename)))
        {
            FileStream fileLoad = File.Open(Application.persistentDataPath + string.Format("/PuzzlesData/{0}", filename), FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)b.Deserialize(fileLoad), theSO);
            fileLoad.Close();
            return theSO;
        }

        return null;
        
    }
}

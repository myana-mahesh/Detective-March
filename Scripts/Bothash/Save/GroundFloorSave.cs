using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GroundFloorSave : MonoBehaviour
{
    public GameObject[] objects;
    public ObjectSavingSo objectSaving;
    public AnimatingObjectsClass[] AnimatingObjectList;




    public static GroundFloorSave Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if (File.Exists(Application.persistentDataPath + "/GameData/game_Data.botHash"))
        {
            LoadGameData();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Start()
    {
        
        /*  if(File.Exists(Application.persistentDataPath + "/GameData/game_Data.botHash")){
                 LoadGameData();
             } */
    }

    void LoadGameData()
    {
        Debug.Log("load");
        BinaryFormatter b = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/GameData/game_Data.botHash"))
        {
            FileStream fileLoad = File.Open(Application.persistentDataPath + "/GameData/game_Data.botHash", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)b.Deserialize(fileLoad), objectSaving);
            fileLoad.Close();
        }
        WriteGameData();
    }


    public void Save()
    {
        objectSaving.GameData.Clear();
        objectSaving.AnimatingObjectsIndexes.Clear();
        objectSaving.AnimatingObjectsData.Clear();

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].activeSelf)
            {
                objectSaving.GameData.Add(i);
            }
        }

        for (int i = 0; i < AnimatingObjectList.Length; i++)
        {

            objectSaving.AnimatingObjectsIndexes.Add(i);
            AnimatorObjects tempobj = new AnimatorObjects();
            tempobj.playOnlyOnce = AnimatingObjectList[i].playOnlyOnce;
            tempobj.positionHold = AnimatingObjectList[i].positionHold;
            tempobj.PositonToHold = AnimatingObjectList[i].PositonToHold;
            objectSaving.AnimatingObjectsData.Add(tempobj);


        }


        Debug.Log("svae");
        if (!fileExist())
        {
            //LoadManager.Instance.LoadAlbum();
            Directory.CreateDirectory(Application.persistentDataPath + "/GameData");
        }
        /* if(!Directory.Exists(Application.persistentDataPath + "/AlbumData/album_data")){
            Directory.CreateDirectory(Application.persistentDataPath + "/AlbumData/album_data");
        } */
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/GameData/game_Data.botHash");
        var json = JsonUtility.ToJson(objectSaving);
        bf.Serialize(file, json);

        file.Close();
    }

    public bool fileExist()
    {
        return Directory.Exists(Application.persistentDataPath + "/GameData");
    }

    void WriteGameData()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objectSaving.GameData.Contains(i))
            {
                objects[i].SetActive(true);
            }
            else
            {
                objects[i].SetActive(false);
            }
        }


        for (int i = 0; i < AnimatingObjectList.Length; i++)
        {
            if (objectSaving.AnimatingObjectsIndexes.Contains(i))
            {
                if (objectSaving.AnimatingObjectsData[i].playOnlyOnce)
                {
                    AnimatingObjectList[i].AnimatingObject.enabled = false;
                }
                if (objectSaving.AnimatingObjectsData[i].positionHold)
                {
                    AnimatingObjectList[i].AnimatingObject.gameObject.transform.localPosition = new Vector3(objectSaving.AnimatingObjectsData[i].PositonToHold.x, objectSaving.AnimatingObjectsData[i].PositonToHold.y, objectSaving.AnimatingObjectsData[i].PositonToHold.z);
                }
            }
            else
            {
                objects[i].SetActive(false);
            }
        }


    }
}
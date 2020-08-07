using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace bothash
{
    public class AlbumManager : MonoBehaviour{
    // Start is called before the first frame update
        public GameObject[] images;
        public AlbumSO albumSO;
        
        public static AlbumManager Instance { get; private set; }

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
            if(File.Exists(Application.persistentDataPath + "/AlbumData/album_data.album")){
                Load();
            }
        }

        public bool fileExist(){
            return Directory.Exists(Application.persistentDataPath + "/AlbumData");
        }
     
        private void Start() {

            
            
        }
        void Load(){
            Debug.Log("load");
            BinaryFormatter b=new BinaryFormatter();
            if(File.Exists(Application.persistentDataPath + "/AlbumData/album_data.album")){
                FileStream fileLoad=File.Open(Application.persistentDataPath + "/AlbumData/album_data.album",FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)b.Deserialize(fileLoad),albumSO);
                fileLoad.Close();
            }
            WriteAlbum();
        }

        public void Save(){
            albumSO.indexesOfActive.Clear();
            for(int i=0;i<images.Length;i++){
                if(images[i].activeSelf){
                    albumSO.indexesOfActive.Add(i);
                }
            }
            if(!fileExist()){
                //LoadManager.Instance.LoadAlbum();
                Directory.CreateDirectory(Application.persistentDataPath + "/AlbumData");
            }   
            /* if(!Directory.Exists(Application.persistentDataPath + "/AlbumData/album_data")){
                Directory.CreateDirectory(Application.persistentDataPath + "/AlbumData/album_data");
            } */  
            BinaryFormatter bf=new BinaryFormatter();
            FileStream file=File.Create(Application.persistentDataPath + "/AlbumData/album_data.album");
            var json =JsonUtility.ToJson(albumSO);
            bf.Serialize(file,json);

            file.Close();
        }

        void WriteAlbum(){
            for(int i=0;i<albumSO.indexesOfActive.Count;i++){
                images[albumSO.indexesOfActive[i]].SetActive(true);
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class _RoomManager : MonoBehaviour
{

    public string roomSaveKey = "roomDB1";
    public string currentRoom;
    public List<GameObject> AllRooms;
    //public ClickControlHog1 cch;

    // Use this for initialization
    void Start()
    {

    }

    /// <summary>
    ///  button event 
    /// </summary>
    public void ChangeRoom(int roomIndex)
    {
        //		int rnd = Random.Range(0, AllRooms.Count);
        for (int i = 0; i < AllRooms.Count; i++)
        {
            AllRooms[i].SetActive(value: false);
        }
        AllRooms[roomIndex].SetActive(value: true);
        currentRoom = AllRooms[roomIndex].name;
        PlayerPrefs.SetString(roomSaveKey, currentRoom);
    }

    private void OnEnable()
    {
        /*if (!PlayerPrefs.HasKey(roomSaveKey)) {
			//currentRoom = AllRooms[0].name;
            PlayerPrefs.SetString(roomSaveKey, AllRooms[0].name);
        }*/
        /*  else {
              currentRoom = PlayerPrefs.GetString(roomSaveKey);
          }*/

        if (!PlayerPrefs.HasKey(roomSaveKey))
        {
            //currentRoom = AllRooms[0].name;
            PlayerPrefs.SetString(roomSaveKey, AllRooms[0].name);
        }
        currentRoom = PlayerPrefs.GetString(roomSaveKey);

        foreach (GameObject level in AllRooms)
        {
            if (level.name.Equals(currentRoom))
            {
                level.SetActive(true);
            }
            else
            {
                level.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        //PlayerPrefs.SetString(roomSaveKey, currentRoom);
        //HintManager.isHogObject = false;
        //HintManager.findPickableObjects = false;
    }

    public void SetupRoomOnRestart()
    {
//        _InventoryDB.instance.ResetDB();
        //cch.RestartTest();
        //PlayerPrefs.SetString(roomSaveKey, AllRooms[0].name);
        currentRoom = AllRooms[0].name;

        foreach (GameObject level in AllRooms)
        {
            if (level.name.Equals(currentRoom))
            {
                level.SetActive(true);
            }
            else
            {
                level.SetActive(false);
            }
        }

        //Invoke("LoadScene", 1f);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // PlayerPrefs.SetInt("ComingFromRestart", 1);
    }
    public void SetupRoomOnLevelComplete()
    {
//        _InventoryDB.instance.ResetDB();
        //PlayerPrefs.SetString(roomSaveKey, AllRooms[0].name);
        // currentRoom = PlayerPrefs.GetString(roomSaveKey);

        //StartCoroutine(LoadAsynchronously());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // PlayerPrefs.SetInt("ComingFromRestart", 1);
    }

    IEnumerator LoadAsynchronously()
    {
//        Destroy(_InventoryDB.instance.gameObject);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        while (!operation.isDone)
        {

            yield return null;
        }
        // PlayerPrefs.SetString(roomSaveKey, AllRooms[0].name);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        ChangeRoom(roomIndex: 15);
    //    }
    //}
}

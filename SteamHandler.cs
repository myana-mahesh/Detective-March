using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;
public class SteamHandler : MonoBehaviour
{
    public static SteamHandler instance;

    public GameObject AchGO;
    public float holdSec = 1f;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
            instance = this;
        }
        //DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update

    

    void Start()
    {
        if (SteamManager.Initialized)
        {
            Debug.LogFormat("@@@ Steam User Name: {0}", SteamFriends.GetPersonaName());
            
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SetAch(string API)
    {
        
        if (!SteamManager.Initialized)
        {
            Debug.Log("@@@@@ STEAM NOT INITIALIZED @@@@@");
            Debug.Log("@@@@@ STEAM NOT INITIALIZED @@@@@");
            return false;
        }
        //SteamUserStats.GetAchievement(API, out status);
        if (!PlayerPrefs.HasKey("STEAM_ACH"+API))
        {

            SteamUserStats.SetAchievement(API);
            notify(API);
            SteamUserStats.StoreStats();
            PlayerPrefs.SetInt("STEAM_ACH" + API, 1);
            bothash.AlbumManager.Instance.albumSO.ACHNAMES.Add("STEAM_ACH" + API);
            Debug.LogFormat("@@@@ ACH SET FOR {0} @@@@", API);
            return true;
        }
        else
        {
            Debug.LogFormat("@@@@ ACH ALREADY SET FOR {0} @@@@", API);
            return false;
        }

    }

    private void notify(string API)
    {
        AchGO.GetComponentInChildren<Text>().text = API;
        AchGO.SetActive(true);
        StartCoroutine(pauseforsec());

    }

    IEnumerator pauseforsec()
    {
        yield return new WaitForSeconds(holdSec);
        AchGO.SetActive(false);
    }

    
}

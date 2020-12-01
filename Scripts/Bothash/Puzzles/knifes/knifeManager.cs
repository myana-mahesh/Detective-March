using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeManager : MonoBehaviour
{   
    public GameObject Prize;
    public GameObject knifes;
    private GameObject first;
    private GameObject second;
    private bool firstPassed;
    private int count=0;
    public static knifeManager Instance { get; private set; }

    public GameObject R_Ruby;
    public GameObject L_Ruby;
    public GameObject Knives;

    public GameObject litcandle;
    public GameObject UnLitcandle;

    public GameObject Parent_Holder;

    public PuzzleSaveSO SavingSo;
    private string fileName = "Candle.puzzle";

    public GameObject Glow;
    void Awake () {
        if (Instance == null) {
            Instance = this;
                //DontDestroyOnLoad (gameObject);
        } else {
            Destroy (gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (LoadData())
        {
            foreach (var item in SavingSo.IndicesOfActiveSpriteRenderer)
            {
                if (item == 0)
                {
                    UnLitcandle.GetComponent<SpriteRenderer>().enabled = true;
                    litcandle.SetActive(true);
                }
                else if (item == 1)
                {
                    litcandle.GetComponent<SpriteRenderer>().enabled = true;
                    Glow.SetActive(true);
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (UnLitcandle.GetComponent<SpriteRenderer>().enabled)
            litcandle.SetActive(true);
        if (litcandle.GetComponent<SpriteRenderer>().enabled)
        {
            Glow.SetActive(true);
            Parent_Holder.SetActive(true);
            
        }
        if (R_Ruby.activeSelf && L_Ruby.activeSelf && !FileBasedPrefs.HasKey("knifeDisplayed"))
        {   FileBasedPrefs.SetInt("knifeDisplayed",1);
            Knives.SetActive(true);
        }

    }

    void OnDisable()
    {
        SavePuzzleData();
    }
    public void passSecondData (GameObject objToPass) {
        if (!firstPassed) {
            first = objToPass;
            firstPassed = true;
            //first.GetComponent<SpriteRenderer>().enabled = true;
            //first.SetActive(false);
            SoundManager.Instance.gameSounds[6].Play();
        } else if(first.GetComponent<SpriteRenderer>().sprite.name!=objToPass.GetComponent<SpriteRenderer>().sprite.name){
            second = objToPass;
            firstPassed = false;
            //second.GetComponent<SpriteRenderer>().enabled = true;
            SoundManager.Instance.gameSounds[6].Play();
            check ();
        }

    }
    public void check () {
        if (first.name == second.name) {
            count += 1;
            //first.GetComponent<BoxCollider2D> ().enabled = false;
            //second.GetComponent<BoxCollider2D> ().enabled = false;
            first.SetActive(false);
            second.SetActive(false);
            SoundManager.Instance.gameSounds[1].Play();

            if (count == 6) {
                Prize.SetActive (true);
                Knives.SetActive(false);
                    
            }
            Debug.Log ("match");
        } else {
            //StartCoroutine (waitFor3 ());
            Debug.Log ("Notmatch");
            first.SetActive(true);
            second.SetActive(true);
        }
    }

    private void SavePuzzleData()
    {
        SavingSo.IndicesOfActiveSpriteRenderer.Clear();

        if (UnLitcandle.GetComponent<SpriteRenderer>().enabled)
            SavingSo.IndicesOfActiveSpriteRenderer.Add(0);
        if (litcandle.GetComponent<SpriteRenderer>().enabled)
            SavingSo.IndicesOfActiveSpriteRenderer.Add(1);
        //calll savepuzzdatamanger with the so and nameofthefile

        PuzzleDataSaveLoad.instance.Save(SavingSo, fileName);

    }
    bool LoadData()
    {
        if (PuzzleDataSaveLoad.instance.Load(SavingSo, fileName) != null)
        {
            SavingSo = PuzzleDataSaveLoad.instance.Load(SavingSo, fileName);
            return true;
        }
        else
        {
            return false;
        }
    }
}

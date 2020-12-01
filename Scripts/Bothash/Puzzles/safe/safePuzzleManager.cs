using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safePuzzleManager : MonoBehaviour
{
    [SerializeField]
    List<Transform> tilesPos = new List<Transform> ();
    public GameObject prize;
    List<Transform> tilesPosOrg = new List<Transform> ();
    public List<int> posAfterRandom=new List<int>();
    [SerializeField]
    private GameObject[] tiles;
    public GameObject blankTile;
    public int blankPos;
    public int[,] adjMatrix;
    public int counter;
    Vector3 temp1 = new Vector3 (0, 0, 0);
    Vector3 temp2 = new Vector3 (0, 0, 0);
    int randI;

    public GameObject refSpade;
    public GameObject Blocker;
    public static safePuzzleManager Instance{get;set;}

    public string SteamACH1 = "Safe Cracker";
    public string SteamACH = "Puzzle Master";
    void OnEnable()
    {
        var temp = false;
        foreach(bothash.InventoryItemSO item in bothash.InventoryManager.instance.InventorySO.myInventory)
        {
            if(item.itemName == "Spade Token")
            {
                temp = true;
            }
        }

        if(temp || refSpade.activeSelf)
        {
            Blocker.SetActive(false);
        }
        
    }
// Start is called before the first frame update
        void Awake () {
            if (Instance == null) {
                Instance = this;
                //DontDestroyOnLoad (gameObject);
            } else {
                Destroy (gameObject);
            }

        }

    void Start()
    {   
        
        counter=0;
        for (int i = 0; i < tilesPos.Count; i++) {
            tilesPosOrg.Add (tilesPos[i]);
        }
        int pos;
        for (int i = 0; i < tiles.Length; i++) {
            pos = UnityEngine.Random.Range (0, tilesPos.Count);
            tiles[i].transform.localPosition = tilesPos[pos].position;
            if(tilesPosOrg.IndexOf (tilesPos[pos])>3){
                posAfterRandom.Add(tilesPosOrg.IndexOf (tilesPos[pos])+1);
            }
            else
                posAfterRandom.Add(tilesPosOrg.IndexOf (tilesPos[pos]));
            tilesPos.RemoveAt (pos);
        }
        posAfterRandom.Insert(4,4);
        adjMatrix=new int[,]{{0,1,0,1,0,1,0,0},{1,0,1,1,1,0,0,0},{0,1,0,0,1,0,0,0},{1,1,0,0,0,1,1,0},{0,1,1,0,0,0,1,1},{1,0,0,1,0,0,1,0},{0,0,0,1,1,1,0,1},{0,0,0,0,1,0,1,0}};
    }

    // Update is called once per frame
    void Update()
    {
        if(check()  ){
                prize.SetActive(true);
                if(!FileBasedPrefs.HasKey("safePrefset")){
                FileBasedPrefs.SetInt("safePrefset",1);
                if (FileBasedPrefs.HasKey("bigPuzzCount") )
                {
                    FileBasedPrefs.SetInt("bigPuzzCount", FileBasedPrefs.GetInt("bigPuzzCount") + 1);
                }
                else
                {
                    FileBasedPrefs.SetInt("bigPuzzCount", 1);
                }
                Debug.Log(FileBasedPrefs.GetInt("bigPuzzCount"));
                if (FileBasedPrefs.GetInt("bigPuzzCount") >= 8)
                {
                    SteamHandler.instance.SetAch(SteamACH);
                }
                }
            }
    }
    public void passData(GameObject token){
        randI = posAfterRandom[int.Parse(token.name)];
        Debug.Log(randI);
        if(adjMatrix[randI,blankPos]>0){
            posAfterRandom[int.Parse(token.name)] = blankPos;
            blankPos = randI;
            Debug.Log(blankPos);
                    
            if(counter==0){
                temp1 = token.transform.localPosition;
                token.transform.localPosition = blankTile.transform.position;
                counter++;
            }
            else
            {
                temp2=token.transform.localPosition;
                token.transform.localPosition=temp1;
                temp1=temp2;
            }
            if(check()){
                prize.SetActive(true);

                

                
                SteamHandler.instance.SetAch(SteamACH1);
            }
            
            //safePuzzleManager.Instance.blankTile.transform.position = temp1;
        }
    }
    public bool check(){
        for (int i = 0; i < posAfterRandom.Count; i++) {
                if (posAfterRandom[i] != i) {
                    return false;
                }
            }
            return true;
    }
}

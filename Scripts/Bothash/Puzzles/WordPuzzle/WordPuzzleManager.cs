using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordPuzzleManager : MonoBehaviour
{
    public Text TotalCount;
    public Text FoundCount;

    public GameObject[] character;
    public DIalogue Dialogues;
    
    public GameObject navToComp;
    public GameObject navToPuzz;

    public static WordPuzzleManager instance;

    public List<string> HorizontalDragWords;
    public List<string> VerticalDragWords;

    public GameObject Reward;

    public string theWord = null;

    private HashSet<GameObject> wordSet = new HashSet<GameObject>();

    private List<string> FoundWord = new List<string>();

    public Color LineColor;


    
    Vector3 startPos;
    Vector3 endPos;
    public Gradient gradientColor;
    LineRenderer lr;
    [SerializeField]

    public float lineWidth = 1;

    public string SteamACH = "Puzzle Master";
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
    // Start is called before the first frame update
    void Start()
    {
        TotalCount.text = (HorizontalDragWords.Count + VerticalDragWords.Count).ToString();
        updateUI();
        lr = this.gameObject.GetComponent<LineRenderer>();
        lr.positionCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewWordDrag(GameObject piece)
    {
        
        lr.positionCount = 1;
        lr.SetWidth(lineWidth, lineWidth);
        
        startPos = piece.transform.position;
        lr.SetPosition(0, piece.transform.position);
        //lr.useWorldSpace = true;
        
        //lr.colorGradient = gradientColor;
        //lr.SetColors(LineColor, LineColor);
        
        lr.positionCount = 2;

        if (theWord!=null)
        theWord = null;


        if (wordSet.Count >= 0)
            wordSet.Clear();
        if (piece.GetComponent<wordPiece>()!=null)
        {
            //Debug.Log(piece.name);
            wordSet.Add(piece);
            //theWord += piece.name;
            //piece.GetComponent<SpriteRenderer>().enabled = true;
            //piece.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.4f);

        }
        else
        {
            //theWord += piece.GetComponent<wordPiece>().pieceName;
        }
    }

    public void ContinueWordDrag(GameObject piece)
    {
        lr.enabled = true;
        endPos = piece.transform.position;
        lr.SetPosition(1, piece.transform.position);
        
        //Debug.Log(piece.name);
        if (piece.GetComponent<wordPiece>()!=null)
        {
            
            wordSet.Add(piece);
            //theWord += piece.name;
            //piece.GetComponent<SpriteRenderer>().enabled = true;
            //piece.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.4f);
        }
        else
        {
            wordSet.Add(piece);
            //theWord += piece.GetComponent<wordPiece>().pieceName;
        }
    }

    public void EndWordDrag(GameObject piece)
    {
        lr.SetPosition(1, piece.transform.position);
        lr.enabled = false;
        lr.positionCount = 0;

        if (piece.GetComponent<wordPiece>()!=null)
        {
            wordSet.Add(piece);
            //theWord += piece.name;
            //piece.GetComponent<SpriteRenderer>().enabled = true;
            //piece.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.4f);
        }
        else
        {
            //theWord += piece.GetComponent<wordPiece>().pieceName;
        }

        foreach(GameObject obj in wordSet)
        {
            theWord += obj.name;
        }
        Debug.Log(theWord);

        if (HorizontalDragWords.Contains(theWord))
        {
            if (!FoundWord.Contains(theWord))
            {
                Debug.Log("Matched Horizontal");
                FoundWord.Add(theWord);
                foreach (GameObject tmppobj in wordSet)
                {
                    tmppobj.GetComponent<wordPiece>().matchedCount++;
                    if (tmppobj.GetComponent<wordPiece>().matchedCount >= 2)
                        tmppobj.GetComponent<SpriteRenderer>().color = new Color(1, 0.6f, 1, 0.6f);
                    else
                        tmppobj.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 0.6f);
                    tmppobj.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            else
            {
                foreach (GameObject tmppobj in wordSet)
                {
                    tmppobj.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 0.6f);
                    tmppobj.GetComponent<SpriteRenderer>().enabled = true;
                }
            }

            

        }
        else if (VerticalDragWords.Contains(theWord))
        {
            if (!FoundWord.Contains(theWord))
            {
                Debug.Log("Matched Vertical");
                FoundWord.Add(theWord);
                foreach (GameObject tmppobj in wordSet)
                {
                    tmppobj.GetComponent<wordPiece>().matchedCount++;
                    if (tmppobj.GetComponent<wordPiece>().matchedCount >= 2)
                        tmppobj.GetComponent<SpriteRenderer>().color = new Color(1, 0.6f, 1, 0.6f);
                    else
                        tmppobj.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 0.6f);
                    tmppobj.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            else
            {
                foreach (GameObject tmppobj in wordSet)
                {
                    tmppobj.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 0.6f);
                    tmppobj.GetComponent<SpriteRenderer>().enabled = true;
                }
            }


        }
        else
        {
            foreach (GameObject tmpobj in wordSet)
            {
                if(tmpobj.GetComponent<wordPiece>().matchedCount <= 0)
                tmpobj.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        updateUI();
        checkIfWon();
        
    }

    private void checkIfWon()
    {
        if (FoundWord.Count >= HorizontalDragWords.Count + VerticalDragWords.Count)
        {
            Debug.Log("WON WORD PUZZLE");

            Reward.SetActive(true);

            if (FileBasedPrefs.HasKey("bigPuzzCount"))
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



            navToComp.SetActive(false);
            navToPuzz.SetActive(true);
            
            bothash.DialogueM.Instance.sentence = Dialogues.sentences;
            bothash.DialogueM.Instance.Avatar = character;
            bothash.DialogueM.Instance.Audio = Dialogues.Audios;
            bothash.DialogueM.Instance.startDialogue ();
            //this.gameObject.SetActive(false);
        }
    }

    private void updateUI()
    {
        if (FoundWord.Count == 0)
            FoundCount.text = "0";
        else
        FoundCount.text = FoundWord.Count.ToString();
    }
}

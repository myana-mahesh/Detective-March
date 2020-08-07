using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSecretButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Add Objects in reverse Sequence")]
    public List<GameObject> Objects;

    public GameObject Reward;

    public static ClockSecretButtonManager Instance;


    private Stack<GameObject> _stack = new Stack<GameObject>();
    private bool _puzzleCompleted=false;

    
    void Start()
    {
        
    }

    void OnEnable()
    {

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
        {
            Instance = this;
            Destroy(gameObject);
        }

        ClearAndResetStack();

        Debug.Log(_stack);

        

    }

    void ClearAndResetStack()
    {
        _stack.Clear();
        foreach (GameObject item in Objects)
        {
            _stack.Push(item);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void iAmClicked(GameObject caller)
    {
        if (_stack.Count > 0 && !_puzzleCompleted)
        {
            Debug.Log(string.Format("On Stack To: {0} | Caller Object: {1}", _stack.Peek().name, caller.name));
            
            if (_stack.Peek().name == caller.name)
            {
                _stack.Pop();
                if (_stack.Count == 0)
                {
                    Reward.SetActive(true);
                    Debug.Log("Won");
                    _puzzleCompleted = true;

                }
            }
            else
            {
                Debug.Log("Sequence Not Found, Resetting Stack");
                ClearAndResetStack();
                Reward.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Already WOn");
            _puzzleCompleted = true;
            Reward.SetActive(true);
        }

        
    }
}

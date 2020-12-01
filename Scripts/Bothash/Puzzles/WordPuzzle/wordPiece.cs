using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordPiece : MonoBehaviour
{
    
    // Start is called before the first frame update
    public string pieceName;
    public int matchedCount = 0;
    private WordPuzzleManager mnInstance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("----------------------------------");
        Debug.Log(this.gameObject.name);
        mnInstance = WordPuzzleManager.instance;
        mnInstance.StartNewWordDrag(this.gameObject);
    }

    void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

        if (hit)
        {
            Debug.Log(hit.collider.gameObject.name);
            mnInstance.ContinueWordDrag(hit.collider.gameObject);
        }

    }

    void OnMouseUp()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

        if (hit)
        {
            Debug.Log(hit.collider.gameObject.name);
            mnInstance.EndWordDrag(hit.collider.gameObject);
        }

    }
}

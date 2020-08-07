using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour {

    public Texture2D mousePointerNormal;
    public Texture2D mousePointerExamine;
    public Texture2D mousePointerPickUp;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public static MousePointer Instance { get; private set; }

    void Awake () {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad (gameObject);
        } else {
            Destroy (gameObject);
        }
    }
    void Start () {
        SetNormalPointer ();
    }

    public void SetNormalPointer () {
        Cursor.SetCursor (mousePointerNormal, hotSpot, cursorMode);
    }

    public void SetExaminePointer () {
        Cursor.SetCursor (mousePointerExamine, hotSpot, cursorMode);
    }

    public void SetPickUpPointer () {
        Cursor.SetCursor (mousePointerPickUp, hotSpot, cursorMode);
    }
}
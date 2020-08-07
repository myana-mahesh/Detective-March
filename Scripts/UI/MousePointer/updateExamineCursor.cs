using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateExamineCursor : MonoBehaviour
{

/*     MousePointer myPointer;
 */
    void Start()
    {

/*         myPointer = GameObject.FindGameObjectWithTag("Main").GetComponent<MousePointer>();
 */    }

    void OnMouseEnter()
    {
        MousePointer.Instance.SetExaminePointer();
    }

    void OnMouseExit()
    {
        MousePointer.Instance.SetNormalPointer();
    }
}

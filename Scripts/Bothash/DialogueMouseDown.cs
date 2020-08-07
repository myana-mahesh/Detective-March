using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace bothash {
    public class DialogueMouseDown : MonoBehaviour {
         private void Update() {
          /*   if(Input.GetKeyDown(KeyCode.Mouse0)){
                Debug.Log("before");
                RaycastHit2D hit=Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
                Debug.Log("after ray");
                if(hit.collider!=null){
                    Debug.Log("hit");
                }
                if(hit.collider.name=="Canvas"){
                    Debug.Log("panel hit");
                }
            }  */   

         }
         public void Next(){
             DialogueM.Instance.NextDialogue();
         }
        }
    }
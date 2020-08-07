using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace bothash
{
    public class Slot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public InventoryItemSO myProperty;
        public Image Palceholder;

        private bool _isDragging = false;
        private bool _isDragSuccess = false;

        private Vector3 _originalPosition;

        

        void Awake()
        {
            _originalPosition = Palceholder.gameObject.transform.localPosition;
        }

        

        public void OnPointerEnter(PointerEventData eventData)
        {
            MousePointer.Instance.SetPickUpPointer();
            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            MousePointer.Instance.SetNormalPointer();
        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            
            Debug.Log("dragging start");
            
            _isDragSuccess = false;
            this.transform.parent.parent.GetComponent<Mask>().enabled = false;
            


        }


        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("dragging");

            Palceholder.transform.position = eventData.position;

        }

        

        public void OnEndDrag(PointerEventData eventData)
        {
            
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(eventData.position);
            RaycastHit2D hit = Physics2D.Raycast(mousepos, Vector2.zero);
            Debug.Log("Drag End");
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                
                if (myProperty.isPuzzleObject && hit.collider.gameObject.name == myProperty.puzzlePieceName )
                {
                    _isDragSuccess = true;
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    InventoryManager.instance.removeFromInventory(this.gameObject);
                    Destroy(this.gameObject);
                    
                }
                else if(myProperty.isMechanicTools && hit.collider.gameObject.name == myProperty.MechanicsDropObjectName)
                {
                    Debug.LogFormat("ADD CODE FOR MECHANICS BASIN PUZZLE");
                }
                else if (myProperty.isDropAble && hit.collider.gameObject.name == myProperty.DropObjectName)
                {
                    Debug.Log("Drop tool");
                    hit.collider.gameObject.GetComponent<ThirdPartyDropping>().InitiateThirdParty();
                    hit.collider.gameObject.SetActive(false);
                    _isDragSuccess = true;
                    InventoryManager.instance.removeFromInventory(this.gameObject);
                    Destroy(this.gameObject);
                }
                else
                {
                    Debug.Log("Collider dow nnull");
                    _isDragSuccess = false;
                    
                    Palceholder.transform.localPosition = _originalPosition;
                    
                }
            }
            else
            {
                Palceholder.transform.localPosition = _originalPosition;
            }

            this.transform.parent.parent.GetComponent<Mask>().enabled = true;




        }

        
    }
}
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
        public DIalogue Dialogues;
        public GameObject[] character;



        void Awake()
        {
            _originalPosition = Palceholder.gameObject.transform.localPosition;
        }

        //

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

            //Debug.Log("dragging start");

            _isDragSuccess = false;

            if (myProperty != null)
            {
                InventoryManager.instance.MouseMoveImage.enabled = true;
                InventoryManager.instance.MouseMoveImage.sprite = myProperty.inventorySprite;
                Palceholder.enabled = false;
            }

            //this.transform.parent.parent.GetComponent<Mask>().enabled = false;



        }


        public void OnDrag(PointerEventData eventData)
        {
            //Debug.Log("dragging");
            if (myProperty != null)
                InventoryManager.instance.MouseMoveImage.gameObject.transform.position = eventData.position;
            //Palceholder.transform.position = eventData.position;


        }



        public void OnEndDrag(PointerEventData eventData)
        {
            if (myProperty != null)
            {
                
                InventoryManager.instance.MouseMoveImage.enabled = false;
                Vector2 mousepos = Camera.main.ScreenToWorldPoint(eventData.position);
                RaycastHit2D hit = Physics2D.Raycast(mousepos, Vector2.zero);
                Debug.Log("Drag End");

                if (hit.collider != null)
                {
                    if (!myProperty.isSimpleDrop)
                    {
                        Debug.Log(hit.collider.gameObject.name==myProperty.DropObjectName);

                        if (myProperty.isPuzzleObject && hit.collider.gameObject.name == myProperty.puzzlePieceName)
                        {
                            _isDragSuccess = true;
                            hit.collider.gameObject.GetComponent<SpriteRenderer>().enabled = true;

                            //if (InventoryManager.instance.inventoryCount < InventoryManager.instance.firstSixSlots.Count)
                            //{
                            //    this.gameObject.GetComponent<bothash.Slot>().myProperty = null;
                            //    this.gameObject.GetComponent<bothash.Slot>().Palceholder.color = new Color(1, 1, 1, 0);
                            //    InventoryManager.instance.removeFromInventory(this.gameObject);
                            //}
                            //else
                            //{

                            InventoryManager.instance.removeFromInventory(this.gameObject);
                            Destroy(this.gameObject);

                            //}


                            //inventory count is less than 5
                            // make img sprite none
                            //else do follwoing


                        }
                        else if (myProperty.isMechanicTools && hit.collider.gameObject.name == myProperty.MechanicsDropObjectName)
                        {
                            Debug.LogFormat("ADD CODE FOR MECHANICS BASIN PUZZLE");
                        }
                        else if (myProperty.isDropAble && hit.collider.gameObject.name == myProperty.DropObjectName)
                        {
                            Debug.Log("Drop tool");
                           
                            if (myProperty.hideSelf)
                                hit.collider.gameObject.SetActive(false);
                            else
                                hit.collider.gameObject.SetActive(true);
                            hit.collider.gameObject.GetComponent<ThirdPartyDropping>().InitiateThirdParty();
                            _isDragSuccess = true;

                            //if (InventoryManager.instance.inventoryCount < InventoryManager.instance.firstSixSlots.Count)
                            //{
                            //    this.gameObject.GetComponent<bothash.Slot>().myProperty = null;
                            //    this.gameObject.GetComponent<bothash.Slot>().Palceholder.color = new Color(1,1,1,0);
                            //    InventoryManager.instance.removeFromInventory(this.gameObject);
                            //}
                            //else
                            //{
                            InventoryManager.instance.removeFromInventory(this.gameObject);
                            Destroy(this.gameObject);

                            //}


                        }
                        else
                        {
                            if (myProperty.blockerDiaglogue)
                            {
                                if (hit.collider.gameObject.GetComponent<BlockerDialogue>() != null){
                                    callOutMyDiag(hit.collider.gameObject.GetComponent<BlockerDialogue>().diaglogue);
                                    _isDragSuccess = false;

                                    Palceholder.transform.localPosition = _originalPosition;
                                    Palceholder.enabled = true;}
                                else
                                {
                                    Debug.Log("Collider dow nnull");
                                    _isDragSuccess = false;

                                    Palceholder.transform.localPosition = _originalPosition;
                                    Palceholder.enabled = true;
                                    int pos = Random.Range(0, Dialogues.sentences.Length);
                                    DialogueM.Instance.sentence = new string[1] { Dialogues.sentences[pos] };
                                    DialogueM.Instance.Avatar = new GameObject[1] { character[pos] };
                                    DialogueM.Instance.Audio = new AudioClip[1] { Dialogues.Audios[pos] };
                                    DialogueM.Instance.startDialogue();
                                }
                            }
                            else
                            {
                                Debug.Log("Collider dow nnull");
                                _isDragSuccess = false;

                                Palceholder.transform.localPosition = _originalPosition;
                                Palceholder.enabled = true;
                                int pos = Random.Range(0, Dialogues.sentences.Length);
                                DialogueM.Instance.sentence = new string[1] { Dialogues.sentences[pos] };
                                DialogueM.Instance.Avatar = new GameObject[1] { character[pos] };
                                DialogueM.Instance.Audio = new AudioClip[1] { Dialogues.Audios[pos] };
                                DialogueM.Instance.startDialogue();
                            }

                        }
                    }
                    else
                    {
                        if (hit.collider.gameObject.name == myProperty.simpleDropObjectName)
                        {
                            hit.collider.gameObject.GetComponent<SimpleDropManager>().SetData ( myProperty);
                            _isDragSuccess = true;
                            InventoryManager.instance.removeFromInventory(this.gameObject);
                            Destroy(this.gameObject);
                        }
                        else
                        {
                            if (myProperty.blockerDiaglogue)
                            {
                                if(hit.collider.gameObject.GetComponent<BlockerDialogue>()!=null){
                                callOutMyDiag(hit.collider.gameObject.GetComponent<BlockerDialogue>().diaglogue);
                                _isDragSuccess = false;

                                    Palceholder.transform.localPosition = _originalPosition;
                                    Palceholder.enabled = true;}
                                else
                                {
                                    Debug.Log("Collider dow nnull");
                                    _isDragSuccess = false;

                                    Palceholder.transform.localPosition = _originalPosition;
                                    Palceholder.enabled = true;
                                    int pos = Random.Range(0, Dialogues.sentences.Length);
                                    DialogueM.Instance.sentence = new string[1] { Dialogues.sentences[pos] };
                                    DialogueM.Instance.Avatar = new GameObject[1] { character[pos] };
                                    DialogueM.Instance.Audio = new AudioClip[1] { Dialogues.Audios[pos] };
                                    DialogueM.Instance.startDialogue();
                                }
                            }
                            else
                            {

                                Palceholder.transform.localPosition = _originalPosition;
                                Palceholder.enabled = true;
                                int pos = Random.Range(0, Dialogues.sentences.Length);
                                DialogueM.Instance.sentence = new string[1] { Dialogues.sentences[pos] };
                                DialogueM.Instance.Avatar = new GameObject[1] { character[pos] };
                                DialogueM.Instance.Audio = new AudioClip[1] { Dialogues.Audios[pos] };
                                DialogueM.Instance.startDialogue();
                            }
                        }
                    }
                }
                else
                {
                    Debug.Log("no collider detected");
                    Palceholder.transform.localPosition = _originalPosition;
                    Palceholder.enabled = true;
                    int pos=Random.Range(0,Dialogues.sentences.Length);
                    DialogueM.Instance.sentence =new string[1]{Dialogues.sentences[pos]};
                    DialogueM.Instance.Avatar =new GameObject[1] {character[pos]};
                    DialogueM.Instance.Audio =new AudioClip[1]{ Dialogues.Audios[pos]};
                    DialogueM.Instance.startDialogue ();
                }

                //this.transform.parent.parent.GetComponent<Mask>().enabled = true;




            }


        }

        private void callOutMyDiag(DIalogue diag)
        {
            DialogueM.Instance.sentence = new string[1] { diag.sentences[0] };
            DialogueM.Instance.Avatar = new GameObject[1] { character[0] };
            DialogueM.Instance.Audio = new AudioClip[1] { diag.Audios[0] };
            DialogueM.Instance.startDialogue();
        }
    }

    
}
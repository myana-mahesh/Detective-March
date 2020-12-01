using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPartyDropping : MonoBehaviour
{
    public bool haveDialogues;
    public GameObject[] character;
    public DIalogue Dialogues;

    [Header("Third Party obj details")]
    public GameObject ThirdPartyObject;

    [Header("Handle Below Animations")]
    public bool StartAnim = false;
    public Animator AnimationComponent;
    // Start is called before the first frame update

    [Header("IF MULTIPLE OBJECTS")]
    public bool isMultipleObject = false;
    public List<GameObject> otherObjects;

    public bool isSteamACH = false;
    public string SteamACH = "Animal Lover";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiateThirdParty()
    {

        if (isSteamACH){
                Debug.Log("ach set for "+ SteamACH);
                SteamHandler.instance.SetAch(SteamACH);

            }

        if (isMultipleObject)
        {
            foreach(GameObject obj in otherObjects)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Initiating Thrd Party");
            Debug.Log(string.Format("Third Party Object Name: {0}", ThirdPartyObject.name));
          
            ThirdPartyObject.SetActive(true);
            
            if (StartAnim)
            {
                AnimationComponent.enabled = true;
            }
            if (haveDialogues){
                bothash.DialogueM.Instance.sentence = Dialogues.sentences;
                bothash.DialogueM.Instance.Avatar = character;
                bothash.DialogueM.Instance.Audio = Dialogues.Audios;
                bothash.DialogueM.Instance.startDialogue ();
            }
            if(this.gameObject.name=="Fireplace"){
                FileBasedPrefs.SetInt("darkRoomActivated",1);
            }
        }
    }
}

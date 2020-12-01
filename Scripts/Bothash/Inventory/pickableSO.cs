using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickableSO : MonoBehaviour
{
    #region Public Variables


    public bothash.InventoryItemSO item;

    [Header("IF WANT TO ACTIVATE / DEACTIVATE SOME OTHER OBJECTS ON PICKUP OF THIS OBJECT")]
    public bool isActivateOther=false;

    public bool Activate;
    public GameObject otherObject;


    #endregion




    void OnMouseDown()
    {
        pickSO();
        if (isActivateOther)
        {
            otherObject.SetActive(Activate);
        }
    }






    #region Public Methods

    public void pickSO()
    {

        bothash.InventoryManager.instance.addToInventory(item);
        this.gameObject.SetActive(false);
        SoundManager.Instance.gameSounds[3].Play();
    }




    #endregion


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickableSO : MonoBehaviour
{
    #region Public Variables


    public bothash.InventoryItemSO item;



    #endregion




    void OnMouseDown()
    {
        pickSO();
    }






    #region Public Methods

    public void pickSO()
    {

        bothash.InventoryManager.instance.addToInventory(item);
        this.gameObject.SetActive(false);
    }




    #endregion


}
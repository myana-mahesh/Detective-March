using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDropManager : MonoBehaviour
{
    public bothash.InventoryItemSO droppedPropertySo;

    public bool isMultipleDrop = false;
    // Start is called before the first frame update

    public List<bothash.InventoryItemSO> multipleDropObjects;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(bothash.InventoryItemSO dropObject)
    {
        if(!isMultipleDrop)
        droppedPropertySo = dropObject;
        else
        {
            multipleDropObjects.Add(dropObject);
        }
    }

    public bothash.InventoryItemSO GetData()
    {
        return droppedPropertySo;
    }

    public List<bothash.InventoryItemSO> GetDatas()
    {
        return multipleDropObjects;
    }
}

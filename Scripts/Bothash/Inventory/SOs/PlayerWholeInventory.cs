using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bothash
{

    [CreateAssetMenu(fileName = "wholeCon", menuName = "InventorySo/Main Inventory")]
    [System.Serializable]
    public class PlayerWholeInventory : ScriptableObject
    {
        public List<bothash.InventoryItemSO> myInventory = new List<bothash.InventoryItemSO>();
    }


}
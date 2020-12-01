using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bothash
{

    [CreateAssetMenu(fileName = "item", menuName = "InventorySo/items")]
    [System.Serializable]

    public class InventoryItemSO : ScriptableObject
    {

        public string itemName;
        public Sprite inventorySprite;

        public bool isPuzzleObject;
        public string puzzlePieceName;
        public string puzzleName;

        public bool isMechanicTools;
        public string MechanicsDropObjectName;
        public string ToolName;

        public bool isDropAble;
        public string DropObjectName;
        public bool hideSelf = true;

        [Header("Shhift Control to the Manager")]
        public bool isSimpleDrop = false;
        public string simpleDropObjectName;

        public bool blockerDiaglogue;
    }


}
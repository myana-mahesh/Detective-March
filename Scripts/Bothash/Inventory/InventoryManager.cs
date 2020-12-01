using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace bothash
{
    public class InventoryManager : MonoBehaviour
    {

        #region Public Variables

        public static InventoryManager instance;
        public bothash.PlayerWholeInventory InventorySO;
        public GameObject slotPrefab;
        public Transform InventoryScrollSlotParent;

        public List<GameObject> firstSixSlots;

        public int inventoryCount = 0;
        public Image MouseMoveImage;

        public Dictionary<string, GameObject> slotItemDict;
        #endregion


        #region MonoBehaviour CallBacks
        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }


        void OnEnable()
        {
           
        }

        void OnDisable()
        {
            Debug.Log("Saving To Database");
            //saveToDB();
        }


        void Start()
        {
             Debug.Log("Loading Data From Database");
            slotItemDict = new Dictionary<string, GameObject>();
            loadFromDB();
            
        }

        void Update()
        {

        }

        #endregion


        #region Public Methods

        public void addToInventory(bothash.InventoryItemSO item)
        {
            GameObject Slot;
            //check for first already instatiated objects
            if(inventoryCount < firstSixSlots.Count)
            {
                Slot = firstSixSlots[inventoryCount];
                Slot.GetComponent<bothash.Slot>().Palceholder.color = new Color(1, 1, 1, 1);

            }
            else
            {
                Slot = Instantiate(slotPrefab, InventoryScrollSlotParent);
            }
            //if available use that slot
            //else do the below
            //counter++

            //@todo
            //instantiate slot gameobject

            /////REPLACE THE SPRITE WITH FRESH SPRITE
            item.inventorySprite = inventoryDictionary.instance.invNameSpriteMap[item.itemName];

            // add reference of item to the slot object
            Slot.GetComponent<bothash.Slot>().myProperty = item;
            //add sprite to slot
            Slot.GetComponent<bothash.Slot>().Palceholder.sprite= item.inventorySprite;

            slotItemDict.Add(item.itemName, Slot);
            //add item to player whole inventory
            InventorySO.myInventory.Add(item);

            inventoryCount++;
            Debug.Log("Added");
            Debug.Log(string.Format("INV COUNT {0}", inventoryCount));

        }     
        
        

        public void removeFromInventory(GameObject invObj)
        {
            //if counter < 6
            //counter --
            //else do nothing
            

            bothash.InventoryItemSO item = invObj.GetComponent<bothash.Slot>().myProperty;
            
            if (item)
            {
                if (firstSixSlots.Contains(invObj))
                    firstSixSlots.Remove(invObj);
                slotItemDict.Remove(item.itemName);
                var result = InventorySO.myInventory.Remove(item);
                Debug.Log(string.Format("Removed: {0}", result.ToString()));
                inventoryCount--;
                Debug.Log(string.Format("INV COUNT {0}", inventoryCount));
            }
        }




        public void resetDB()
        {
            int i = 0;
            while (File.Exists(Application.persistentDataPath + "/Inventory" + string.Format("/{0}.invso", i)))
            {
                File.Delete(Application.persistentDataPath + "/Inventory" + string.Format("/{0}.invso", i));
                i++;
            }

            Debug.Log("Flushed");
        }



        public void saveToDB()
        {
            resetDB();
            if (!Directory.Exists(Application.persistentDataPath + "/Inventory"))
                Directory.CreateDirectory(Application.persistentDataPath + "/Inventory");
            int i;
            for ( i = 0; i < InventorySO.myInventory.Count; i++)
            {
                FileStream file = File.Create(Application.persistentDataPath + "/Inventory" + string.Format("/{0}.invso", i));
                BinaryFormatter binary = new BinaryFormatter();
                var json = JsonUtility.ToJson(InventorySO.myInventory[i]);
                binary.Serialize(file, json);
                file.Close();
            }

            Debug.Log(string.Format("Saved: {0} Items",i));
        }


        public void loadFromDB()
        {
            inventoryDictionary.instance.StartMap();
            InventorySO.myInventory.Clear();
            int i = 0;
            while (File.Exists(Application.persistentDataPath + "/Inventory" + string.Format("/{0}.invso", i)))
            {
                var temp = ScriptableObject.CreateInstance<bothash.InventoryItemSO>();
                FileStream file = File.Open(Application.persistentDataPath + "/Inventory" + string.Format("/{0}.invso", i), FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), temp);
                file.Close();
                //InventorySO.myInventory.Add(temp);
                Debug.Log("Loaded into SO");

                

                addToInventory(temp);

                Debug.Log("Name: " + temp.name);

                //GameObject Slot = Instantiate(slotPrefab, InventoryScrollSlotParent);
                //Slot.GetComponent<bothash.Slot>().myProperty = InventorySO.myInventory[i];
                //Slot.GetComponent<bothash.Slot>().Palceholder.sprite= InventorySO.myInventory[i].inventorySprite;

                i++;

            }

            Debug.Log(string.Format("Loaded: {0} Inventory Items", i));

        }


        #endregion

    }


}
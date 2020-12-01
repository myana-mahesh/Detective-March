using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace bothash
{
    public class inventoryDictionary : MonoBehaviour
    {
        public static inventoryDictionary instance;
        public List<InventoryItemSO> AllSO;
        private bool flag=false;
        public Dictionary<string, Sprite> invNameSpriteMap=new Dictionary<string,Sprite>();
     void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(this.gameObject);
 
        }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void StartMap()
        {
            if (!flag)
            {
                foreach(InventoryItemSO item in AllSO)
                {
                    try
                    {
                        invNameSpriteMap.Add(item.itemName, item.inventorySprite);
                    }
                    catch (System.Exception)
                    {

                        continue;
                    }
                        
                    
                
                }

                flag = true;
            }
            else
                return;
                
        }
}


}
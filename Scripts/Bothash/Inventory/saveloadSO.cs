using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class saveloadSO : MonoBehaviour
{
    public bothash.PlayerWholeInventory invo;
    public List<Image> slot;




    public void resetSo()
    {
        int i = 0;
        while (File.Exists(Application.persistentDataPath + string.Format("/{0}.invso", i)))
        {
            File.Delete(Application.persistentDataPath + string.Format("/{0}.invso", i));
            i++;
        }
    }


    public void saveSO()
    {
        resetSo();
        for (int i = 0; i < invo.myInventory.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.invso", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(invo.myInventory[i]);
            binary.Serialize(file, json);

            file.Close();
        }

        Debug.Log("Save");

    }

    public void LoadSO()
    {
        invo.myInventory.Clear();
        int i = 0;
        while (File.Exists(Application.persistentDataPath + string.Format("/{0}.invso", i)))
        {
            var temp = ScriptableObject.CreateInstance<bothash.InventoryItemSO>();
            FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.invso", i), FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter();
            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), temp);
            file.Close();
            invo.myInventory.Add(temp);
            i++;
            Debug.Log("Loaded into SO");
        }

        for (int j = 0; j < invo.myInventory.Count; j++)
        {
            Debug.Log("Name: " + invo.myInventory[j].name);
            slot[j].sprite = invo.myInventory[j].inventorySprite;

        }

    }

}
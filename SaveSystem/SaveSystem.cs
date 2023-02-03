using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveInventory()
    {
        var formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/inventory.dat";

        var stream = new FileStream(path, FileMode.Create);
        var inventoryData = new InventoryData(UI_Inventory.Instance.GetInventory());

        formatter.Serialize(stream, inventoryData);
        stream.Close();
    }

    public static InventoryData LoadInventory()
    {
        string path = Application.persistentDataPath + "/inventory.dat";
        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);

            var inventoryData = (InventoryData)formatter.Deserialize(stream);
            stream.Close();

            return inventoryData;
        }
        else return null;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoInventory : MonoBehaviour
{
    private Dictionary<string,int> ammoDictionary = new Dictionary<string,int>();

    [SerializeField] private AmmoContainer ammoContainer;

    public Dictionary<string,int> GetAmmoDict()
    {
        return ammoDictionary;
    }
    public bool AddAmmoToDict(string key, int val)
    {
        if (!ammoDictionary.ContainsKey(key))
        {
            ammoDictionary.Add(key, val);
            return true;
        }
        else
        {
            return false; // Eðer anahtar zaten varsa ekleme iþlemi baþarýsýz olur.
        }
    }

    private void Start()
    {
        foreach (var item in ammoContainer.ammoList)
        {
            ammoDictionary.Add(item.GetFoodType().ToString(), 0);
            Debug.Log($"Added{item.GetFoodType()} to dict");

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase
{
    static private List<Item> _item;
    static private bool _isDatabaseLoaded = false;
    static private void ValidateDatabase()
    {
        if (_item == null)
            _item = new List<Item>();
        if (!_isDatabaseLoaded) LoadDatabase();
    }
    static public void LoadDatabase()
    {
        if (_isDatabaseLoaded) return;
        _isDatabaseLoaded = true;
        LoadDatabaseForce();
    }

    static public int Getlengh()
    {

        ValidateDatabase();
        Item[] resource = Resources.LoadAll<Item>(@"itemResources");
        return resource.Length;
    }
    static public void LoadDatabaseForce()
    {
        ValidateDatabase();
        Item[] resource = Resources.LoadAll<Item>(@"itemResources");
        foreach (Item item in resource)
        {
            if (!_item.Contains(item))
            {
                _item.Add(item);
            }
        }
    }
    static public void ClearDatabase()
    {
        _isDatabaseLoaded = false;
        _item.Clear();
    }
    static public Item GetItem(int id)
    {
        ValidateDatabase();
        foreach (Item item in _item)
        {
            if (item.itemID == id)
            {
                return ScriptableObject.Instantiate(item) as Item;
            }
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ItemUtility
{
    [MenuItem("Assets/Create/item")]
    static public void CreateItem()
    {
        ScriptableObjectUtility.CreateAsset<Item>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
public class ItemUtility
{

    [UnityEditor.MenuItem("Assets/Create/item")]
    static public void CreateItem()
    {
        ScriptableObjectUtility.CreateAsset<Item>();
    }

}
#endif

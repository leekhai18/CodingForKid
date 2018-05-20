using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

#if UNITY_EDITOR
public class ScriptableObjectUtility {
    public static void CreateAsset<T>() where T:ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T>();
        string path = UnityEditor.AssetDatabase.GetAssetPath(UnityEditor.Selection.activeObject);
        if(path=="")
        {
            path = "Assets";
        }
        else if(Path.GetExtension(path)!="")
        {
            path = path.Replace(Path.GetFileName(UnityEditor.AssetDatabase.GetAssetPath(UnityEditor.Selection.activeObject)), "");
        }
        string assetPathAndName = UnityEditor.AssetDatabase.GenerateUniqueAssetPath(path + "/New" + typeof(T).ToString() + ".asset");
        UnityEditor.AssetDatabase.CreateAsset(asset, assetPathAndName);
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.EditorUtility.FocusProjectWindow();
        UnityEditor.Selection.activeObject = asset;
    }
}

#endif
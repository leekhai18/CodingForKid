using UnityEngine;
using MarchingBytes;
using System.Collections;
using System.Collections.Generic;

public class Example : MonoBehaviour {
	
	public string poolName;
	List<GameObject> goList = new List<GameObject>();
	
	public void CreateFromPoolAction() {
		GameObject go = EasyObjectPool.Instance.GetObjectFromPool(poolName,Vector3.zero,Quaternion.identity);
		if(go) {
			goList.Add(go);
		}
	}

	public void ReturnToPoolAction() {
		foreach(GameObject go in goList) {
			EasyObjectPool.Instance.ReturnObjectToPool(go);
		}
		goList.Clear();
	}
}

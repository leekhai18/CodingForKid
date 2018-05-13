using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Item : ScriptableObject {
    
    public int itemID;
    public string itemName;
    public string itemDesc;
    public Sprite itemSprite;
    public Sprite iconSprite;
    public Item(Item ex)
    {
        this.itemID = ex.itemID;
        this.itemName = ex.itemName;
        this.itemDesc = ex.itemDesc;
        this.itemSprite = ex.itemSprite;
        this.iconSprite = ex.iconSprite;
    }
   
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Item : ScriptableObject
{

    public int itemID;
    public string itemName;
    public string VietnameseDesc;
    public Sprite itemSprite;
    public Sprite iconSprite;
    public string EnglishDesc;
    // làm sao tạo đc 1 biến public dùng truy xuất trong script và ko hiện ra giao diện unity - ko thể chỉnh sửa trong giao diện unity
    public string itemDesc;
    private void UpdateAnswer()
    {
        int last;
        last = VietnameseDesc.LastIndexOf("\"");
        itemDesc = VietnameseDesc.Substring(0, last + 1);
    }
    public void Awake()
    {
        UpdateAnswer();
    }
    public Item(Item ex)
    {
        this.itemID = ex.itemID;
        this.itemName = ex.itemName;
        this.VietnameseDesc = ex.VietnameseDesc;
        this.itemSprite = ex.itemSprite;
        this.iconSprite = ex.iconSprite;
        this.itemDesc = ex.itemDesc;

    }


}

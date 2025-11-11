using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SiottltemPrefab : MonoBehaviour
{

    public Image itemlmage;
    public TextMeshProUGUI itemText;

    public void ItemSetting(Sprite itemSprite, string txt)
    {
        itemlmage.sprite = itemSprite;
        itemText.text = txt;
    }
    public void Updatelnventory(Inventory mylnven)
    {
        foreach (var item in mylnven.items)
        {
            switch(item.Key)
            {
                case BlockType.Dirt:

                    break;
                case BlockType.Tile:

                    break;
                case BlockType.Cube:

                    break;
            }
            
            
        }


    }
}

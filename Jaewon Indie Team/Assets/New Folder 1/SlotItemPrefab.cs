using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotItemPrefab : MonoBehaviour
{

    public Image itemlmage;
    public TextMeshProUGUI itemText;
    public BlockType blockType;

    public void ItemSetting(Sprite itemSprite, string txt, BlockType type)
    {
        itemlmage.sprite = itemSprite;
        itemText.text = txt;
        blockType = type;
    }
   
}

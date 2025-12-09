using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotItemPrefab : MonoBehaviour, IPointerClickHandler
{

    public Image itemlmage;
    public TextMeshProUGUI itemText;
    public ItemType blockType;
    public CraftingPanel craftingpanel;

    public void ItemSetting(Sprite itemSprite, string txt, ItemType type)
    {
        itemlmage.sprite = itemSprite;
        itemText.text = txt;
        blockType = type;
    }
   
    void Awake()
    {
        if (!craftingpanel)
            craftingpanel = FindObjectOfType<CraftingPanel>(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right) return;
                if (!craftingpanel) return;

        craftingpanel.AddPlanned(blockType, 1);
    }
}

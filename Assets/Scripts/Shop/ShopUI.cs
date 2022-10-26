using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{

    public bool isbuffDefense;
    public bool isbuffAttack;

    private PShopManager PortionShopManager;

    public Transform Shopportionparent;

    private Portionslot[] itemSlots;

    public int selectIndex = -1;

    public Text nameText;
    //public Text descriptionText;
    public Text priceText;
    void Start()
    {
        PortionShopManager = PShopManager.instance;
        PortionShopManager.selectCallBack += SelectSlot;

        itemSlots = Shopportionparent.GetComponentsInChildren<Portionslot>();

        SetShopSlots();
    }


    private void SetShopSlots()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].SetShopSlot(PortionShopManager.shopItems[i], i);
        }
    }

    public void SelectSlot(int index)
    {
        if (selectIndex == index)
        {
            ResetItemInfoUI();
            return;
        }

        selectIndex = index;

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (selectIndex == i)
            {
                itemSlots[i].SetSelectImage(true);
            }
            else
            {
                itemSlots[i].SetSelectImage(false);
            }
        }

        SetItemInfoUI();
    }
    private void SetItemInfoUI()
    {
        //buyButton.SetActive(true);

        nameText.text = itemSlots[selectIndex].item.name;
        //descriptionText.text = itemSlots[selectIndex].item.itemdescription;
        priceText.text = itemSlots[selectIndex].item.shopPrice.ToString() + " Gold";
    }

    private void ResetItemInfoUI()
    {
        //buyButton.SetActive(false);

        nameText.text = "";
        //descriptionText.text = "";
        priceText.text = "";

        if (selectIndex >= 0)
        {
            itemSlots[selectIndex].SetSelectImage(false);
            selectIndex = -1;
        }
    }
}

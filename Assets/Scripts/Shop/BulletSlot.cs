using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSlot : MonoBehaviour
{
    public GameObject Description;
    public Text descriptionText;

    public Item item;

    public int slotIndex;

    public Sprite iconImage;
    public GameObject selectImage;
    public Text itemname;
    public Text itemprice;

    public void SetShopSlot(Item _item, int index)
    {
        if (_item == null)
            return;

        item = _item;
        slotIndex = index;

        itemname.text = _item.name;
        itemprice.text = _item.shopPrice.ToString() + "G";
        //iconImage.GetComponent<Image>().sprite = item.iconImage;
    }

    public void ResetShopSlot()
    {
        item = null;

        //iconImage.enabled = false;
        //iconImage.GetComponent<Image>().sprite = null;
    }

    public void SelectSlot()
    {
        if (item == null)
            return;

        PShopManager.instance.SelectSlot(slotIndex);
    }
    public void SetSelectImage(bool isSelect)
    {
        selectImage.SetActive(isSelect);
    }

    public void BuyItem()
    {
        float price = item.shopPrice;
        if (PlayerStats.Instance.UseGold(price))
        {
            Inventory.Instance.Add(item);

            StartCoroutine(ShowMessage(item.name + " 아이템 구매 성공"));
        }
        else
        {
            StartCoroutine(ShowMessage("아이템 구매에 실패하였습니다"));
        }
    }

    IEnumerator ShowMessage(string msg)
    {
        Description.SetActive(true);
        descriptionText.text = msg;

        yield return new WaitForSeconds(2f);
        Description.SetActive(false);
        descriptionText.text = "";
    }

}

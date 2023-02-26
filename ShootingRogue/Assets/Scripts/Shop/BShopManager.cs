using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BShopManager : MonoBehaviour
{
    #region Singleton
    public static BShopManager instance;

    private void Awake()
    {
        if (instance != null)
        {

            return;
        }
        instance = this;
        // DontDestroyOnLoad(gameObject);
    }
    #endregion

    //상점에서 판매할 아이템 등록
    public Item[] shopItems;

    public delegate void SeletSlotDelegate(int slot);
    public SeletSlotDelegate bselectCallBack;

    public void SelectSlot(int index)
    {
        if (bselectCallBack != null)
            bselectCallBack(index);
    }

}

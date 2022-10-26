using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PShopManager : MonoBehaviour
{
    #region Singleton
    public static PShopManager instance;

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

    //�������� �Ǹ��� ������ ���
    public Item[] shopItems;

    public delegate void SeletSlotDelegate(int slot);
    public SeletSlotDelegate selectCallBack;

    public void SelectSlot(int index)
    {
        if (selectCallBack != null)
            selectCallBack(index);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one instance of Inventory found!");
            return;
        }

        Instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public delegate void OnremoveItem();
    public OnremoveItem onremoveItemCallback;
    
    public delegate void OnequipItem();
    public OnremoveItem onequipItemCallback;
    public int space = 30;

    public List<Item> items = new List<Item>();

    //들어온 아이템 저장변수
    public Item item;

    public Item removeitem;
    public Item olditem;

    public Item removebuttonitem;

    //inventoryslot에서 어떠한값을 받아왔는지 저장하는 변수 및 inventoryUI에 그 값을 넘겨준다.
    public int index;
    public int equipindex;
    public int bulletindex;
    
    
    public Transform itemsParent;
   
    private void Start()
    {
        
        
    }

    public bool Add(Item _item)
    {
        if (!_item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("공간이 부족합니다");
                return false;
            }
            items.Add(_item);
            item = _item;
            //들어옴 아이템 저장
            
            if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    //Equip했을때 들어오는 메서드
    public void Adds(Item _item)
    {
        
            if (items.Count >= space)
            {
                Debug.Log("공간이 부족합니다");
                
            }
            items.Add(_item);
            olditem = _item;
            //들어옴 아이템 저장
            if (onequipItemCallback != null)
                onequipItemCallback.Invoke();

    }

    //equip.removefromthisinventory에서 온 remove함수
    public void Remove(Item _item)
    {
        removeitem = _item;
        //equipindex = _equipindex;

        items.Remove(_item);
        
    }

    //removebutton의 함수
    public void Removes(Item _item, int _index)
    {
        removebuttonitem = _item;
        index = _index;

        for(int i = 0; i < items.Count; i++)
        {
           items.Remove(_item); //지금은 해당 아이템만 지우는데

           //같은 칸에 들어간 item들을 다 지워줘야함  
           // removeitem.slots[]
        }
        if (onremoveItemCallback != null)
            onremoveItemCallback.Invoke();

    }

    public void Bulletnum(int _bulletnum)
    {
        bulletindex = _bulletnum;
    }
}

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

    //���� ������ ���庯��
    public Item item;

    public Item removeitem;
    public Item olditem;

    public Item removebuttonitem;

    //inventoryslot���� ��Ѱ��� �޾ƿԴ��� �����ϴ� ���� �� inventoryUI�� �� ���� �Ѱ��ش�.
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
                Debug.Log("������ �����մϴ�");
                return false;
            }
            items.Add(_item);
            item = _item;
            //���� ������ ����
            
            if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    //Equip������ ������ �޼���
    public void Adds(Item _item)
    {
        
            if (items.Count >= space)
            {
                Debug.Log("������ �����մϴ�");
                
            }
            items.Add(_item);
            olditem = _item;
            //���� ������ ����
            if (onequipItemCallback != null)
                onequipItemCallback.Invoke();

    }

    //equip.removefromthisinventory���� �� remove�Լ�
    public void Remove(Item _item)
    {
        removeitem = _item;
        //equipindex = _equipindex;

        items.Remove(_item);
        
    }

    //removebutton�� �Լ�
    public void Removes(Item _item, int _index)
    {
        removebuttonitem = _item;
        index = _index;

        for(int i = 0; i < items.Count; i++)
        {
           items.Remove(_item); //������ �ش� �����۸� ����µ�

           //���� ĭ�� �� item���� �� ���������  
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image icon;
    public Button removeButton;
    public int itemcount; // 흭득한 아이템의 개수

    public Item item;

    //inventoryslot 마다 고유의 값을 저장한다.
    public int index;
    public int equipindex;
    public int bulletnum;

    //필요한 컴포넌트
    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;
    public InventorySlot[] slots;
    public Item itemInfo;

    public Transform go_base;
    public Transform itemsParent;

    public GameObject itemTooltip;
    ItemTooltipUI itemTooltipUI;

    
    private void Start()
    {
        itemTooltipUI = itemTooltip.GetComponent<ItemTooltipUI>();
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void Update()
    {
        //if(EquipmentManager.Instance.oldItem == null)
        //{
        //    if(EquipmentManager.Instance.isequip == true)
        //    {
        //        ClearSlot();
        //    }
        //}
    }

    public void AddItem(Item newItem, int _count = 1, int _bulletnem = 0)
    {
        item = newItem;
        itemcount = _count;
        bulletnum = _bulletnem;
        Inventory.Instance.Bulletnum(bulletnum);

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

        if (item.itemType != Item.Itemtype.Equipment)
        {
            //아이템개수창 표시 true
            go_CountImage.SetActive(true);
            text_Count.text = itemcount.ToString();
            Debug.Log("stuff는" + itemcount + "만큼있습니다");
        }
        else
        {
            //아이템개수창 표시 true
           
            go_CountImage.SetActive(false);
        }


    }

    public void AddweaponIcon(Item newItem)
    {
        item = newItem;
        Debug.Log(item);

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

        go_CountImage.SetActive(false);
    }

    public void AddIcon(Item newItem, int _count = 1)
    {
        item = newItem;
        itemcount = _count;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

        go_CountImage.SetActive(true);
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;

        //카운트 이미지 초기화
        go_CountImage.SetActive(false);
        //text_Count.text = "0";

    }

    public void onRemoveButton()
    { 
        
        //onRemove할때 index값을 같이 넘겨줘야함ㄴㅁ
        Inventory.Instance.Removes(item, index);
        Debug.Log("없애는 아이템:" + item);
    }

    public void SetSlotCount(int _count = 1)
    {
        itemcount += _count;
        text_Count.text = itemcount.ToString();  
    }

    public void UseItem()
    {
        if(EquipmentManager.Instance.notequip == false )
        {
            if (item.itemType == Item.Itemtype.Equipment)
            {
                Debug.Log("무기여 잘있거라");
                item.Use();
                ClearSlot();
                
                return;
            }
           
        }
        
        if (item != null)
        {
            if (item.itemType == Item.Itemtype.Equipment)
            {
                //사용하기전에 미리 알려줘야함
                Inventory.Instance.equipindex = equipindex; 
                item.Use();
            }

            else if(item.itemType == Item.Itemtype.HealthPosion)
            {
                SetSlotCount(-1);
                item.Use();
                if(itemcount <= 0)
                {
                    ClearSlot();
                }
            }
            else
            {
                return;
            }

           
            
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            //if (EquipmentManager.Instance.oldItem == null)
            //{
                
                   if(item.itemType == Item.Itemtype.Equipment)
                   {
                        Debug.Log("무기여 잘있거라");
                        ClearSlot();
                   }
                   if(item.itemType == Item.Itemtype.Chemicalbullet || item.itemType == Item.Itemtype.Shotgunbullet || item.itemType == Item.Itemtype.Pistolbullet || item.itemType == Item.Itemtype.Riflebullet)
                   {
                        Debug.Log("응 안눌려~");
                        return;
                   }
                   if(item.itemType == Item.Itemtype.HealthPosion)
                   {
                        Debug.Log("회복템");
                        SetSlotCount(-1);
                   }
            //}
            
        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item != null)
        {
            ShowTooltip(item, go_base.position);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideTooltip();
    }

    private void ShowTooltip(Item _item, Vector3 _pos)
    {
        itemTooltipUI.ShowToolTip(_item, _pos);
    }

    private void HideTooltip()
    {
        go_base.gameObject.SetActive(false);
    }

    public void decreaseBullet(int _minus)
    {
        itemcount -= _minus;
        text_Count.text = itemcount.ToString();  
    }
}




/*
 * public void AddItem(Item newItem, int _count)
    {
        
        //items = newItem;
        if (newItem.itemType == Item.Itemtype.Equipment)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].AddweaponIcon(newItem);
                Debug.Log("무기추가했음");
                
            }
        }

        else
        {
            for (int i = 0; i < slots.Length; i++)
            { 
                if (slots[i].item == null)
                {
                    slots[i].AddIcon(newItem);
                    Debug.Log("stuff 추가됨");
                    return;
                }

                if (slots[i].item != null)

                { //이름이 같다면 숫자를 더해주고

                    if (slots[i].item.name == newItem.name)
                    {
                        slots[i].SetSlotCount(1);
                        Debug.Log("이미 있음");
                       
                    }
            
                }
            }
        
        }
      */
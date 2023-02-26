using UnityEngine;
using UnityEngine.EventSystems;
public class InventoryUI : MonoBehaviour
{
    //inventory slot 인덱스 저장값
    int[] slotnum;

    public GameObject inventoryUI;

    Inventory inventory;

    public Transform itemsParent;
    [HideInInspector]
    public InventorySlot[] slots;
    
    // public InventorySlot slotIndex;
    //inventory slot에서 어떠한 index를 넘겨받았는지 저장하는것

    //아이템 툴팁
    
    public Transform go_base;

    Gun gun;
    //Inventroy.instance.item
    
    
    void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;
        inventory.onremoveItemCallback += removeUI;
        inventory.onequipItemCallback += equipUI;
       

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        //slotIndex = itemsParent.GetComponentsInChildren<InventorySlot>();
        
    }

    void Update()
    {
        //총알을 감소시켜주는 UI
     
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        

    }

    void UpdateUI()
    {
        if (Item.Itemtype.Equipment != Inventory.Instance.item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                { //이름이 같다면 숫자를 더해주고

                    if (slots[i].item.name == Inventory.Instance.item.name)
                    {
                        //만약 이름이 9탄총알 == slot[i].item.name 이면 SetSlotCount()의 수 만큼 더해줌
                        if(slots[i].item.itemType == Item.Itemtype.Pistolbullet)
                        {
                            Debug.Log("숫자를 7을 더한다");
                            slots[i].SetSlotCount(7);
                            Bullet.Instance.remainpistolbullet += 7;
                            return;
                        }
                        if(slots[i].item.itemType == Item.Itemtype.Riflebullet)
                        {
                            slots[i].SetSlotCount(25);
                            Bullet.Instance.remainriflebullet += 25;
                            return;
                        }
                        if (slots[i].item.itemType == Item.Itemtype.Chemicalbullet)
                        {
                            slots[i].SetSlotCount(10);
                            Bullet.Instance.remainchemicalbullet += 10;
                            return;
                        }
                        if (slots[i].item.itemType == Item.Itemtype.Shotgunbullet)
                        {
                            slots[i].SetSlotCount(10);
                            Bullet.Instance.remainshotgunbullet += 10;
                            return;
                        }

                        slots[i].SetSlotCount();

                        //이 slot의 인덱스 값을 받아서 넘겨줘야함
                       // slotnum[i] = i;
                       // Debug.Log("인벤토리 창의" + slotnum[i] + "에 저장이 되었다");

                        Debug.Log("소모품  1추가주문이요");
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                if (Item.Itemtype.Equipment == Inventory.Instance.item.itemType)
                {
                    slots[i].AddweaponIcon(Inventory.Instance.item);
                    Debug.Log("최초무기추가요");
                    return;
                }
                else if(Item.Itemtype.Pistolbullet == Inventory.Instance.item.itemType)
                {
                    slots[i].AddItem(Inventory.Instance.item, 7, 1);
                    Bullet.Instance.remainpistolbullet += 7;
                    return;
                }
               else if(Item.Itemtype.Riflebullet == Inventory.Instance.item.itemType)
                {
                    slots[i].AddItem(Inventory.Instance.item, 25, 2);
                    Bullet.Instance.remainriflebullet += 25;

                }
                else if (Item.Itemtype.Chemicalbullet == Inventory.Instance.item.itemType)
                {
                    slots[i].AddItem(Inventory.Instance.item, 10, 3);
                    Bullet.Instance.remainchemicalbullet += 10;

                }
                else if (Item.Itemtype.Shotgunbullet == Inventory.Instance.item.itemType)
                {
                    slots[i].AddItem(Inventory.Instance.item, 10, 3);
                    Bullet.Instance.remainshotgunbullet += 10;

                }
                else if(Item.Itemtype.HealthPosion == Inventory.Instance.item.itemType)
                {
                    slots[i].AddItem(Inventory.Instance.item, 1);
                }

                else
                        slots[i].AddIcon(Inventory.Instance.item);
                        Debug.Log("소모품 주문이요");

                return;
            }

        }

    }

    public void equipUI()
    {
        Debug.Log("equipUI가 실행되었습니다");
        if (Inventory.Instance.olditem.itemType != Item.Itemtype.Equipment)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < inventory.items.Count)
                {
                    //소모품이고 slot[i]에 이미 아이템이 존재하는경우
                    if (slots[i].item.itemType == Inventory.Instance.olditem.itemType)
                    {
                        slots[i].SetSlotCount();
                        Debug.Log("기존 인벤에 있으면 소모품 숫자 추가");
                        return;
                    }
                    else
                    {
                        slots[i].AddIcon(Inventory.Instance.olditem);
                        Debug.Log("기존 인벤에 없으면 소모품자체를 추가");
                        
                    }
                }

            }
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if(Inventory.Instance.olditem != null) 
            {
                slots[Inventory.Instance.equipindex].ClearSlot();
                slots[Inventory.Instance.equipindex].AddweaponIcon(Inventory.Instance.olditem);
                return;
            }
            slots[Inventory.Instance.equipindex].ClearSlot();
        }
        
    }

    //삭제 버튼 전용 delegate
       
    void removeUI()
    {
        Debug.Log("removeUI 사용");
       
         slots[Inventory.Instance.index].ClearSlot();
         //slots[i].AddItem(inventory.items[i], 0);
         Debug.Log("remove버튼 누르면 삭제");

    }

    public void BulletUI(Item.Itemtype bulletType)
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                // n번째 슬롯에 들어있는 itemType과 매개변수로 받은 itemType이 일치하면
                if (slots[i].item.itemType == bulletType) 
                {
                     // itemType이 일치하는 n번째 슬롯의 총알 제거
                     slots[i].decreaseBullet(1);
                }
            }
              
        }
       
    }

}


/*
 * if (i < inventory.items.Count)
            {
                //slots[i].AddItem(inventory.items[i], 0);
                Debug.Log("착용시 안비워줄래~ 다른거 채울거야~");
            }*/
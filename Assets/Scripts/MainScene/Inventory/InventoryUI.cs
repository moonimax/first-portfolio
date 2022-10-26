using UnityEngine;
using UnityEngine.EventSystems;
public class InventoryUI : MonoBehaviour
{
    //inventory slot �ε��� ���尪
    int[] slotnum;

    public GameObject inventoryUI;

    Inventory inventory;

    public Transform itemsParent;
    [HideInInspector]
    public InventorySlot[] slots;
    
    // public InventorySlot slotIndex;
    //inventory slot���� ��� index�� �Ѱܹ޾Ҵ��� �����ϴ°�

    //������ ����
    
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
        //�Ѿ��� ���ҽ����ִ� UI
     
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
                { //�̸��� ���ٸ� ���ڸ� �����ְ�

                    if (slots[i].item.name == Inventory.Instance.item.name)
                    {
                        //���� �̸��� 9ź�Ѿ� == slot[i].item.name �̸� SetSlotCount()�� �� ��ŭ ������
                        if(slots[i].item.itemType == Item.Itemtype.Pistolbullet)
                        {
                            Debug.Log("���ڸ� 7�� ���Ѵ�");
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

                        //�� slot�� �ε��� ���� �޾Ƽ� �Ѱ������
                       // slotnum[i] = i;
                       // Debug.Log("�κ��丮 â��" + slotnum[i] + "�� ������ �Ǿ���");

                        Debug.Log("�Ҹ�ǰ  1�߰��ֹ��̿�");
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
                    Debug.Log("���ʹ����߰���");
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
                        Debug.Log("�Ҹ�ǰ �ֹ��̿�");

                return;
            }

        }

    }

    public void equipUI()
    {
        Debug.Log("equipUI�� ����Ǿ����ϴ�");
        if (Inventory.Instance.olditem.itemType != Item.Itemtype.Equipment)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < inventory.items.Count)
                {
                    //�Ҹ�ǰ�̰� slot[i]�� �̹� �������� �����ϴ°��
                    if (slots[i].item.itemType == Inventory.Instance.olditem.itemType)
                    {
                        slots[i].SetSlotCount();
                        Debug.Log("���� �κ��� ������ �Ҹ�ǰ ���� �߰�");
                        return;
                    }
                    else
                    {
                        slots[i].AddIcon(Inventory.Instance.olditem);
                        Debug.Log("���� �κ��� ������ �Ҹ�ǰ��ü�� �߰�");
                        
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

    //���� ��ư ���� delegate
       
    void removeUI()
    {
        Debug.Log("removeUI ���");
       
         slots[Inventory.Instance.index].ClearSlot();
         //slots[i].AddItem(inventory.items[i], 0);
         Debug.Log("remove��ư ������ ����");

    }

    public void BulletUI(Item.Itemtype bulletType)
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                // n��° ���Կ� ����ִ� itemType�� �Ű������� ���� itemType�� ��ġ�ϸ�
                if (slots[i].item.itemType == bulletType) 
                {
                     // itemType�� ��ġ�ϴ� n��° ������ �Ѿ� ����
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
                Debug.Log("����� �Ⱥ���ٷ�~ �ٸ��� ä��ž�~");
            }*/
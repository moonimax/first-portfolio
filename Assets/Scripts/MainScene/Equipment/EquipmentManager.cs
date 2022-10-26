using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager Instance;

    void Awake()
    {
        Instance = this;
    }

    #endregion

    Equipment equip;
    PlayerMove playermove;
    Gun gun;

    public MeshRenderer targetMesh;

    public Equipment[] currentEquipment;
    MeshRenderer[] currentMeshes;

    //���� ������Ʈ�� �������ִ� ����
    GameObject[] currentgameobjects;

    //������� ������Ʈ�� ������
    Vector3 usinggameobject;

    public Transform handposition;

    private Vector3 handplace;
    public Vector3 place;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment equipment);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    public InventorySlot inventoryslot;
    public Transform itemsparent;

    Playergun player;

    [HideInInspector]
    public bool notequip = false;
    //����â�� ������� Ȯ��
    public int slotIndex;

    
    public Equipment oldItem;
    private void Start()
    {

        inventory = Inventory.Instance;
       inventoryslot = itemsparent.GetComponentInChildren<InventorySlot>(); 

        int slots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;

        //�ֱ� slot�� �� 1 -> 1 / 2->2 ���� �������ִ� ����
        currentEquipment = new Equipment[slots];
        currentMeshes = new MeshRenderer[slots];
        currentgameobjects = new GameObject[slots];
        equip = new Equipment();
        playermove = GetComponent<PlayerMove>();
        player = GetComponent<Playergun>();
        gun = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Gun>();
    }

    private void Update()
    {
       if(currentEquipment[slotIndex] == null)
        {
            player.Check(0);
        }
    }

    public void Equip(Equipment newItem)
    {
        if(currentEquipment[slotIndex] == null)
        {
            notequip = true;
        }
       
        slotIndex = (int)newItem.equipSlot;


        oldItem = UnEquip(slotIndex);
        
        //Equipment _tempItem;

        //if (oldItem == null)
        //{
        //    inventoryslot.ClearSlot();
        //
        

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
           
            inventory.Adds(oldItem);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        
        currentEquipment[slotIndex] = newItem;


        //MeshRenderer newMesh = Instantiate<MeshRenderer>(newItem.mesh);
        //newMesh.transform.SetParent(handposition);
        //newMesh.transform.SetParent(handposition);
        //currentMeshes[slotIndex] = newMesh;
        //�÷��̾�� ���� �ɾ���
       
        

        GameObject temp = Instantiate(newItem.gameobject, handposition.position, transform.rotation);
        temp.transform.SetParent(handposition.transform);
        //temp.GetComponent<MeshRenderer>
        temp.GetComponent<ItemPickup>().enabled = false;
        currentgameobjects[slotIndex] = temp;
        
        //������ ������Ʈ�� ��ġ���� vector3 place�� ����
        //place = newItem.gameobject.transform.position;

        player.Check(newItem.itemvalue);
        player.Checkweapondmg(newItem.damageModifier);
        playermove.checkAni(newItem.itemvalue);
       
       // Restore(newItem.gameobject.transform.position);


        //�������� intvalue�� üũ���ش��� �ش�������� üũ���ְ� �̰� �ִϸ��̼����� �Ѱܾ���
    }

    void Restore(Vector3 vector)
    {
        usinggameobject = vector;
    } 
    
        
    public Equipment UnEquip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if(currentgameobjects[slotIndex] != null)
            {
                Destroy(currentgameobjects[slotIndex].gameObject);
            }

            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Adds(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
               onEquipmentChanged.Invoke(null, oldItem);
            }
            return oldItem;

        }
        return null;
    }

    public void UnEquipAll()
    {
        for(int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
    }
}

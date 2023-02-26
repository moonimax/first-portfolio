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

    //게임 오브젝트를 저장해주는 수단
    GameObject[] currentgameobjects;

    //사용중인 오브젝트를 저장중
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
    //슬롯창이 비었는지 확인
    public int slotIndex;

    
    public Equipment oldItem;
    private void Start()
    {

        inventory = Inventory.Instance;
       inventoryslot = itemsparent.GetComponentInChildren<InventorySlot>(); 

        int slots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;

        //최근 slot에 들어간 1 -> 1 / 2->2 들어간걸 저장해주는 변수
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
        //플레이어에게 총을 심어줌
       
        

        GameObject temp = Instantiate(newItem.gameobject, handposition.position, transform.rotation);
        temp.transform.SetParent(handposition.transform);
        //temp.GetComponent<MeshRenderer>
        temp.GetComponent<ItemPickup>().enabled = false;
        currentgameobjects[slotIndex] = temp;
        
        //생성된 오브젝트의 위치값을 vector3 place에 저장
        //place = newItem.gameobject.transform.position;

        player.Check(newItem.itemvalue);
        player.Checkweapondmg(newItem.damageModifier);
        playermove.checkAni(newItem.itemvalue);
       
       // Restore(newItem.gameobject.transform.position);


        //아이템의 intvalue를 체크해준다음 해당아이템을 체크해주고 이걸 애니메이션으로 넘겨야함
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

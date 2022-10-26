using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string name = "New Item";
    public Sprite icon = null;
    public Itemtype itemType;
    public bool isDefaultItem = false;
    public string itemdescription;
    
    public int itemnum;
    public float shopPrice;

    //protected PlayerStats playerstat;

    void Start()
    {
        // playerstat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }
    public enum Itemtype
    {
        Equipment,
        Stuff,
        Pistolbullet,
        Riflebullet,
        Chemicalbullet,
        Shotgunbullet,
        HealthPosion
    }

    //기능같은걸 구현하는곳
    public virtual void Use()
    {
        
    }
    
    public void RemoveFromInventory()
    {
        Inventory.Instance.Remove(this);
        
    }
}
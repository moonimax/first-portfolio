using UnityEngine;

[CreateAssetMenu(fileName = "New Usuable", menuName = "Inventory/Usuable")]
public class HealthPosion : Item
{
    //ShopUI shopUI;
    public bool LHP;
    public bool MHP;
    public bool BHP;
    public bool LDef;
    public bool MDef;
    public bool HDef;
    public bool LAtk;
    public bool MAtk;
    public bool HAtk;



    void Start()
    {
        // shopUI = GameObject.FindGameObjectWithTag("ShopUI").GetComponent<ShopUI>();
        //  playerstat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }
    public override void Use()
    {
        //base.Use();
        //playerstat.AddHP(25);

        AddHp();

        AddDef();

        AddAtk();

        Debug.Log("무시하고 아이템사용됨");
        RemoveFromInventory();
    }

    void AddHp()
    {
        if (LHP)
        {
            PlayerStats.Instance.AddHP(20);
        }
        if (MHP)
        {
            PlayerStats.Instance.AddHP(50);

        }
        if (BHP)
        {
            PlayerStats.Instance.AddHP(120);

        }
    }

    void AddDef()
    {
        if (LDef)
        {
            PlayerStats.Instance.def -= 0.01f;
        }


        if (MDef)
        {
            PlayerStats.Instance.def -= 0.03f;
        }

        if (HDef)
        {
            PlayerStats.Instance.def -= 0.05f;
        }

    }

    void AddAtk()
    {
        if (LAtk)
        {
            PlayerStats.Instance.playeratk *= 1.03f;
        }


        if (MAtk)
        {
            PlayerStats.Instance.playeratk *= 1.05f;

        }

        if (HAtk)
        {
            PlayerStats.Instance.playeratk *= 1.07f;

        }

    }
}

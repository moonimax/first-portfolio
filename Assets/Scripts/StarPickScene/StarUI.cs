using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarUI : MonoBehaviour
{
    private StarpickManager starpickManager;
    private Characterpickslot[] itemSlots;
    public Transform StarUIparent;
    void Start()
    {
        starpickManager = StarpickManager.instance;
        //starpickManager.cselectCallBack += SetCharacterslot;
        itemSlots = GetComponentsInChildren<Characterpickslot>();
        SetCharacterslots();
    }

   
   private void SetCharacterslots()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {

            itemSlots[i].SetCharacterslot(starpickManager.staritems[i],i);
        }
    }
}

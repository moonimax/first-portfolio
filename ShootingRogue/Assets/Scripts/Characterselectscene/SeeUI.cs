using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeUI : MonoBehaviour
{
    public Staritem staritem;
    SaveStarpick saveStarpick;
    StarpickManager starpickManager;

    private void Start()
    {
        saveStarpick = SaveStarpick.instance;
        SaveITem();
    }

    public void SaveITem()
    {
        staritem = saveStarpick.staritems;
        //this.gameObject.GetComponent<Transform>() = 
        GameObject.Instantiate(Resources.Load<GameObject>("CObject/C" + staritem.number.ToString()), transform.position, Quaternion.identity);
    }
    
}

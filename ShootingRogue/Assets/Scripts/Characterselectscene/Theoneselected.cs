using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theoneselected : MonoBehaviour
{
    SaveStarpick saveStarpick;
    

    int num;
    void Start()
    {
        saveStarpick = SaveStarpick.instance;
        
    }

    private void Update()
    {
        check();
    }
    public void SelectCharacter()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        SelectedCharater.instance.Getselected(num);
    }

    void check()
    {
       num = saveStarpick.staritems.number;
    }
}

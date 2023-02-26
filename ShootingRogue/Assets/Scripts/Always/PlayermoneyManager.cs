using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayermoneyManager : MonoBehaviour
{
    
    public Text zem;

    void Start()
    {
     
    }

    void Update()
    {
        zem.text = CharacterManager.instance.gem.ToString();
        
    }
}

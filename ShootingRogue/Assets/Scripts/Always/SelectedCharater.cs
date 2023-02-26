using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharater : MonoBehaviour
{
    CharacterManager characterManager;
    public Staritem staritem;
    #region Singleton
    public static SelectedCharater instance;

    private void Awake()
    {
        if (instance != null)
        {

            return;
        }
        instance = this;
        // DontDestroyOnLoad(gameObject);
      
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    void Start()
    {
        characterManager = CharacterManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Getselected(int _int)
    {
        staritem.name = characterManager.characteritems[_int].name;
        staritem.number = characterManager.characteritems[_int].number;
        staritem.atk = characterManager.characteritems[_int].atk;
        staritem.def = characterManager.characteritems[_int].def;
        staritem.life = characterManager.characteritems[_int].life;
    }

    //public void GetselectedCharacterInfo()
    //{
     //   GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().GetselectedCharacterInfo(staritem.atk, staritem.name,staritem.def, staritem.life);
   // }
}

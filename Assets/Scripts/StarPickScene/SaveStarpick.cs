using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//전 starpickup 창에서 버튼을 누르면 그 저장된 슬롯의 친구가 이곳으로 저장됨
public class SaveStarpick : MonoBehaviour
{
    #region Singleton
    public static SaveStarpick instance;

    private void Awake()
    {
        if (instance != null)
        {

            return;
        }
        instance = this;
        
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public Staritem staritems;
   
    public void SaveItem(Staritem staritem)
    {
        staritems = staritem;
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� starpickup â���� ��ư�� ������ �� ����� ������ ģ���� �̰����� �����
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

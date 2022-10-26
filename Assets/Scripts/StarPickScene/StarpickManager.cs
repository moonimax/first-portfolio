using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class StarpickManager : MonoBehaviour
{
    #region Singleton
    public static StarpickManager instance;

    private void Awake()
    {
        if (instance != null)
        {

            return;
        }
        instance = this;
        // DontDestroyOnLoad(gameObject);
        LoadXmlFile(xmlFile);

        DontDestroyOnLoad(gameObject);
    }
    #endregion
    public string xmlFile = "XML/Characteritem";
    //public TextAsset textasset;
    public XmlNodeList allNodeList;

    public List<Staritem> staritems = new List<Staritem>();

    public delegate void SetSlotDelegate(int slot);
    public SetSlotDelegate cselectCallBack;
    void Start()
    {
    }

    private void LoadXmlFile(string fileName)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        allNodeList = xmlDoc.SelectNodes("root/characteritem");

        foreach (XmlNode node in allNodeList)
        {
            Staritem item = new Staritem();
            item.number = int.Parse(node["number"].InnerText);
            item.name = node["name"].InnerText;
            
            
            staritems.Add(item);
        }
    }

    public void giveInfo(Staritem _staritem, int _index)
    {
            staritems[_index].atk = _staritem.atk;
            staritems[_index].life = _staritem.life;
            staritems[_index].def = _staritem.def;

    }

   

}

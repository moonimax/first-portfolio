using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class CharacterManager : MonoBehaviour
{
    #region Singleton
    public static CharacterManager instance;

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
    
    public XmlNodeList allNodeList;

    public List<Staritem> characteritems = new List<Staritem>();

    StarpickManager starpickManager;

    Staritem moment;

    public int Clearlevel = 1;

    public float gem = 300;
    void Start()
    {
        starpickManager = StarpickManager.instance;
        //characteritems[0].piece = 30;
        //처음 시작할때 rank1을 지정해줌
        for(int i = 0; i < characteritems.Count ; i++)
        {
            characteritems[i].atk = characteritems[i].Rank1Atk;
            characteritems[i].def = characteritems[i].Rank1Def;
            characteritems[i].life = characteritems[i].Rank1Life;
        }
       // characteritems[0].piece = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //checkRank();
        giveInfo();

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
            item.Rank1Atk = float.Parse(node["Rank1Atk"].InnerText);
            item.Rank2Atk = float.Parse(node["Rank2Atk"].InnerText);
            item.Rank3Atk = float.Parse(node["Rank3Atk"].InnerText);
            item.Rank1Def = float.Parse(node["Rank1Def"].InnerText);
            item.Rank2Def = float.Parse(node["Rank2Def"].InnerText);
            item.Rank3Def = float.Parse(node["Rank3Def"].InnerText);
            item.Rank1Life = float.Parse(node["Rank1Life"].InnerText);
            item.Rank2Life = float.Parse(node["Rank2Life"].InnerText);
            item.Rank3Life = float.Parse(node["Rank3Life"].InnerText);
            item.Rank1Parts = float.Parse(node["Rank1Parts"].InnerText);
            item.Rank2Parts = float.Parse(node["Rank2Parts"].InnerText);
            item.Rank3Parts = float.Parse(node["Rank3Parts"].InnerText);
            //item.image = Re
            characteritems.Add(item);
        }
    }

    //랭크업을 확인하는 메서드
    
    void giveInfo()
    {
        for(int i = 0; i < characteritems.Count; i++)
        {
            moment = characteritems[i];
            starpickManager.giveInfo(moment, i);
        }
    }

    public void shopAddpp(int _winnerIndex, int _amountIndex)
    {
        characteritems[_winnerIndex].piece += _amountIndex;
    }

}
/*
 * void checkRank()
    {
       for(int i = 0; i < characteritems.Count; i++)
        {
            if (characteritems[i].Rank3 == true)
            {
                characteritems[i].atk = characteritems[i].Rank3Atk;
                characteritems[i].def = characteritems[i].Rank3Def;
                characteritems[i].life = characteritems[i].Rank3Life;
                return;
            }
            
            if (characteritems[i].Rank2 == true)
            {
                characteritems[i].atk = characteritems[i].Rank2Atk;
                characteritems[i].def = characteritems[i].Rank2Def;
                characteritems[i].life = characteritems[i].Rank2Life;
                return;
            }
            if (characteritems[i].Rank1 == true)
            {
                characteritems[i].atk= characteritems[i].Rank1Atk;
                characteritems[i].def= characteritems[i].Rank1Def;
                characteritems[i].life= characteritems[i].Rank1Life;
            }
            
        }
    }
*/
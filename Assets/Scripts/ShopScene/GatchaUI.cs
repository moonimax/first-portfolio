using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class GatchaUI : MonoBehaviour
{
    public string xmlFile = "XML/name_list";
    public string pxmlFile = "gg";

   
    [HideInInspector]
    public Image gatchaimg;

    public XmlNodeList allNodeList;

    public List<Gatchaitem> gatchaItems = new List<Gatchaitem>();

    public List<Possiblegatcha> possiblegatcha = new List<Possiblegatcha>();

    private GatchaState gatchaState;

    public GameObject boxss;
    
    public Animation gatchaanim;
    
    public GameObject Endbutton;
    
    public GameObject edgePanel;
    
    public GameObject ppshow;
    
    public GameObject pptext;

   
    public GameObject ppimage;

    PlayermoneyManager playermoneyManager;
    public GameObject PlayercoinUI;

    //´çÃ·°á°ú
    public int winnerIndex;
    public int amountIndex;
    [HideInInspector]
    public bool stopgatcha;

    void Start()
    {
        LoadXmlFile(xmlFile);
        GetXmlFile(pxmlFile);
        playermoneyManager = PlayercoinUI.GetComponent<PlayermoneyManager>(); 
    }

    
    void Update()
    {
        
    }

   

    public void Pressgatcha()
    {

        if (stopgatcha == true) return;
        //Ã¹¹øÂ° °«Â÷
        winnerIndex = GetGachaItem();
        amountIndex = GetpossibleItem();
        //PlayermoneyManager.instance.gem -= 30;

        if(winnerIndex != 6)
        { //º¸¼®À» 300°³¸¦ ´õÇØÁÜ
            CharacterManager.instance.shopAddpp(winnerIndex, amountIndex);
            gatchaimg.GetComponent<RectTransform>().sizeDelta = new Vector2(288,313);
            gatchaimg.GetComponent<Image>().sprite = Resources.Load<Sprite>("Catchaitem/C" + winnerIndex);
            pptext.GetComponent<Text>().text = amountIndex.ToString();
        }
        else
        {
            //º¸¼®À» 300°³¸¦ Ãß°¡ÇØÁÜ
            CharacterManager.instance.gem += 300;
            gatchaimg.GetComponent<RectTransform>().sizeDelta = new Vector2(288,313);
            gatchaimg.GetComponent<Image>().sprite = Resources.Load<Sprite>("Catchaitem/C" + winnerIndex);
            pptext.GetComponent<Text>().text = "300";
            ppimage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Catchaitem/C" + winnerIndex);
        
        }
        //°¡¿îµ¥ ¹à°Ô ºû³ª¸é¼­ »ÌÈù ¾ÆÀÌÄÜÀ» º¸¿©ÁÜ
       StartCoroutine(box());
    }

    IEnumerator box()
    {
        stopgatcha = true;
        
        boxss.GetComponent<Animation>().Play("Openbox");

        gatchaanim.Play("gatcha1");

        
        yield return new WaitForSeconds(1.6f);
        
        boxss.SetActive(false);
        edgePanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        ppshow.SetActive(true);
        ppshow.GetComponent<Animation>().Play("ppshow");
        
        yield return new WaitForSeconds(2f);

        Endbutton.SetActive(true);
        

    }
    private int GetGachaItem()
    {
        int result = 0;

        //gachaItems
        int total = 0;
        for (int i = 0; i < gatchaItems.Count; i++)
        {
            total += gatchaItems[i].rate;
        }

        int rand = Random.Range(0, total);

        total = 0;
        for (int i = 0; i < gatchaItems.Count; i++)
        {
            total += gatchaItems[i].rate;

            if (rand < total)
            {
                result = i;
                break;
            }
        }

        return result;
    }

    private int GetpossibleItem()
    {
        int result = 0;

        //gachaItems
        float total = 0;
        for (int i = 0; i < possiblegatcha.Count; i++)
        {
            total += possiblegatcha[i].rate;
        }

        float rand = Random.Range(0, total);

        total = 0;
        for (int i = 0; i < possiblegatcha.Count; i++)
        {
            total += possiblegatcha[i].rate;

            if (rand < total)
            {
                result = i +1;
                break;
            }
        }

        return result;
    }
    public enum GatchaState
    {
        Ready,
        FirstGatcha,
        SecondGatch,
        End
    }
    
    private void LoadXmlFile(string fileName)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        allNodeList = xmlDoc.SelectNodes("root/gatchaitem");

        foreach (XmlNode node in allNodeList)
        {
            Gatchaitem item = new Gatchaitem();
            item.number = int.Parse(node["number"].InnerText);
            item.name = node["name"].InnerText;
            item.rate = int.Parse(node["rate"].InnerText);

            gatchaItems.Add(item);
        }
    }

    private void GetXmlFile(string fileName)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        allNodeList = xmlDoc.SelectNodes("root/possible");

        foreach (XmlNode node in allNodeList)
        {
            Possiblegatcha item = new Possiblegatcha();
            item.number = int.Parse(node["number"].InnerText);
           
            item.rate = float.Parse(node["rate"].InnerText);

            possiblegatcha.Add(item);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characterpickslot : MonoBehaviour
{
    public Staritem staritem;
    public int slotIndex;

    public GameObject image;
    public GameObject Rankicon;
    public GameObject Ranknum;

    int num;
    
    public void SetCharacterslot(Staritem _item, int _index)
    {
        staritem = _item;
        slotIndex = _index;
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>("CImage/C" + staritem.number.ToString());

    }

    private void Update()
    {

        //값을 넘겨주는 num
        num = staritem.number;
        if(CharacterManager.instance.characteritems[num].piece <= 0)
        {
            image.GetComponent<Image>().color = new Color(255, 255, 255, 0.2f); 
            GetComponent<Button>().enabled = false;
        }
        else
        {
            image.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
            GetComponent<Button>().enabled = true;
        }

        if (CharacterManager.instance.characteritems[num].Nowrank == 3)
        {
            Rankicon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Rankicon/bronze3");
            Ranknum.GetComponent<Image>().sprite = Resources.Load<Sprite>("Rankicon/3");

            return;
        }   
        if (CharacterManager.instance.characteritems[num].Nowrank == 2)
        {
            Rankicon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Rankicon/bronze2");
            Ranknum.GetComponent<Image>().sprite = Resources.Load<Sprite>("Rankicon/2");
            return;
        }   
    }
    //해당 캐릭터를 누르면!
    public void SaveCharacter()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<SaveStarpick>().SaveItem(staritem);
    }
}

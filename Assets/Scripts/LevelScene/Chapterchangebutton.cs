using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapterchangebutton : MonoBehaviour
{
   
    public GameObject Button1;
    public GameObject Button2;
    
    public GameObject chapter1;
    public GameObject chapter2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goChapter2()
    {
        chapter2.SetActive(true);
        Button2.SetActive(true);
        chapter1.SetActive(false);
        Button1.SetActive(false);
    }

    public void goChapter1()
    {
        Button1.SetActive(true);
        chapter1.SetActive(true);
        chapter2.SetActive(false);
        Button2.SetActive(false);
    }

   
}

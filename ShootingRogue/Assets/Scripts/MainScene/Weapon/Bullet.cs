using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Singleton

    public static Bullet Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one instance of Inventory found!");
            return;
        }

        Instance = this;
    }

    #endregion

    // ³²Àº ÀüÃ¼ Åº¾à±ÇÃÑÃÑ¾Ë
    public float remainpistolbullet;
    //ÇöÀç ÅºÃ¢¿¡ ³²Àº ÃÑ¾Ë°³¼ö
    public float pmagAmmo;
    [HideInInspector]
    public float pmagCapacity = 7f;

    public float remainriflebullet;
    public float rmagAmmo;
    [HideInInspector]
    public float rmagCapacity = 25f;

    public float remainchemicalbullet;
    public float cmagAmmo;
    [HideInInspector]
    public float cmagCapacity = 5f;

    public float remainshotgunbullet;
    public float smagAmmo;
    [HideInInspector]
    public float smagCapacity = 7f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

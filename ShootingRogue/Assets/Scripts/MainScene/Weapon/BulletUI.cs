using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    Bullet bullet;
    Playergun playergun;
    public Text remainbullet;
    public Text totalbullet;

    void Start()
    {
        bullet = GetComponent<Bullet>();
        playergun = GameObject.FindGameObjectWithTag("Player").GetComponent<Playergun>();
    }

    // Update is called once per frame
    void Update()
    {
        Changebullet();
    }

    void Changebullet()
    {
        if (playergun.currentequipvalue == 1)
        {

            // ¿‹ø© √— ππ ¿Ã∑±¿˙∑± «•Ω√
            remainbullet.text = string.Format("{0:00}", bullet.pmagAmmo) + "/";
            totalbullet.text = bullet.remainpistolbullet.ToString();

        }

        if (playergun.currentequipvalue == 2)
        {
            remainbullet.text = string.Format("{0:00}", bullet.rmagAmmo) + "/";
            totalbullet.text = bullet.remainriflebullet.ToString();

        }

        if (playergun.currentequipvalue == 3)
        {
            remainbullet.text = string.Format("{0:00}", bullet.cmagAmmo) + "/";
            totalbullet.text = bullet.remainchemicalbullet.ToString();

        }

        if (playergun.currentequipvalue == 4)
        {
            remainbullet.text = string.Format("{0:00}", bullet.smagAmmo) + "/";
            totalbullet.text = bullet.remainshotgunbullet.ToString();
        }

    }
}

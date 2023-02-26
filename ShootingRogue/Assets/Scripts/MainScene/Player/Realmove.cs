using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Realmove : MonoBehaviour
{
    public Transform spawn;
    public GameObject Blackknight;
    public GameObject Showmessage;
    public GameObject BossUI;

    PlayerMove playermove;
    float x;
    float z;
    float y;
    public float speed;
    float jumpforce = 5;

    public Vector3 movevec;
    void Start()
    {
        playermove = GetComponentInChildren<PlayerMove>();
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Checkscene();
    }

    // Update is called once per frame
    void Update()
    {
        x = playermove.x;
        z = playermove.z;

        speed = playermove.speed;

        Move();
    }

    void Move()
    {
        movevec = new Vector3(x, 0, z).normalized;
        transform.position += movevec * speed * Time.deltaTime;
    }

    public void Jump()
    {
        movevec.y += jumpforce;
        Debug.Log(jumpforce);
    }

    public void BossSpawn()

    {
        GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>().getkey--;
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Knightsong();

        transform.position = spawn.position;
        BossUI.SetActive(true);
        Showmessage.SetActive(false);
        Blackknight.SetActive(true);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnpos : MonoBehaviour
{
    public GameObject showbossmessage;
    public GameObject Blackknight;

    private void OnEnable()
    {
        Blackknight.SetActive(true);
    }

    public void SpawnBoss()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>().getkey--;
        this.gameObject.SetActive(false);
    }
}

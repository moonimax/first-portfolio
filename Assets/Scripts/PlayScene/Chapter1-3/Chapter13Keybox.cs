using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter13Keybox : MonoBehaviour
{
    Animation ani;
    public GameObject key;
    void Start()
    {
        ani = GetComponent<Animation>();
    }

    private void OnEnable()
    {
        //���� �ִϸ��̼� ������ �����Ŀ� Ű�� Ȱ��ȭ��
        //ani.Play("Playtest1-3");
        StartCoroutine(showKey());
        
    }
    
    IEnumerator showKey()
    {
        yield return new WaitForSeconds(0.4f);
        key.SetActive(true);
    }
    void Update()
    {
        
    }
}

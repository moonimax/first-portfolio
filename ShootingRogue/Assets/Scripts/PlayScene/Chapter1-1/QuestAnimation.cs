using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAnimation : MonoBehaviour
{
    Animation animation;
    void Start()
    {
        
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenQuest()
    {
        animation.Play("Openquest");
    }
    public void CloseQuest()
    {
        animation.Play("Closequest");
    }
}

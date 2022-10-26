using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    //Fader �̹���
    public Image img;
    //�ð��� ���� ��� ����
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    //���� �����
    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t >= 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);

            img.color = new Color(0, 0, 0, t);

            yield return 0;
        }
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t <= 1f)
        {
            t += Time.deltaTime;
            img.color = new Color(0, 0, 0, t);
            yield return 0;

        }

        SceneManager.LoadScene(scene);
    }
}

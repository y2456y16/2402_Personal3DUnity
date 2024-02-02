using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public Image image;
    public float flashSpeed;

    private Coroutine coroutine;//�ڷ�ƾ ����, update�� �ƴϴ��� ���� �ð� �������� �ݺ� �����ϴ� ���

    public void Flash()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        image.enabled = true;
        image.color = Color.red;
        coroutine = StartCoroutine(FadeAway());//�ڷ�ƾ ȣ��
    }

    private IEnumerator FadeAway()//�ڷ�ƾ �ʼ� ���
    {
        float startAlpha = 0.3f;
        float a = startAlpha;

        while (a > 0.0f)
        {
            a -= (startAlpha / flashSpeed) * Time.deltaTime;
            image.color = new Color(1.0f, 0.0f, 0.0f, a);
            yield return null;
        }

        image.enabled = false;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button gameStart;
    public Image image;

    public void StartFade()
    {
        StartCoroutine("FadeOut");
        gameStart.gameObject.SetActive(false);
    }

    public void Start()
    {
        gameStart.GetComponent<Button>().onClick.AddListener(StartFade);

    }

    IEnumerator FadeOut()
    {
        float startAlpha = 0;
        while (startAlpha < 1.0f)
        {
            startAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, startAlpha);
        }
        StopCoroutine(FadeOut());
        SceneManager.LoadScene("SampleScene");
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float startAlpha = 1;
        while (startAlpha > 0f)
        {
            startAlpha -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, startAlpha);
        }
    }

}

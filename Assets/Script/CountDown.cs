using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public int countDown = 3;
    public Text countDownText;
    void Start()
    {
        countDownText.gameObject.SetActive(true);
        StartCoroutine(CountDownTimer());
    }

    IEnumerator CountDownTimer()
    {
        while (countDown > 0)
        {
            countDownText.text = countDown.ToString();
            yield return new WaitForSeconds(1);

            countDown--;
        }

        if (countDown == 0)
        {
            Destroy(countDownText);
        }
    }
}

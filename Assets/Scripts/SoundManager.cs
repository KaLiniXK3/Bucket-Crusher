using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip background, fuelBuff, levelFinished,moneyBuff, wheelEarnedMoney;
    static AudioSource audioSource;
    void Start()
    {
        background = Resources.Load<AudioClip>("background");
        wheelEarnedMoney = Resources.Load<AudioClip>("wheelEarnedMoney");
        fuelBuff = Resources.Load<AudioClip>("fuelBuff");
        levelFinished = Resources.Load<AudioClip>("levelFinished");
        moneyBuff = Resources.Load<AudioClip>("moneyBuff");
        audioSource = GetComponent<AudioSource>();
    }

  public static void PlayTheSound(string clip)
    {
        switch (clip)
        {
            case "background":
                audioSource.PlayOneShot(background);
                break;
            case "wheelEarnedMoney":
                audioSource.PlayOneShot(wheelEarnedMoney);
                break;
            case "fuelBuff":
                audioSource.PlayOneShot(fuelBuff);
                break;
           
            case "levelFinished":
                audioSource.PlayOneShot(levelFinished);
                break;
            case "moneyBuff":
                audioSource.PlayOneShot(moneyBuff);
                break;
           
        }

    }

}

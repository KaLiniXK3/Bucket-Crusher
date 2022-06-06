using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fortune : MonoBehaviour
{
    private int randomvalue;
    private float timeInterval;
    private bool coroutineAllowed;
    private int finalAngle;
    public GameObject fortuneCanvas;
    public TextMeshProUGUI winText;
    public GameObject spinTheWheelText;
    public MoneyManager moneyManager;
    public GameManager gameManager;

    private void Start()
    {
        fortuneCanvas.SetActive(true);
        coroutineAllowed = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && coroutineAllowed)
        {
            StartCoroutine(Spin());
            spinTheWheelText.SetActive(false);
        }
    }
    private IEnumerator Spin()
    {
        coroutineAllowed = false;
        randomvalue = Random.Range(70, 100);
        timeInterval = 0.05f;


        for (int i = 0; i < randomvalue; i++)
        {
            transform.Rotate(0, 0, 22.5f);
            if (i > Mathf.RoundToInt(randomvalue * 0.5f))
                timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randomvalue * 0.85f))
                timeInterval = 0.2f;
            yield return new WaitForSeconds(timeInterval);
        }
        if (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
            transform.Rotate(0, 0, 22.5f);
        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);
        Debug.Log(finalAngle);
        switch (finalAngle)
        {
            case 45:
                winText.text = "$500";
                moneyManager.money += 500;
                break;
            case 90:
                winText.text = "$300";
                moneyManager.money += 300;
                break;
            case 135:
                winText.text = "$0";
                moneyManager.money += 0;
                break;
            case 180:
                winText.text = "$1.5k";
                moneyManager.money += 1500;
                break;
            case 225:
                winText.text = "$5";
                moneyManager.money += 5;
                break;
            case 270:
                winText.text = "$75";
                moneyManager.money += 75;
                break;
            case 315:
                winText.text = "$50";
                moneyManager.money += 50;
                break;
            case 360:
                winText.text = "$25";
                moneyManager.money += 25;
                break;
        }
        coroutineAllowed = true;
        yield return new WaitForSeconds(3f);
        gameManager.upgradeHud.SetActive(true);
        gameManager.fortune.SetActive(false);
        winText.text = "";
        fortuneCanvas.SetActive(false);
    }
}

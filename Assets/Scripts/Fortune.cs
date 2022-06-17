using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fortune : MonoBehaviour
{
    public GameObject fortuneCanvas;
    public TextMeshProUGUI winText;
    public GameObject spinTheWheelText;
    public MoneyManager moneyManager;
    public GameManager gameManager;
    public float genSpeed;
    public float subSpeed;
    public bool isSpinning;
    public bool canSpin;
    public bool canStartSpin;

    private void OnEnable()
    {
        fortuneCanvas.SetActive(true);
        canStartSpin = true;
        canSpin = true;
        genSpeed = 1;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && canStartSpin && canSpin)
        {
            spinTheWheelText.SetActive(false);
            spinTheWheel();
        }

        if (isSpinning)
        {
            transform.Rotate(0, 0, genSpeed * Time.deltaTime * 90, Space.World);
            genSpeed -= subSpeed;
        }
        if (genSpeed <= 0)
        {
            genSpeed = 1;
            isSpinning = false;
            canSpin = false;
        }
        if (!isSpinning && transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 45 && !canSpin)
        {

            StartCoroutine(StopText("500", 500));
            SoundManager.PlayTheSound("wheelEarnedMoney");
        }
        if (!isSpinning && transform.eulerAngles.z > 45 && transform.eulerAngles.z <= 90 && !canSpin)
        {
            StartCoroutine(StopText("300", 300));
            SoundManager.PlayTheSound("wheelEarnedMoney");
        }
        if (!isSpinning && transform.eulerAngles.z > 90 && transform.eulerAngles.z <= 135 && !canSpin)
        {
            StartCoroutine(StopText("0", 0));
            SoundManager.PlayTheSound("wheelEarnedMoney");
        }
        if (!isSpinning && transform.eulerAngles.z > 135 && transform.eulerAngles.z <= 180 && !canSpin)
        {
            StartCoroutine(StopText("1.5k", 1500));
            SoundManager.PlayTheSound("wheelEarnedMoney");
        }
        if (!isSpinning && transform.eulerAngles.z > 180 && transform.eulerAngles.z <= 225 && !canSpin)
        {
            StartCoroutine(StopText("5", 5));
            SoundManager.PlayTheSound("wheelEarnedMoney");
        }
        if (!isSpinning && transform.eulerAngles.z > 225 && transform.eulerAngles.z <= 270 && !canSpin)
        {
            StartCoroutine(StopText("75", 75));
            SoundManager.PlayTheSound("wheelEarnedMoney");
        }
        if (!isSpinning && transform.eulerAngles.z > 270 && transform.eulerAngles.z <= 315 && !canSpin)
        {
            StartCoroutine(StopText("50", 50));
            SoundManager.PlayTheSound("wheelEarnedMoney");
        }
        if (!isSpinning && transform.eulerAngles.z > 315 && transform.eulerAngles.z <= 360 && !canSpin)
        {
            StartCoroutine(StopText("25", 25));
            SoundManager.PlayTheSound("wheelEarnedMoney");
        }
    }
    IEnumerator StopText(string text, int amount)
    {
        canSpin = true;
        winText.gameObject.SetActive(true);
        if (amount == 0)
        {
            winText.text = "Unlucky :(";
        }
        else winText.text = "+$" + text;

        moneyManager.SetMoney(amount);
        yield return new WaitForSeconds(0.80f);
        moneyManager.SetMoneyText();
        yield return new WaitForSeconds(1.65f);
        winText.gameObject.SetActive(false);
        winText.text = "";
        gameManager.fortune.SetActive(false);
        fortuneCanvas.SetActive(false);
        spinTheWheelText.SetActive(true);
        gameManager.upgradeHud.SetActive(true);
        gameManager.playButton.SetActive(true);
        gameManager.UpgradeEvent();
        canStartSpin = true;
    }
    public void spinTheWheel()
    {
        isSpinning = true;
        canStartSpin = false;
        genSpeed = Random.Range(4, 7);
        subSpeed = Random.Range(0.006f, 0.012f);
    }

}

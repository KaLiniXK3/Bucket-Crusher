using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wheel : MonoBehaviour
{
    private int randomvalue;
    private float timeInterval;
    private bool coroutineAllowed;
    private int finalAngle;
    //private bool earned;
    public GameObject fortuneCanvas;
    public GameObject gameCanvas;
    public TextMeshProUGUI winText;
    public GameObject spinTheWheelText;
    public MoneyManager mM;


    // Use this for initialization
    private void Start()
    {
        coroutineAllowed = true;
        gameCanvas.SetActive(false);

    }

    // Update is called once per frame
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
        timeInterval = 0.1f;


        for (int i = 0; i < randomvalue; i++)
        {

            transform.Rotate(0, 0, 22.5f);
            if (i > Mathf.RoundToInt(randomvalue * 0.5f))
                timeInterval = 0.2f;
            if (i > Mathf.RoundToInt(randomvalue * 0.85f))
                timeInterval = 0.4f;
            yield return new WaitForSeconds(timeInterval);
        }
        if (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
            transform.Rotate( 0, 0 , 22.5f);
        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);

        switch (finalAngle)
        {
            case 45:
                winText.text = "$500";
                mM.money += 500;
                break;
            case 90:
                winText.text = "$300";
                mM.money += 300;
                break;
            case 135:
                winText.text = "$0";
                mM.money += 0;
                break;
            case 180:
                winText.text = "$1.5k";
                mM.money += 1500;
                break;
            case 225:
                winText.text = "$5";
                mM.money += 5;
                break;
            case 270:
                winText.text = "$75";
                mM.money += 75;
                break;
            case 315:
                winText.text = "$50";
                mM.money += 50;
                break;
            case 360:
                winText.text = "$25";
                mM.money += 25;
                break;


        }
        coroutineAllowed = true;
        //earned = true;
        yield return new WaitForSeconds(3f);
        fortuneCanvas.SetActive(false);
        gameCanvas.SetActive(true);

    }
}

using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] FuelManager fuelManager;
    [SerializeField] GameObject OutOfFuelScreen;
    [SerializeField] TextMeshProUGUI earnedMoneyText;
    [SerializeField] MachineData machineData;
    [SerializeField] GameObject hud;
    [SerializeField] GameObject upgradeHud;
    [SerializeField] GameObject moneyHud;
    [SerializeField] GameObject cam;
    public Vector3 targetStartPos;
    Vector3 cameraStartPos = new Vector3(0, 0.4f, -2.5f);
    Vector3 cameraUpgradePos = new Vector3(-0.37f, 0.55f, -3.30f);
    public GameObject currentMachine;
    bool setCameraUpgradePos;
    public bool setCameraStartPos;
    public GameObject[] cubePrefabs;
    public GameObject currentCube;
    public GameObject parentCube;
    int level = 0;

    private void Start()
    {
        currentCube = parentCube.transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        if (setCameraUpgradePos)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, cameraUpgradePos, Time.deltaTime);
        }
        if (setCameraStartPos)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, cameraStartPos, 0.1f);
        }
    }
    public IEnumerator OutOfFuelEvents()
    {
        OutOfFuelScreen.SetActive(true);
        hud.SetActive(false);
        moneyHud.SetActive(false);
        float money = moneyManager.money;
        if (money >= 1000) earnedMoneyText.text = ((double)money / 1000).ToString("$0.##k");
        else earnedMoneyText.text = "$" + money;
        Destroy(currentCube);
        yield return new WaitForSeconds(1.5f);
        moneyHud.SetActive(true);
        OutOfFuelScreen.SetActive(false);
        fuelManager.SetFuel();
        fuelManager.outOfFuel = false;
        currentCube = Instantiate(cubePrefabs[level], cubePrefabs[level].transform.position, Quaternion.identity, parentCube.transform) as GameObject;

        UpgradeEvent();

    }
    public void UpgradeEvent()
    {
        GameObject currentMachine = machineData.currentMachine;
        IKManager target = currentMachine.GetComponentInChildren<IKManager>();
        target.joystickInput.input.x = 0;
        target.joystickInput.input.y = 0;
        target.joystickInput.handle.anchoredPosition = new Vector3(0, 0, 0);
        GameObject[] bones = target.bones;
        for (int i = 0; i < bones.Length; i++)
        {
            bones[i].transform.rotation = Quaternion.identity;
        }
        target.target.transform.position = targetStartPos;
        setCameraUpgradePos = true;

        upgradeHud.SetActive(true);
    }
    public void SetCameraStartPos()
    {
        setCameraUpgradePos = false;
        setCameraStartPos = true;
    }
}

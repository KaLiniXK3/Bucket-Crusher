using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] FuelManager fuelManager;
    [SerializeField] UpgradeController upgradeController;
    [SerializeField] GameObject OutOfFuelScreen;
    [SerializeField] TextMeshProUGUI earnedMoneyText;
    [SerializeField] MachineData machineData;
    [SerializeField] GameObject hud;
    [SerializeField] LevelProgress levelProgress;
    public GameObject upgradeHud;
    public GameObject playButton;
    public WarningTrigger warningTrigger;
    [SerializeField] GameObject moneyHud;
    [SerializeField] GameObject cam;
    public GameObject fortune;
    public Vector3 targetStartPos;
    Vector3 cameraStartPos = new Vector3(0, 0.4f, -2.70f);
    Vector3 cameraUpgradePos = new Vector3(-0.37f, 0.55f, -3.30f);
    public GameObject currentMachine;
    bool setCameraUpgradePos;
    public bool setCameraStartPos;
    public GameObject[] cubePrefabs;
    public GameObject currentCube;
    public GameObject parentCube;
    int level;
    float startMoney;
    float currentMoney;
    int forFortuneRemainingCount;
    public GameObject buffDebuffSpawner;
    public BuffSpawner buffSpawner;

    private void Start()
    {
        currentCube = parentCube.transform.GetChild(0).gameObject;
        startMoney = moneyManager.money;
        playButton.SetActive(true);
        hud.SetActive(false);
    }
    private void Update()
    {
        if (playButton.activeInHierarchy)
        {
            buffSpawner.CancelInvoke("SpawnRandomBuff");

        }
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
        level = levelProgress.sceneBuildIndex;
        hud.SetActive(false);
        moneyHud.SetActive(false);
        buffDebuffSpawner.SetActive(false);
        playButton.SetActive(false);
        currentMoney = moneyManager.money;
        float earnedMoney = currentMoney - startMoney;
        if (earnedMoney >= 1000) earnedMoneyText.text = ((double)earnedMoney / 1000).ToString("$0.##k");
        else earnedMoneyText.text = "$" + earnedMoney;
        Destroy(currentCube);
        buffSpawner.CancelInvoke("SpawnRandomBuff");
        yield return new WaitForSeconds(1.5f);
        moneyHud.SetActive(true);
        OutOfFuelScreen.SetActive(false);
        buffDebuffSpawner.SetActive(false);
        fuelManager.SetFuel();
        fuelManager.outOfFuel = false;
        currentCube = Instantiate(cubePrefabs[level], cubePrefabs[level].transform.position, Quaternion.identity, parentCube.transform) as GameObject;
        levelProgress.destroyedCubeAmount = 0;
        forFortuneRemainingCount++;
        UpgradeEvent();
    }
    public void UpgradeEvent()
    {
        upgradeController.CheckCanBuy();
        warningTrigger.image.color = new Color(warningTrigger.image.color.r, warningTrigger.image.color.g, warningTrigger.image.color.b, 0.0f);
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
        if (forFortuneRemainingCount == 3)
        {
            fortune.SetActive(true);
            forFortuneRemainingCount = 0;
        }
        else
        {
            upgradeHud.SetActive(true);
            playButton.SetActive(true);
        }
    }
    public void SetCameraStartPos()
    {
        setCameraUpgradePos = false;
        setCameraStartPos = true;
    }
    public void SaveMoney()
    {
        startMoney = moneyManager.money;
    }


}

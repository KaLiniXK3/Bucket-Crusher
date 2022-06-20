using UnityEngine;

public class MachineData : MonoBehaviour
{
    public Vector3 size;
    public int power;
    public float fuel;
    //public int length = 1;

    RotateKnife rotateKnife;
    [SerializeField] FuelManager fuelManager;
    [SerializeField] GameManager gameManager;
    public GameObject[] lengths;
    public GameObject[] knives;
    GameObject currentKnife;
    public GameObject currentMachine;
    private void Start()
    {
        if (currentKnife == null)
        {
            for (int i = 0; i < knives.Length; i++)
            {
                if (knives[i].activeInHierarchy == true)
                {
                    currentKnife = knives[i];
                    currentMachine = lengths[i];
                    gameManager.currentMachine= currentMachine;
                    gameManager.targetStartPos = currentMachine.GetComponentInChildren<IKManager>().transform.position;
                    this.gameObject.transform.parent = currentKnife.transform;
                    break;
                }
            }
        }

        power = 150;
        fuel = 200;
        fuelManager.SetFuel();
        rotateKnife = currentKnife.GetComponent<RotateKnife>();
        size = currentKnife.transform.localScale;
        rotateKnife.power = power;
    }

    public void AddPower(int amount)
    {
        rotateKnife.power += amount;
        power = rotateKnife.power;
    }

    public void AddSize(float amount)
    {
        size = new Vector3(size.x + amount, size.y + amount, size.z + amount);
        currentKnife.transform.localScale = size;
    }

    public void AddFuel(float amount)
    {
        fuel += amount;
        fuelManager.SetFuel();
    }

    public void AddLength(int oldLength, int newLength)
    {
        lengths[oldLength].SetActive(false);
        lengths[newLength].SetActive(true);
        knives[newLength].SetActive(true);
        currentKnife = knives[newLength];
        currentMachine = lengths[newLength];
        this.gameObject.transform.parent = currentKnife.transform;
        // Take New Machine's rotate Knife Reference
        rotateKnife = currentKnife.GetComponent<RotateKnife>();
        knives[oldLength].SetActive(false);
        //Update New Machine Power And Size
        rotateKnife.power = power;
        currentKnife.transform.localScale = size;
    }
}

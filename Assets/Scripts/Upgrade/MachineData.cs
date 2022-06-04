using UnityEngine;

public class MachineData : MonoBehaviour
{
    public Vector3 size;
    public int power;
    public float fuel;
    public int length = 1;

    RotateKnife rotateKnife;
    [SerializeField] FuelManager fuelManager;
    public GameObject[] lengths;
    public GameObject[] knives;
    GameObject currentMachine;

    private void Start()
    {
        if (currentMachine == null)
        {
            for (int i = 0; i < knives.Length; i++)
            {
                if (knives[i].activeInHierarchy == true)
                {
                    currentMachine = knives[i];
                    this.gameObject.transform.parent = currentMachine.transform;
                    break;
                }
            }
        }

        power = 200;
        fuel = 100;
        fuelManager.SetFuel();
        rotateKnife = currentMachine.GetComponent<RotateKnife>();
        size = currentMachine.transform.localScale;
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
        currentMachine.transform.localScale = size;
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
        currentMachine = knives[newLength];
        this.gameObject.transform.parent = currentMachine.transform;
        // Take New Machine's rotate Knife Reference
        rotateKnife = currentMachine.GetComponent<RotateKnife>();
        knives[oldLength].SetActive(false);
        //Update New Machine Power And Size
        rotateKnife.power = power;
        currentMachine.transform.localScale = size;
    }
}

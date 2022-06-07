using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] DestroyControl destroyControl;
    [SerializeField] Slider progressSlider;
    [SerializeField] TextMeshProUGUI levelCountText;
    [SerializeField] GameObject cubesParent;
    [SerializeField] GameObject levelFinishedImage;
    public int destroyedCubeAmount;
    public int sceneBuildIndex;
    int maxCubeAmount;
    int percentAmount;
    private void Start()
    {
        maxCubeAmount = cubesParent.transform.GetChild(0).transform.childCount;
        progressSlider.maxValue = 100;
        sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        levelCountText.text = "Level " + (sceneBuildIndex + 1);
    }

    private void Update()
    {
        percentAmount = destroyedCubeAmount * 100 / maxCubeAmount;
        progressSlider.value = percentAmount;
        if (percentAmount >= 100)
        {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        levelFinishedImage.SetActive(true);
        yield return new WaitForSeconds(1);
        levelFinishedImage.SetActive(false);
        SceneManager.LoadScene(sceneBuildIndex + 1);
    }
}

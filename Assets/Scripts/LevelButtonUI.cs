using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonUI : MonoBehaviour
{
    public int levelIndex; // Set in Inspector

    

    [SerializeField] GameObject[] stars; // Drag 3 star images here
    void Start()
    {

       int starsEarned = PlayerPrefs.GetInt("Level_" + levelIndex + "_Stars", 0);

        ShowStars(starsEarned);
        Debug.Log(starsEarned);
    }

    void ShowStars(int count)
    {
        // ❗ FIRST: turn ALL stars OFF
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(false);
        }

        // turn ON only the correct amount
        for (int i = 0; i < count; i++)
        {
            stars[i].SetActive(true);
        }

       // stars[count - 1].SetActive(true);
    }
}
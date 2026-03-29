using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject[] states;
    [SerializeField] AudioClip sucessSFX;
    [SerializeField] AudioClip failureSFX;
    [SerializeField] int pointIncrease = 3;
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] GameObject OneStar;
    [SerializeField] GameObject TwoStars;
    [SerializeField] GameObject ThreeStars;

    [SerializeField] int currentIndex = 0;
    int points = 0;
    //int animalCount = 0;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DisplayScore();
    }

    public void CorrectAnswer()
    {
        audioSource.PlayOneShot(sucessSFX, 0.7F);
        AddScore();
        NextPannel();
    }

    public void NextPannel()
    {
        if (currentIndex < states.Length - 1)
        {
            states[currentIndex].SetActive(false);
            currentIndex++;
            states[currentIndex].SetActive(true);
        }

        if (currentIndex >= states.Length - 1)
        {
            ShowStars();
        }
    }

    public void ShowStars()
    {
        int starsEarned = 0;

        // ✅ FIXED based on your scoring (points increase by 3)
        if (points <= 3)
        {
            starsEarned = 1;
            OneStar.SetActive(true);
        }
        else if (points <= 6)
        {
            starsEarned = 2;
            TwoStars.SetActive(true);
        }
        else
        {
            starsEarned = 3;
            ThreeStars.SetActive(true);
        }

        Debug.Log("Stars Earned Before Save: " + starsEarned);

        int levelIndex = SceneManager.GetActiveScene().buildIndex;

        int savedStars = PlayerPrefs.GetInt("Level_" + levelIndex + "_Stars", 0);

        if (starsEarned > savedStars)
        {
            PlayerPrefs.SetInt("Level_" + levelIndex + "_Stars", starsEarned);
            PlayerPrefs.Save();

            Debug.Log("Saved Stars: " + starsEarned);
        }
    }

    public void WrongAnswer()
    {
        audioSource.PlayOneShot(failureSFX, 0.7F);
        NextPannel();
    }

    public void AddScore()
    {
        points += pointIncrease;
        DisplayScore();
    }

    private void DisplayScore()
    {
        pointText.text = points.ToString();
    }
}
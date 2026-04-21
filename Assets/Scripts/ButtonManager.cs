using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Security.Cryptography;
using NUnit.Framework;


public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject[] states;
    [SerializeField] AudioClip sucessSFX;
    [SerializeField] AudioClip failureSFX;
    [SerializeField] int pointIncrease = 3;
    [SerializeField] GameObject OneStar;
    [SerializeField] GameObject TwoStars;
    [SerializeField] GameObject ThreeStars;
    [SerializeField] float timeToChangePannelinSec = 1.5f;


    [SerializeField] int currentIndex = 0;
    int points = 0;
    //int animalCount = 0;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void CorrectAnswer()
    {
        audioSource.PlayOneShot(sucessSFX, 0.7F);
        AddScore();
        StartCoroutine(LoadNextPannel(timeToChangePannelinSec));
    }
    IEnumerator LoadNextPannel(float delayinSec)
    {
        yield return new WaitForSeconds(delayinSec);
        NextPannel();
        
    }

    private void NextPannel()
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

        if (points <= 2)
        {
            starsEarned = 1;
            OneStar.SetActive(true);
            SetLastPannelinArrayOff();
        }
        else if (points <= 4)
        {
            starsEarned = 2;
            TwoStars.SetActive(true);
            SetLastPannelinArrayOff();
        }
        else
        {
            starsEarned = 3;
            ThreeStars.SetActive(true);
            SetLastPannelinArrayOff();
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

    private void SetLastPannelinArrayOff()
    {
        states[states.Length - 1].SetActive(false);
    }

    public void WrongAnswer()
    {
        audioSource.PlayOneShot(failureSFX, 0.7F);
        NextPannel();
    }

    public void AddScore()
    {
        points += pointIncrease;
    }

    public void ExitLevel()
    {
        points = 0;
        SceneManager.LoadScene("Levels");
    }
}
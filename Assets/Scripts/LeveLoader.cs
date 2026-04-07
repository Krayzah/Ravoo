using UnityEngine;
using UnityEngine.SceneManagement;

public class LeveLoader : MonoBehaviour
{
    public void LoadLevelByNumber(int levelNumber)
    {
        string levelName = "Level" +" " + levelNumber;
        SceneManager.LoadScene(levelName);
    }

    public void LoadLevelsScene()
    {
        UnlockNewLevel();
        SceneManager.LoadScene("Levels");
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
            {
                PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
                PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
                PlayerPrefs.Save();
            }
    }
}

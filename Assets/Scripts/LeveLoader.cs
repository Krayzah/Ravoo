using UnityEngine;
using UnityEngine.SceneManagement;

public class LeveLoader : MonoBehaviour
{

   /* public static LeveLoader Instance;

    private void Awake()
    {
        // If no instance exists, set this
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists across scenes
        }
        else
        {
            Destroy(gameObject); // prevents duplicates
        }
    }*/

    public void LoadLevelByNumber(int levelNumber)
    {
        string levelName = "Level" +" " + levelNumber;
        SceneManager.LoadScene(levelName);
    }

    public void LoadLevelsScene()
    {
        SceneManager.LoadScene("Levels");
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

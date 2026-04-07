using UnityEngine;

public class LockedLevelManager : MonoBehaviour
{
    public GameObject[] LevelCover;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < LevelCover.Length; i++)
        {
            LevelCover[i].SetActive(true);
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            LevelCover[i].SetActive(false);
        }
    }
}

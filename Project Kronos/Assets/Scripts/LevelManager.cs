

using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    private static string lastLevel;

    public static void SetLastLevel(string level)
    {
        lastLevel = level;
    }

    public static string GetLastLevel()
    {
        return lastLevel;
    }

    public static void ChangeToPreviousLvl()
    {
        SceneManager.LoadScene(lastLevel);
    }
    public static void ChangeToNextLvl()
    {
        int nextLevel = Int32.Parse(Regex.Match(lastLevel, @"\d+").Value) + 1;
        if(nextLevel>8)
            SceneManager.LoadScene("Thanks");
        SceneManager.LoadScene("Level "+nextLevel);
    }
}

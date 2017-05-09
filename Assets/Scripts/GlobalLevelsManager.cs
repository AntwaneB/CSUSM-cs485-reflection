using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalLevelsManager
{
    private static GlobalLevelsManager instance;

    public static GlobalLevelsManager get()
    {
        if (instance == null)
        {
            instance = new GlobalLevelsManager();
        }

        return instance;
    }

    private List<string> levels;
    private int currentLevel;

    private GlobalLevelsManager()
    {
        levels = new List<string>();
        levels.Add("0_tutorial");
        levels.Add("1_enemies");

        currentLevel = 0;
    }

    public void first()
    {
        currentLevel = 0;
        SceneManager.LoadScene(levels[0], LoadSceneMode.Single);
    }

    public void next()
    {
        string sceneToLoad = "end";

        if (currentLevel < levels.Count - 1)
        {
            currentLevel++;
            sceneToLoad = levels[currentLevel];
        }

        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

    public void previous()
    {
        string sceneToLoad = "start";

        if (currentLevel > 0)
        {
            currentLevel--;
            sceneToLoad = levels[currentLevel];
        }

        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

    public void load(string level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    public void reload()
    {
        SceneManager.LoadScene(levels[currentLevel], LoadSceneMode.Single);
    }
}

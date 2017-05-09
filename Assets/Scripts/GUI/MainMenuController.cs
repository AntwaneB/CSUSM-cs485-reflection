using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void play()
    {
        GlobalLevelsManager.get().first();
    }

    public void quit()
    {
        Application.Quit();
    }
}

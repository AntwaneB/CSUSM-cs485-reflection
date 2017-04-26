using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using System;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour, EventListener
{
    private void Start()
    {
        EventManager.get().Subscribe(this, new HashSet<Type>
        {
            typeof(RespawnHitEvent)
        });
    }

    public void OnNotify(EventSystem.Event e)
    {
        if (e is RespawnHitEvent)
        {
            resetLevel();
        }
    }

    private void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}

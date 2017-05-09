using System.Collections;
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
            typeof(RespawnHitEvent),
            typeof(EndReachedEvent),
            typeof(ResetRequestedEvent)
        });

        Time.timeScale = 1;
    }

    public void OnNotify(EventSystem.Event e)
    {
        if (e is RespawnHitEvent)
        {
            resetLevel();
        }
        else if (e is ResetRequestedEvent)
        {
            resetLevel();
        }
        else if (e is EndReachedEvent)
        {
            StartCoroutine(finishLevel());
        }
    }

    private void resetLevel()
    {
        GlobalLevelsManager.get().reload();
    }

    private IEnumerator finishLevel()
    {
        yield return StartCoroutine(animateLevelEnd());

        GlobalLevelsManager.get().next();
    }

    private IEnumerator animateLevelEnd()
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        float animationDuration = 2.0f;

        while (timer < animationDuration)
        {
            Time.timeScale = Mathf.Lerp(1, 0, timer / animationDuration);
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }

        Time.timeScale = 0;
    }
}

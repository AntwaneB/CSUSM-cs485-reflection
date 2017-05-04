using System.Collections;
using System.Collections.Generic;
using EventSystem;
using UnityEngine;
using System;

public class EndChestController : MonoBehaviour, EventListener
{
    private bool alreadyReached;

    private void Start()
    {
        EventManager.get().Subscribe(this, new HashSet<Type>
        {
            typeof(EndReachedEvent)
        });

        alreadyReached = false;
    }

    public void OnNotify(EventSystem.Event e)
    {
        if (e is EndReachedEvent)
        {
            reached();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!alreadyReached)
                StartCoroutine(reached());
        }
    }
    
    private IEnumerator reached()
    {
        if (!alreadyReached)
        {
            alreadyReached = true;

            Animation animation = this.GetComponent<Animation>();
            animation.Play("open");

            yield return new WaitForSeconds(animation.clip.length);

            EventManager.get().Notify(new EndReachedEvent());
        }
    }
}

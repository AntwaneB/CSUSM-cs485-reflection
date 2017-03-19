using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingGameObject : MonoBehaviour
{
    public GameObject objectToFollow;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - objectToFollow.transform.position;
        transform.position = objectToFollow.transform.position + offset;
    }

    private void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlayer : MonoBehaviour {

    public Vector3 offset;

    private GameObject shield;
    private GameObject parent;

    private void Start()
    {
        parent = this.transform.parent.gameObject;
        
    }
    private void Update()
    {
        this.transform.position = parent.transform.position;
        this.transform.localPosition = offset;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNote : MonoBehaviour {

    public float speed = 6.0f;
    public Transform target;

	// Use this for initialization
	void Start () {
	}

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}

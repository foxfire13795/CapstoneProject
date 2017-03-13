using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private float speed = 5.0f;
    public Vector3 target;
    public bool canMove;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        canMove = true;
        target = transform.position;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Obstacle")
            target = transform.position;
        else if (col.tag == "Warp")
        {
            transform.position = col.GetComponent<Warp>().warpPoint.position;
            target = transform.position;
        }
        else if (col.tag == "SceneChange")
        {
            SceneManager.LoadScene(col.GetComponent<ChangeScene>().SceneToChange);
        }
    }
}

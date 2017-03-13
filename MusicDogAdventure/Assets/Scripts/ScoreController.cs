using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    public int score;
    public int numNotes;
    public int successThreshold;
    private SpriteRenderer[] signals = new SpriteRenderer[5];

    void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            signals[i] = GameObject.Find("MissSignal" + (i+1)).GetComponent<SpriteRenderer>();
            signals[i].enabled = false;
        }
    }

    void Start()
    {
        score = numNotes;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Col1")
        {
            Destroy(col.gameObject);
            score--;
            StartCoroutine(showMiss(0));
        }
        else if (col.gameObject.tag == "Col2")
        {
            Destroy(col.gameObject);
            score--;
            StartCoroutine(showMiss(1));
        }
        else if (col.gameObject.tag == "Col3")
        {
            Destroy(col.gameObject);
            score--;
            StartCoroutine(showMiss(2));
        }
        else if (col.gameObject.tag == "Col4")
        {
            Destroy(col.gameObject);
            score--;
            StartCoroutine(showMiss(3));
        }
        else if (col.gameObject.tag == "Col5")
        {
            Destroy(col.gameObject);
            score--;
            StartCoroutine(showMiss(4));
        }
    }

    IEnumerator showMiss(int column)
    {
        signals[column].enabled = true;
        yield return new WaitForSeconds(0.3f);
        signals[column].enabled = false;
    }
}

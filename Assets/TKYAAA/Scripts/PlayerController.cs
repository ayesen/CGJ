using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private TextToMap textToMap;
    private Vector3 spd;
    [SerializeField]
    private float set_spd;
    private int x_pos;
    private int y_pos;
    [SerializeField]
    private float timer;
    public bool crRunning;
    void Start()
    {
        crRunning = false;
        spd = Vector2.zero;
        textToMap = GameObject.Find("TextToMapControl").GetComponent<TextToMap>();
        x_pos = 13;
        y_pos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!crRunning)
        {
            if (Input.GetKeyUp(KeyCode.RightArrow))
                StartCoroutine(PlayerMove(1, 0));
            if (Input.GetKeyUp(KeyCode.DownArrow))
                StartCoroutine(PlayerMove(0, 1));
            if (Input.GetKeyUp(KeyCode.LeftArrow))
                StartCoroutine(PlayerMove(-1, 0));
            if (Input.GetKeyUp(KeyCode.UpArrow))
                StartCoroutine(PlayerMove(0, -1));
        }
    }

    IEnumerator PlayerMove(int x, int y)
    {
        if (textToMap.grid.gridArray[x_pos + x, y_pos + y].tag == "Wall" || textToMap.grid.gridArray[x_pos + x, y_pos + y].tag == "Stop")
        {
            Debug.Log("Stop");
            crRunning = false;
            StopAllCoroutines();
        }
        else
        {
            crRunning = true;
            x_pos += x;
            y_pos += y;
            transform.position = textToMap.grid.gridArray[x_pos, y_pos].transform.position;
            yield return new WaitForSeconds(timer);
            StartCoroutine(PlayerMove(x, y));
        }
    }
}

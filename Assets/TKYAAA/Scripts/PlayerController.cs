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
    [SerializeField]
    private Animator thisAnim;
    public int DirectionNum = 0;

    public bool canUp, canDown, canLeft, canRight;

    void Start()
    {
        canUp = true;
        canDown = true;
        canLeft = true;
        canRight = true;
        crRunning = false;
        spd = Vector2.zero;
        textToMap = GameObject.Find("TextToMapControl").GetComponent<TextToMap>();
        x_pos = (int)transform.position.x;
        y_pos = (int)transform.position.y * -1;
    }

    // Update is called once per frame
    void Update()
    {
        DetectWall();
        PlayerAnimation();
        PlayerControl(); 
    }

    IEnumerator PlayerMove(int x, int y)
    {
        if (textToMap.grid.gridArray[x_pos + x, y_pos + y].tag == "Wall" || textToMap.grid.gridArray[x_pos + x, y_pos + y].tag == "Intersact"
            || textToMap.grid.gridArray[x_pos + x, y_pos + y].tag == "Exit")
        {
            thisAnim.SetInteger("Direction", 0);
            Debug.Log("Stop");
            crRunning = false;
            if (textToMap.grid.gridArray[x_pos + x, y_pos + y].tag == "Intersact" || textToMap.grid.gridArray[x_pos + x, y_pos + y].tag == "Exit")
            {
                x_pos += x;
                y_pos += y;
                transform.position = textToMap.grid.gridArray[x_pos, y_pos].transform.position;
            }
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

    private void NextLevel()
    {
        if(textToMap.grid.gridArray[x_pos, y_pos].tag == "Exit")
        {
            
        }
    }

    private void DetectWall()
    {
        if (textToMap.grid.gridArray[x_pos + 1, y_pos].tag == "Wall")
            canRight = false;
        else
            canRight = true;
        if (textToMap.grid.gridArray[x_pos, y_pos + 1].tag == "Wall")
            canDown = false;
        else
            canDown = true;
        if (textToMap.grid.gridArray[x_pos - 1, y_pos].tag == "Wall")
            canLeft = false;
        else
            canLeft = true;
        if (textToMap.grid.gridArray[x_pos, y_pos - 1].tag == "Wall")
            canUp = false;
        else
            canUp = true;
    }

    private void PlayerAnimation()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && canDown)
        {
            thisAnim.SetInteger("Direction", 1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && canUp)
        {
            thisAnim.SetInteger("Direction", 2);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && canLeft)
        {
            thisAnim.SetInteger("Direction", 3);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && canRight)
        {
            thisAnim.SetInteger("Direction", 4);
        }
    }
    

    private void PlayerControl()
    {
        if (!crRunning)
        {
            if (Input.GetKeyUp(KeyCode.RightArrow) && canRight)
            {
                StartCoroutine(PlayerMove(1, 0));
            }
            if (Input.GetKeyUp(KeyCode.DownArrow) && canDown)
            {
                StartCoroutine(PlayerMove(0, 1));
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) && canLeft)
            {
                StartCoroutine(PlayerMove(-1, 0));
            }
            if (Input.GetKeyUp(KeyCode.UpArrow) && canUp)
            {
                StartCoroutine(PlayerMove(0, -1));
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private TextToMap textToMap;
    private int x_pos;//Player's X position in the grid. If you need, make it public.
    private int y_pos;//Player's Y position in the grid
    [SerializeField]
    private float timer;//Change this to control time between each grid. Default 0.2

    public bool crRunning;//To detect if my walk coroutine is working or not. If not, player's idle.

    [SerializeField]
    private Animator thisAnim;
    public int DirectionNum = 0;

    public bool canUp, canDown, canLeft, canRight;//Coop may need this. Bools to detect walls.

    void Start()
    {
        canUp = true;
        canDown = true;
        canLeft = true;
        canRight = true;
        crRunning = false;
        textToMap = GameObject.Find("TextToMapControl").GetComponent<TextToMap>();
        x_pos = (int)transform.position.x;
        y_pos = (int)transform.position.y * -1;
    }

    // Update is called once per frame
    void Update()
    {
        DetectWall();
        PlayerControl();
        //Set player to the correct position.
        transform.position = textToMap.grid.gridArray[x_pos, y_pos].transform.position;
        PlayerAnimation();
        NextLevel();
    }
    //Coroutine for player to move.
    IEnumerator PlayerMove(int x, int y)
    {
        // Detect the next step to check for wall, intersact or exit.
        if (textToMap.grid.gridArray[x_pos + x, y_pos + y].tag == "Wall" || textToMap.grid.gridArray[x_pos + x, y_pos + y].tag == "Intersact"
            || textToMap.grid.gridArray[x_pos + x, y_pos + y].tag == "Exit")
        {
            thisAnim.SetInteger("Direction", 0);
            crRunning = false;
            //Move one block forward to stand on this block.
            if (textToMap.grid.gridArray[x_pos + x, y_pos + y].tag == "Intersact" || textToMap.grid.gridArray[x_pos + x, y_pos + y].tag == "Exit")
            {
                x_pos += x;
                y_pos += y;
            }
            StopAllCoroutines();
        }
        // If not, move forward.
        else
        {
            crRunning = true;
            x_pos += x;
            y_pos += y;
            yield return new WaitForSeconds(timer);
            StartCoroutine(PlayerMove(x, y));
        }
    }
    // If player steps on the exit block, change to next scene.
    private void NextLevel()
    {
        if(textToMap.grid.gridArray[x_pos, y_pos].tag == "Exit")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Detect if there's wall around.
    private void DetectWall()
    {
        if (!crRunning)
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
    }
    //Ayesen's animation
    private void PlayerAnimation()
    {
        if (!crRunning)
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
    }
    //Don't mess with the controls would be th best.
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

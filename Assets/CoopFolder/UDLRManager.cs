using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class UDLRManager : MonoBehaviour
{
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public GameObject answers;

    public GameObject Player;
    private PlayerController pC;
    private QNA qNA;
    
    //private bool canChoose = true;

    public static int intersection;

    private void Awake()
    {
        pC = Player.GetComponent<PlayerController>();
        qNA = GetComponent<QNA>();
    }

    private void Start()
    {
        intersection = 0;
        ChangeQuestions();   
    }

    private void Update()
    {
        //LevelOneDetect();
        if (!pC.crRunning)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && pC.canUp)
            {
                //do the walk stuff
                //fade out animation

                //load the next question

                //if the animation finished, fade in
                //better call from other script
                if (SceneManager.GetActiveScene().buildIndex != 4)
                    FadeInOrOut();
                //intersection += 1; 

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow)&&pC.canDown)
            {
                if (SceneManager.GetActiveScene().buildIndex != 4)
                    FadeInOrOut();
                //intersection += 1;

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow)&&pC.canLeft)
            {
                if (SceneManager.GetActiveScene().buildIndex != 4)
                    FadeInOrOut();
                if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    intersection += 1;
                    ChangeQuestions();
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)&&pC.canRight)
            {
                if(SceneManager.GetActiveScene().buildIndex != 4)
                    FadeInOrOut();
                if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    intersection += 1;
                    ChangeQuestions();
                }
            }
        }
        
    }

    public void FadeInOrOut()
    {
        up.GetComponent<PanelFader>().Fade();
        down.GetComponent<PanelFader>().Fade();
        left.GetComponent<PanelFader>().Fade();
        right.GetComponent<PanelFader>().Fade();
        answers.GetComponent<PanelFader>().Fade();
    }

    public void ChangeQuestions()//dont know the data structure for the questions
    {
        up.GetComponent<Image>().color = Color.black;
        down.GetComponent<Image>().color = Color.black;
        left.GetComponent<Image>().color = Color.black;
        right.GetComponent<Image>().color = Color.black;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LevelOneDetect();
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            LevelTwoDetect();
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            LevelThreeDetect();
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            LevelFourDetect();
        }
        
        answers.GetComponentInChildren<TextMeshProUGUI>().text = " "+qNA.answers[intersection];
        up.GetComponentInChildren<TextMeshProUGUI>().text = " ↑: " + qNA.questions[intersection].questions[0];
        down.GetComponentInChildren<TextMeshProUGUI>().text = " ↓: "+ qNA.questions[intersection].questions[1];
        left.GetComponentInChildren<TextMeshProUGUI>().text = " ←: "+ qNA.questions[intersection].questions[2];
        right.GetComponentInChildren<TextMeshProUGUI>().text = " →: "+ qNA.questions[intersection].questions[3];
        
        //DisableQuestions();
    }

    public void DisableQuestions()
    {
        if (!pC.canUp)
        {
            up.GetComponentInChildren<TextMeshProUGUI>().text = "";
            up.GetComponent<Image>().color = Color.grey;
        }
        if (!pC.canDown)
        {
            down.GetComponentInChildren<TextMeshProUGUI>().text = "";
            down.GetComponent<Image>().color = Color.grey;
        }
        if (!pC.canLeft)
        {
            left.GetComponentInChildren<TextMeshProUGUI>().text = "";
            left.GetComponent<Image>().color = Color.grey;
        }
        if (!pC.canRight)
        {
            right.GetComponentInChildren<TextMeshProUGUI>().text = "";
            right.GetComponent<Image>().color = Color.grey;
        }
    }

    public void LevelOneDetect()
    {
        Vector2 pos = new Vector2(pC.x_pos, pC.y_pos);
        Debug.Log(pos);
        if (pos.Equals(new Vector2(1, 8)))
        {
            intersection = 0;
        }
        if (pos.Equals(new Vector2(6, 8)))
        {
            intersection = 1;
        }
        if (pos.Equals(new Vector2(6, 13)))
        {
            intersection = 2;
        }
        if (pos.Equals(new Vector2(13, 13)))
        {
            intersection = 3;
        }
        if (pos.Equals(new Vector2(13, 5)))
        {
            intersection = 4;
        }
        if (pos.Equals(new Vector2(17, 5)))
        {
            intersection = 5;
        }
        if (pos.Equals(new Vector2(17, 8)))
        {
            intersection = 6;
        }
        if (pos.Equals(new Vector2(19, 8)))
        {
            intersection = 7;
        }
    }
    
    public void LevelTwoDetect()
    {
        Vector2 pos = new Vector2(pC.x_pos, pC.y_pos);
        Debug.Log(pos);
        if (pos.Equals(new Vector2(20, 15)))
        {
            intersection = 0;
        }
        if (pos.Equals(new Vector2(12, 15)))
        {
            intersection = 1;
        }
        if (pos.Equals(new Vector2(12, 9)))
        {
            intersection = 2;
        }
        if (pos.Equals(new Vector2(17, 9)))
        {
            intersection = 3;
        }
        if (pos.Equals(new Vector2(17, 6)))
        {
            intersection = 4;
        }
        if (pos.Equals(new Vector2(13, 6)))
        {
            intersection = 5;
        }
        if (pos.Equals(new Vector2(13, 4)))
        {
            intersection = 6;
        }
        if (pos.Equals(new Vector2(13, 2)))
        {
            intersection = 7;
        }
        if (pos.Equals(new Vector2(18, 2)))
        {
            intersection = 8;
        }
        if (pos.Equals(new Vector2(4, 4)))
        {
            intersection = 9;
        }
        if (pos.Equals(new Vector2(2, 4)))
        {
            intersection = 10;
        }
        if (pos.Equals(new Vector2(4, 9)))
        {
            intersection = 11;
        }
        if (pos.Equals(new Vector2(9, 9)))
        {
            intersection = 12;
        }
        if (pos.Equals(new Vector2(9, 15)))
        {
            intersection = 13;
        }
        if (pos.Equals(new Vector2(2, 15)))
        {
            intersection = 14;
        }

    }
    
        public void LevelThreeDetect()
    {
        Vector2 pos = new Vector2(pC.x_pos, pC.y_pos);
        Debug.Log(pos);
        if (pos.Equals(new Vector2(9, 1)))
        {
            intersection = 0;
        }
        if (pos.Equals(new Vector2(3, 1)))
        {
            intersection = 1;
        }
        if (pos.Equals(new Vector2(18, 1)))
        {
            intersection = 2;
        }
        if (pos.Equals(new Vector2(22, 1)))
        {
            intersection = 3;
        }
        if (pos.Equals(new Vector2(18, 10)))
        {
            intersection = 4;
        }
        if (pos.Equals(new Vector2(22, 10)))
        {
            intersection = 5;
        }
        if (pos.Equals(new Vector2(22, 17)))
        {
            intersection = 6;
        }
        if (pos.Equals(new Vector2(17, 17)))
        {
            intersection = 7;
        }
        if (pos.Equals(new Vector2(4, 17)))
        {
            intersection = 8;
        }
        if (pos.Equals(new Vector2(4, 22)))
        {
            intersection = 9;
        }
        if (pos.Equals(new Vector2(4, 25)))
        {
            intersection = 10;
        }
        if (pos.Equals(new Vector2(8, 25)))
        {
            intersection = 11;
        }
        if (pos.Equals(new Vector2(12, 25)))
        {
            intersection = 12;
        }
        if (pos.Equals(new Vector2(16, 25)))
        {
            intersection = 13;
        }
        if (pos.Equals(new Vector2(9, 6)))
        {
            intersection = 14;
        }
        if (pos.Equals(new Vector2(9, 10)))
        {
            intersection = 15;
        }
        if (pos.Equals(new Vector2(4, 6)))
        {
            intersection = 16;
        }
        if (pos.Equals(new Vector2(4, 10)))
        {
            intersection = 17;
        }
        if (pos.Equals(new Vector2(4, 14)))
        {
            intersection = 18;
        }
        if (pos.Equals(new Vector2(1, 14)))
        {
            intersection = 19;
        }
    }
        
    public void LevelFourDetect()
    {
        Vector2 pos = new Vector2(pC.x_pos, pC.y_pos);
        Debug.Log(pos);
        if (pos.Equals(new Vector2(12, 1)))
        {
            intersection = 0;
        }
        if (pos.Equals(new Vector2(12, 3)))
        {
            intersection = 1;
        }
        if (pos.Equals(new Vector2(12, 5)))
        {
            intersection = 2;
        }
        if (pos.Equals(new Vector2(12, 7)))
        {
            intersection = 3;
        }
        if (pos.Equals(new Vector2(12, 9)))
        {
            intersection = 4;
        }
        if (pos.Equals(new Vector2(12, 11)))
        {
            intersection = 5;
        }
        if (pos.Equals(new Vector2(12, 13)))
        {
            intersection = 6;
        }
        if (pos.Equals(new Vector2(12, 15)))
        {
            intersection = 7;
        }
        if (pos.Equals(new Vector2(12, 17)))
        {
            intersection = 8;
        }
        if (pos.Equals(new Vector2(12, 19)))
        {
            intersection = 9;
        }
        if (pos.Equals(new Vector2(12, 21)))
        {
            intersection = 10;
        }
        if (pos.Equals(new Vector2(12, 23)))
        {
            intersection = 11;
        }
        if (pos.Equals(new Vector2(12, 25)))
        {
            intersection = 12;
        }
        if (pos.Equals(new Vector2(12, 27)))
        {
            intersection = 13;
        }
        if (pos.Equals(new Vector2(12, 29)))
        {
            intersection = 14;
        }
        if (pos.Equals(new Vector2(12, 31)))
        {
            intersection = 15;
        }
        if (pos.Equals(new Vector2(12, 33)))
        {
            intersection = 16;
        }
        if (pos.Equals(new Vector2(12, 35)))
        {
            intersection = 17;
        }
        if (pos.Equals(new Vector2(12, 37)))
        {
            intersection = 18;
        }
        if (pos.Equals(new Vector2(12, 39)))
        {
            intersection = 19;
        }
        if (pos.Equals(new Vector2(12, 41)))
        {
            intersection = 20;
        }
        if (pos.Equals(new Vector2(12, 43)))
        {
            intersection = 21;
        }
        if (pos.Equals(new Vector2(12, 45)))
        {
            intersection = 22;
        }
    }
    
    
    
}

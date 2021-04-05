using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    
    private bool canChoose = true;

    public static int intersection;

    private void Awake()
    {
        pC = Player.GetComponent<PlayerController>();
        qNA = GetComponent<QNA>();
    }

    private void Start()
    {
        intersection = 0;
        ChangeQuestions(intersection);   
    }

    private void Update()
    {
        if (!pC.crRunning)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && pC.canUp)
            {
                //do the walk stuff
                //fade out animation
                
                //load the next question
               
                //if the animation finished, fade in
                //better call from other script
                FadeInOrOut();
                intersection += 1; 
                
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow)&&pC.canDown)
            {
                FadeInOrOut();
                intersection += 1; 
                
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow)&&pC.canLeft)
            {
                FadeInOrOut();
                intersection += 1; 
                
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)&&pC.canRight)
            {
                FadeInOrOut();
                intersection += 1; 
                
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

    public void ChangeQuestions(int x)//dont know the data structure for the questions
    {
        up.GetComponent<Image>().color = Color.black;
        down.GetComponent<Image>().color = Color.black;
        left.GetComponent<Image>().color = Color.black;
        right.GetComponent<Image>().color = Color.black;

        answers.GetComponentInChildren<TextMeshProUGUI>().text = " "+qNA.answers[x];
        up.GetComponentInChildren<TextMeshProUGUI>().text = " ↑: " + qNA.questions[x].questions[0];
        down.GetComponentInChildren<TextMeshProUGUI>().text = " ↓: "+ qNA.questions[x].questions[1];
        left.GetComponentInChildren<TextMeshProUGUI>().text = " ←: "+ qNA.questions[x].questions[2];
        right.GetComponentInChildren<TextMeshProUGUI>().text = " →: "+ qNA.questions[x].questions[3];
        
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
    
    
}

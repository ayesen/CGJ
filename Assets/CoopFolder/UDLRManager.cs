using System;
using System.Collections;
using System.Collections.Generic;
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
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //do the walk stuff
                //fade out animation
                
                //load the next question
               
                //if the animation finished, fade in
                //better call from other script
                FadeInOrOut();
                intersection += 1; 
                
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                FadeInOrOut();
                intersection += 1; 
                
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                FadeInOrOut();
                intersection += 1; 
                
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
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
        answers.GetComponentInChildren<TextMeshProUGUI>().text = " "+qNA.answers[x];
        up.GetComponentInChildren<TextMeshProUGUI>().text = " ↑: " + qNA.questions[x].questions[0];
        down.GetComponentInChildren<TextMeshProUGUI>().text = " ↓: "+ qNA.questions[x].questions[1];
        left.GetComponentInChildren<TextMeshProUGUI>().text = " ←: "+ qNA.questions[x].questions[2];
        right.GetComponentInChildren<TextMeshProUGUI>().text = " →: "+ qNA.questions[x].questions[3];
    }
    
    
}

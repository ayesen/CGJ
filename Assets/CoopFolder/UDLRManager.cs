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
    
    
    
    private bool canChoose = true;
    private void Update()
    {
        if (canChoose)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //do the walk stuff
                //fade out animation
                FadeInOrOut();
                //load the next question
                ChangeQuestions();
                //if the animation finished, fade in
                //better call from other script

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                FadeInOrOut();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                FadeInOrOut();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                FadeInOrOut();
            }
        }
    }

    void FadeInOrOut()
    {
        up.GetComponent<PanelFader>().Fade();
        down.GetComponent<PanelFader>().Fade();
        left.GetComponent<PanelFader>().Fade();
        right.GetComponent<PanelFader>().Fade();
    }

    void ChangeQuestions()//dont know the data structure for the questions
    {
        up.GetComponentInChildren<TextMeshProUGUI>().text = "↑: ";
        down.GetComponentInChildren<TextMeshProUGUI>().text = "↓: ";
        left.GetComponentInChildren<TextMeshProUGUI>().text = "←: ";
        right.GetComponentInChildren<TextMeshProUGUI>().text = "←: ";
    }
    
    
}

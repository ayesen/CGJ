using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Questions
{
    public string[] questions;
}

public class QNA : MonoBehaviour
{
    [Header("QUESTIONS: 0: up 1: down 2: left 3: right")]
    public Questions[] questions;
    [Header("ANSWERS")]
    public String[] answers;
}

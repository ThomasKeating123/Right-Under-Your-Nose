using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public int taskID;
    public string[] taskObjectives;
    public string introduction;

    public bool isCompleted;

    public Task(int taskid, string[] objectives, string intro)
    {
        taskID = taskid;
        taskObjectives = objectives;
        introduction = intro;
    }

    public void CompleteTask()
    {
        isCompleted = true;
    }
}

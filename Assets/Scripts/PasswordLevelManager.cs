using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PasswordLevelManager : MonoBehaviour
{
    public TMP_Text objectiveText;
    public TMP_Text successText;

    public List<Task> tasks = new List<Task>();
    public int taskIndex = 1;

    public GameObject introductionPanel;
    public GameObject task1Panel;
    public GameObject task2Panel;
    public GameObject objectivesPanel;
    public GameObject sucessPanel;

    //Task 1
    public TMP_Text usernameText;
    public TMP_Text passwordHintText;
    public TMP_InputField passwordInput;
    public GameObject task1TaskPanel;
    public GameObject task1Intro;
    public TMP_Text task1IntroText;

    private List<User> users = new List<User>();
    private User chosenUser;
    //Identifier 1
    public GameObject identifier1Panel;
    public TMP_Text identifier1Text;
    public TMP_Text identifier1EnlargedText;
    //Identifier 2
    public GameObject identifier2;
    public GameObject identifier2Panel;
    public TMP_Text identifier2Text;
    public TMP_Text identifier2EnlargedText;


    //Task 2
    public GameObject task2TaskPanel;
    public GameObject task2Intro;
    public TMP_Text task2IntroText;
    public TMP_InputField passwordCheckerInput;
    public Slider passwordStrength;
    public Image sliderFill;

    private PasswordChecker passwordChecker = new PasswordChecker();
    private string previousInput = "";
    private int passwordScore = 0;

    void Start()
    {
        tasks.Add(new Task(1, new string[] {
            "Use Problem Solving skills to locate elements related to the user's password.", "Through the use of trial and error and the password hint determined what the password is."},
            "During this task you will have to locate, identify, and piece together elements from around the scene to identify the user’s password and gain access to the account."));

        tasks.Add(new Task(2, new string[] {
            "Identify the different elements which make up a strong password.", "Use different characters to create a strong password which is harder to crack."},
            "During this task you will have to identify what makes a password strong and produce a strong password."));

        foreach (Task tsk in tasks)
        {
            if(tsk.taskID == taskIndex)
            {
                string objectives = string.Join("\n\n", tsk.taskObjectives);

                objectiveText.text = objectives;
            }
        }

        Task1Setup();
    }

    public void UpdateObjectives()
    {
        foreach (Task tsk in tasks)
        {
            if (tsk.taskID == taskIndex)
            {
                string objectives = string.Join("\n\n", tsk.taskObjectives);

                objectiveText.text = objectives;
            }
        }
    }

    public void LoadTask1()
    {
        introductionPanel.SetActive(false);
        task1Panel.SetActive(true);
        objectivesPanel.SetActive(true);
        sucessPanel.SetActive(true);
    }

    public void LoadTask2()
    {
        task1Panel.SetActive(false);
        task2Panel.SetActive(true);
    }

    public void Task1Setup()
    {
        task1IntroText.text = GetTask(taskIndex).introduction;

        users.Add(new User("John Smith", "Mary1983", "Wife+Daughter", new string[] {"Mary Jones", "1983"}));
        users.Add(new User("Mary Jones", "alfie", "Dog", new string[] {"Alfie"}));
        users.Add(new User("Jane Doe", "john17", "Father+Son", new string[] {"John Smith", "2017"}));

        chosenUser = users[Random.Range(0, users.Count)];

        usernameText.text = chosenUser.username;
        passwordHintText.text = "Password Hint: \n" + chosenUser.hint;


        identifier1Text.text = chosenUser.hintElements[0] + " appointment is on the 16th April";
        identifier1EnlargedText.text = chosenUser.hintElements[0] + " appointment is on the 16th April";

        if (chosenUser.hintElements.Length == 2)
        {
            identifier2.SetActive(true);

            identifier2Text.text = chosenUser.hintElements[1];
            identifier2EnlargedText.text = chosenUser.hintElements[1];
            
        }
        else
        {
            identifier2.SetActive(false);
        }
    }

    public void Task2Setup()
    {
        task2IntroText.text = GetTask(taskIndex).introduction;

        passwordStrength.maxValue = passwordChecker.maxScore;
        passwordStrength.value = 0;
    }

    public void CheckPassword()
    {
        int score = 0;
        successText.text = "";

        if (passwordChecker.HasWhitespce(passwordCheckerInput.text) == false && passwordChecker.HasUnwantedChar(passwordCheckerInput.text) == false)
        {
            if (passwordCheckerInput.text != previousInput)
            {
                score = passwordChecker.CheckPassword(passwordCheckerInput.text);
                passwordStrength.value = score;

                if (score <= 4)
                {
                    sliderFill.color = Color.red;
                }
                else if (score == 5)
                {
                    sliderFill.color = Color.yellow;
                }
                else if (score > 5)
                {
                    sliderFill.color = Color.green;
                }
            }
        }
        else
        {
            successText.text = "The password contains unsuitable character or spaces.";
            passwordStrength.value = 0;
        }

        passwordScore = score;
    }
    
    public void Login()
    {
        StartCoroutine(LoginCoroutine()); 
    }

    IEnumerator LoginCoroutine()
    {
        if (passwordInput.text == chosenUser.password)
        {
            if (tasks[taskIndex].isCompleted == false)
            {
                GetTask(taskIndex).CompleteTask();
                successText.text = "Task " + taskIndex + " has been completed, the next task will start shortly.";
                yield return new WaitForSeconds(5);

                successText.text = "";
                taskIndex++;
                UpdateObjectives();
                Task2Setup();
                LoadTask2();
            }
        }
        else
        {
            successText.text = "Incorrect password or invalid characters.";
            yield return new WaitForSeconds(5);
            successText.text = "";
        }
    }

    public Task GetTask(int taskIdx)
    {
        foreach (Task tsk in tasks)
        {
            if (tsk.taskID == taskIdx)
            {
                return tsk;
            }
        }

        return null;
    }

    public void Continue()
    {
        LoadTask1();
    }

    public void CloseIdentifier1()
    {
        identifier1Panel.SetActive(false);
    }

    public void OpenIdentifier1()
    {
        identifier1Panel.SetActive(true);
    }

    public void CloseIdentifier2()
    {
        identifier2Panel.SetActive(false);
    }

    public void OpenIdentifier2()
    {
        identifier2Panel.SetActive(
            true);
    }

    public void Task1OK()
    {
        task1Intro.SetActive(false);
        task1TaskPanel.SetActive(true);
    }

    public void Task2OK()
    {
        task2Intro.SetActive(false);
        task2TaskPanel.SetActive(true);
    }

    public void Submit()
    {
        if (passwordScore == passwordChecker.maxScore)
        {
            StartCoroutine(SubmitCoroutine());
        }
    }

    IEnumerator SubmitCoroutine()
    {
        successText.text = "Task " + taskIndex + " has been completed, you have created a strong password. You have completed the level.";
        yield return new WaitForSeconds(5);
        successText.text = "";

        SceneManager.LoadScene("Menu");
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string category;
        public string question;
        public string a;
        public string b;
        public string c;
        public string d;
        public string correct;
    }

    public Question[] questions;
    private int score = 0; // Track the score

    public TMP_Text questionText;
    public TMP_Text answerAText;
    public TMP_Text answerBText;
    public TMP_Text answerCText;
    public TMP_Text answerDText;
    public TMP_Text timerText;
    public Button submitButton;
    public TMP_Text health;
    private string selectedAnswer;

    private float totalQuizTime = 60f; // Total time for the quiz
    private bool quizActive = true; // Track if the quiz is ongoing

    private void Start()
    {
        health.text = $"{GameManager.Instance.gameHealth}/4";
        // Initialize the questions
        questions = new Question[]
        {
            new Question { category = "geo", question = "What is the capital of France?", a = "Berlin", b = "Madrid", c = "Paris", d = "Rome", correct = "Paris" },
            new Question { category = "math", question = "What is 2 + 2?", a = "3", b = "4", c = "5", d = "6", correct = "4" },
            new Question { category = "math", question = "What is the largest planet in our Solar System?", a = "Earth", b = "Mars", c = "Jupiter", d = "Saturn", correct = "Jupiter" },
            new Question { category = "idk", question = "What element does 'O' represent on the periodic table?", a = "Osmium", b = "Oxygen", c = "Gold", d = "Silver", correct = "Silver" }
        };

        answerAText.transform.parent.GetComponent<Button>().onClick.AddListener(() => SelectAnswer(answerAText.text));
        answerBText.transform.parent.GetComponent<Button>().onClick.AddListener(() => SelectAnswer(answerBText.text));
        answerCText.transform.parent.GetComponent<Button>().onClick.AddListener(() => SelectAnswer(answerCText.text));
        answerDText.transform.parent.GetComponent<Button>().onClick.AddListener(() => SelectAnswer(answerDText.text));

        //StartCoroutine(StartTimer(totalQuizTime));
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {
        if (GameManager.Instance.currentQuestionIndex < questions.Length)
        {
            Question currentQuestion = questions[GameManager.Instance.currentQuestionIndex];

            questionText.text = currentQuestion.question;
            answerAText.text = currentQuestion.a;
            answerBText.text = currentQuestion.b;
            answerCText.text = currentQuestion.c;
            answerDText.text = currentQuestion.d;
        }
        else
        {
            EndQuiz(); // End the quiz if all questions are completed
        }
    }

    /*private IEnumerator StartTimer(float duration)
    {
        float timeRemaining = duration;
        while (timeRemaining > 0 && quizActive)
        {
            timerText.text = $"Time Left: {timeRemaining:F1}s"; // Show timer in seconds
            timeRemaining -= Time.deltaTime;
            yield return null;
        }

        if (quizActive)
        {
            GameManager.Instance.gameHealth=0;
            timerText.text = "Time's up!";
            EndQuiz();
        }
    }*/

    private void SelectAnswer(string answer)
    {
        selectedAnswer = answer; // Update selected answer
        ValidateAnswer();
    }

    private void ValidateAnswer()
    {
        // Validate selected answer
        if (GameManager.Instance.currentQuestionIndex < questions.Length)
        {
            Question currentQuestion = questions[GameManager.Instance.currentQuestionIndex];

            if (selectedAnswer == currentQuestion.correct)
            {
                Debug.Log("Correct Answer!");
            }
            else
            {
                GameManager.Instance.gameHealth--;
                health.text = $"{GameManager.Instance.gameHealth}/4";
                if (GameManager.Instance.gameHealth == 0)
                {
                    Application.Quit();
                }
            }

            GameManager.Instance.currentQuestionIndex++;
            DisplayQuestion();
        }
    }

private void EndQuiz()
    {
        quizActive = false; 
    }
}

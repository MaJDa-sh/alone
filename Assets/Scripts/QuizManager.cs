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
            new Question
            {
                category = "Logic",
                question = "Imagine a triangle that contains four consecutive triangles. How many triangles do we have in total?",
                a = "8",
                b = "5",
                c = "6",
                correct = "5"
            },
        new Question
        {
            category = "Logic",
            question = " 4, 9, 16, 25, 36... What number will be next?",
            a = "49",
            b = "44",
            c = "54",
            correct = "49"
        },
        new Question
        {
            category = "Logic",
            question = "If I eat a quarter of a dozen cookies, how many will I have left?",
            a = "3",
            b = "4",
            c = "9",
            correct = "9"
        },
        new Question
        {
            category = "Logic",
            question = "What has keys but can't open locks?",
            a = "a piano",
            b = " a map",
            c = "a computer",
            correct = "a piano"
        },
        new Question
        {
            category = "Logic",
            question = "I speak without a mouth and hear without ears. What am I?",
            a = "a ghost",
            b = "an echo",
            c = "a dream",
            correct = "an echo"
        },
        new Question
        {
            category = "Logic",
            question = "What has to be broken before you can use it?",
            a = "a promise",
            b = "an egg",
            c = " a code",
            correct = "an egg"
        },new Question
        {
            category = "Logic",
            question = "What can travel around the world while staying in a corner?",
            a = "a stamp",
            b = "a postcard",
            c = "a shadow",
            correct = "a stamp"
        },new Question
        {
            category = "Logic",
            question = "What has many teeth but cannot bite?",
            a = "a comb",
            b = " a saw",
            c = "a zipper",
            correct = "a comb"
        },new Question
        {
            category = "Logic",
            question = "What can you catch but not throw?",
            a = "a cold",
            b = "a ball",
            c = "a fish",
            correct = "a cold"
        },new Question
        {
            category = "Logic",
            question = " What has a heart that doesn’t beat?",
            a = "a tree",
            b = "an artichoke",
            c = "a computer",
            correct = "an artichoke"
        },new Question
        {
            category = "Logic",
            question = "What runs all around a backyard, yet never moves?",
            a = "a fence",
            b = "a garden hose",
            c = "a tree",
            correct = "a fence"
        },new Question
        {
            category = "Logic",
            question = "What can be broken, but never held?",
            a = "a promise",
            b = "a toy",
            c = "a glass",
            correct = "a promise"
        },new Question
        {
            category = "Logic",
            question = "What goes up but never comes down?",
            a = "age",
            b = "smoke ",
            c = "a balloon",
            correct = "age"
        },new Question
        {
            category = "Logic",
            question = "What has one eye but can’t see",
            a = "a needle ",
            b = "a cyclops",
            c = "a storm",
            correct = "a needle "
        },new Question
        {
            category = "Logic",
            question = "What begins with T, ends with T, and has T in it?",
            a = "a teapot ",
            b = "a tent",
            c = " a train",
            correct = "a teapot "
        },new Question
        {
            category = "Logic",
            question = "What is full of holes but still holds water?",
            a = "a bucket ",
            b = "a net",
            c = " a sponge",
            correct = " a sponge"
        },new Question
        {
            category = "Logic",
            question = "What can fill a room but takes up no space?",
            a = " light",
            b = "air ",
            c = "sound",
            correct = " light"
        },new Question
        {
            category = "Logic",
            question = " I am taken from a mine, and shut up in a wooden case, from which I am never released. What am I?",
            a = "a diamond",
            b = "a pencil lead",
            c = "necklace",
            correct = "a pencil lead"
        },new Question
        {
            category = "Logic",
            question = "What has words but never speaks?",
            a = "a book",
            b = "a computer",
            c = "a painting",
            correct = "a book"
        },new Question
        {
            category = "Logic",
            question = "What can go up and down but never moves?",
            a = "a ladder",
            b = "a yo-yo",
            c = "a staircase",
            correct = "a staircase"
        },new Question
        {
            category = "Logic",
            question = "What has a neck but no head?",
            a = "a bottle",
            b = "a shirt",
            c = "a tree",
            correct = "a bottle"
        },new Question
        {
            category = "Logic",
            question = "What is always in front of you but can’t be seen?",
            a = "the future",
            b = "the air",
            c = "a shadow",
            correct = "the future"
        },new Question
        {
            category = "Logic",
            question = "What has a thumb and four fingers but is not alive?",
            a = "a glove ",
            b = "a hand",
            c = "a puppet",
            correct = "a glove "
        },new Question
        {
            category = "Logic",
            question = "What can you hold in your left hand but not in your right?",
            a = "your right elbow",
            b = "a pen",
            c = "a phone",
            correct = "your right elbow"
        },new Question
        {
            category = "Logic",
            question = "What begins with 'P' and ends with 'E' and has thousands of letters?",
            a = "a post office",
            b = "a page",
            c = " a package",
            correct = "a post office"
        },new Question
        {
            category = "Halloween",
            question = "What vegetable is traditionally carved for Halloween?",
            a = "Carrot",
            b = "Pumpkin",
            c = "Potato",
            correct = "Pumpkin"
        },new Question
        {
            category = "Logic",
            question = "What do children typically say when they go trick-or-treating?",
            a = "Happy Halloween",
            b = "Trick or treat",
            c = "Scare me",
            correct = "Trick or treat"
        },new Question
        {
            category = "Halloween",
            question = "Which animal is commonly associated with Halloween?",
            a = "Dog",
            b = "Cat",
            c = "Owl",
            correct = "Cat"
        },new Question
        {
            category = "Halloween",
            question = "What do you call a carved pumpkin with a light inside?",
            a = "Pumpkin pie",
            b = "Jack-o'-lantern",
            c = "Pumpkin spice",
            correct = "Jack-o'-lantern"
        },new Question
        {
            category = "Halloween",
            question = "In which country did Halloween originate?",
            a = "United States",
            b = "Ireland",
            c = "Mexico",
            correct = "Ireland"
        },new Question
        {
            category = "Halloween",
            question = "What does the word “Halloween” mean?",
            a = "Holy evening",
            b = "Happy evening",
            c = "Harvest evening",
            correct = "Holy evening"
        },new Question
        {
            category = "Halloween",
            question = "What is a common Halloween decoration?",
            a = "Christmas tree",
            b = "Spider web",
            c = "Flowers",
            correct = "Spider web"
        },new Question
        {
            category = "Halloween",
            question = "What do ghosts often say?",
            a = "Boo!",
            b = "Help!",
            c = "Hi!",
            correct = "Boo!"
        },new Question
        {
            category = "Halloween",
            question = "Which creature is said to transform during a full moon?",
            a = "Vampire",
            b = "Werewolf",
            c = "Zombie",
            correct = "Werewolf"
        },new Question
        {
            category = "Halloween",
            question = "What is the traditional Halloween game involving apples?",
            a = "Apple toss",
            b = "Bobbing for apples",
            c = "Apple picking",
            correct = "Bobbing for apples"
        },new Question
        {
            category = "Halloween",
            question = "Which horror movie features a killer named Michael Myers?",
            a = "Friday the 13th",
            b = "Halloween",
            c = "Scream",
            correct = "Halloween"
        },new Question
        {
            category = "Halloween",
            question = "What is a popular Halloween candy?",
            a = "Chocolate bars",
            b = "Candy corn",
            c = "Gummy bears",
            correct = "c"
        },new Question
        {
            category = "Halloween",
            question = "WWhat do witches commonly ride on?",
            a = "Broomsticks",
            b = "Bicycles",
            c = "Cars",
            correct = "Broomsticks"
        },
        new Question
        {
            category = "Halloween",
            question = "What color is associated with ghosts?",
            a = "Green",
            b = "White",
            c = "Yellow",
            correct = "White"
        },
        new Question
        {
            category = "Halloween",
            question = "What is the purpose of a jack-o'-lantern?",
            a = "Decoration",
            b = "Scaring away spirits",
            c = "Both a and b",
            correct = "Both a and b"
        },
        new Question
        {
            category = "Halloween",
            question = "What do you call a spooky story told around a campfire?",
            a = "Ghost story",
            b = "Fairy tale",
            c = "Mystery",
            correct = "Ghost story"
        },
        new Question
        {
            category = "Halloween",
            question = "What do vampires drink?",
            a = "Blood",
            b = "Water",
            c = "Juice",
            correct = "Bloodc"
        },
        new Question
        {
            category = "Halloween",
            question = "What day is Halloween celebrated?",
            a = "October 31",
            b = "November 1",
            c = "October 15",
            correct = "October 31"
        },
        new Question
        {
            category = "Halloween",
            question = "What is a common symbol of Halloween?",
            a = "a) Pumpkin",
            b = "Heart",
            c = "Star",
            correct = "Pumpkin"
        },
        new Question
        {
            category = "Halloween",
            question = "Which mythical creature is known for its long, pointed ears and sharp fangs?",
            a = "Ghost",
            b = "Vampire",
            c = "Werewolf",
            correct = "Vampire"
        },
        new Question
        {
            category = "Halloween",
            question = "What do you call a gathering of witches?",
            a = "A party",
            b = "A coven",
            c = " A gathering",
            correct = "A coven"
        },
        new Question
        {
            category = "Halloween",
            question = "Which of these is a famous Halloween song?",
            a = "Jingle Bells",
            b = "Thriller",
            c = "Let It Go",
            correct = "Thriller"
        },
        new Question
        {
            category = "Halloween",
            question = "What creature is known for being undead?",
            a = "Vampire",
            b = "Ghost",
            c = "Zombie",
            correct = "Zombie"
        },
        new Question
        {
            category = "Halloween",
            question = "What do you call a haunted house?",
            a = "Scary house",
            b = "Haunted mansion",
            c = "Ghost house",
            correct = "Haunted mansion"
        }
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

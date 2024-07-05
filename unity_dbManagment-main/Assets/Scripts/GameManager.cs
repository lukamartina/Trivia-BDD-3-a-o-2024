using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<question> responseList; // Lista donde guardo la respuesta de la query hecha en la pantalla de selección de categoría
    public int currentTriviaIndex = 0;
    public int randomQuestionIndex = 0;
    public List<string> _answers = new List<string>();
    public bool queryCalled;
    private int _points;
    private int _maxAttempts = 10;

    private int _currentAttemps = 0;
    public int _numQuestionAnswered = 0;
    string _correctAnswer;
    public static GameManager Instance { get; private set; }
    public Timer timer;
    private int score = 0;
    private int maxScore = 3;

    public string gameResult =  "";

    

    void Awake()
    {
        // Configura la instancia
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Para mantener el objeto entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartTrivia();
        queryCalled = false;
        timer?.StartTimer(10.0f);
    }

    void StartTrivia()
    {
        // Cargar la trivia desde la base de datos
        // triviaManager.LoadTrivia(currentTriviaIndex);
        // print(responseList.Count);
        queryCalled = false;
        timer?.StartTimer(10.0f);
    }

    public void CategoryAndQuestionQuery(bool isCalled)
    {
        isCalled = UIManagment.Instance.queryCalled;

        if (!isCalled)
        {
            randomQuestionIndex = Random.Range(0, GameManager.Instance.responseList.Count);

            _correctAnswer = GameManager.Instance.responseList[randomQuestionIndex].CorrectOption;

            // Agrego a la lista de answers las 3 answers
            _answers.Clear();
            _answers.Add(GameManager.Instance.responseList[randomQuestionIndex].Answer1);
            _answers.Add(GameManager.Instance.responseList[randomQuestionIndex].Answer2);
            _answers.Add(GameManager.Instance.responseList[randomQuestionIndex].Answer3);

            // La mixeo con el método Shuffle (ver script Shuffle List)
            _answers.Shuffle();

            // Asigno estos elementos a los textos de los botones
            for (int i = 0; i < UIManagment.Instance._buttons.Length; i++)
            {
                UIManagment.Instance._buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = _answers[i];

                int index = i; // Captura el valor actual de i en una variable local -- SINO NO FUNCA!
                UIManagment.Instance._buttons[i].onClick.RemoveAllListeners();
                UIManagment.Instance._buttons[i].onClick.AddListener(() => UIManagment.Instance.OnButtonClick(index));
            }

            UIManagment.Instance.queryCalled = true;

            // Reiniciar el temporizador cada vez que se seleccione una nueva pregunta
            timer?.StartTimer(10.0f);
        }
    }

    public void CheckAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            score++;
            Debug.Log("Respuesta correcta! Puntos: " + score);

            if (score >= maxScore)
            {
                Debug.Log("Completaste el nivel!");
                gameResult = "You're Winner!";
                SceneManager.LoadScene("LmaoMao");
                // Aquí puedes agregar la lógica para finalizar el nivel o avanzar al siguiente
            }
           UIManagment.Instance.queryCalled = false;
        }
        else
        {
            Debug.Log("Respuesta incorrecta. Fin del nivel.");
            gameResult = "Your Luser";
            SceneManager.LoadScene("LmaoMao"); // Asegúrate de que la escena "Main" esté agregada en la Build Settings
        }
    }

    private void Update()
    {
    }
}

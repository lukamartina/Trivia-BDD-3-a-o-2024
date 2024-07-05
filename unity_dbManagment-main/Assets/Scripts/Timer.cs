using UnityEngine;
using TMPro; // Asegúrate de tener esto
using System.Collections;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement; // Asegúrate de tener esto

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // UI Text para mostrar el tiempo

    private Coroutine timerCoroutine;

    void Start()
    {
        GameManager.Instance.timer = this;
        GameManager.Instance.gameObject.SendMessage("StartTrivia");
    }
    public void StartTimer(float countdownTime)
    {
        print(countdownTime);
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
        timerCoroutine = StartCoroutine(RunTimer(countdownTime));
    }

    private IEnumerator RunTimer(float countdownTime)
    {
        float currentTime = countdownTime;
            print(currentTime);
        while (currentTime > 0)
        {

            currentTime -= Time.deltaTime; // Resta el tiempo transcurrido desde el último frame
            timerText?.SetText(currentTime.ToString("F2")); // Actualiza la UI con el tiempo restante
            yield return null; // Espera hasta el siguiente frame
        }

        TimerEnded();
    }

    private void TimerEnded()
    {
        Debug.Log("¡El temporizador ha terminado!");
        GameManager.Instance.gameResult = "Your Luser";
        SceneManager.LoadScene("LmaoMao");
        // Aquí puedes poner el código que quieres ejecutar cuando el temporizador termine.
    }
}

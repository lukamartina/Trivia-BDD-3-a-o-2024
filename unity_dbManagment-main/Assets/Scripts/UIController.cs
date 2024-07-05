using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameManager gameManager;

    // Método para manejar la respuesta del jugador (llamado desde botones o eventos)
    public void OnAnswerSelected(bool isCorrect)
    {
        gameManager.CheckAnswer(isCorrect);
    }
}

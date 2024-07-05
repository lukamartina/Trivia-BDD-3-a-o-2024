 using UnityEngine;
using TMPro;

public class RegistrationUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField userInput;
    [SerializeField] private TMP_InputField userPass;
    [SerializeField] private DatabaseManager databaseManager;

    public void OnRegisterButtonClicked()
    {
        string username = userInput.text;
        string password = userPass.text;

        if (databaseManager != null)
        {
            databaseManager.RegisterUser(username, password);
        }
    }
}
 
using UnityEngine;
using Supabase;
using Supabase.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Postgrest.Models;
using System;

public class DatabaseManager : MonoBehaviour
{
    string supabaseUrl = "https://cabbjuieealsyryjromm.supabase.co";
    string supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNhYmJqdWllZWFsc3lyeWpyb21tIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjAwMTQzOTQsImV4cCI6MjAzNTU5MDM5NH0.Dw8U9NE60GtarA1tjVUzu40aflHEmcKqU_Z0hBm8YGE";

    Supabase.Client clientSupabase;

    public int index;

    async void Start()
    {
        clientSupabase = new Supabase.Client(supabaseUrl, supabaseKey);
        
        index = PlayerPrefs.GetInt("SelectedIndex");

        // Cargar datos de trivia al inicio
        await LoadTriviaData(index);
    }

    async Task LoadTriviaData(int index)
    {
        var response = await clientSupabase
            .From<question>()
            .Where(question => question.trivia_id == index)
            .Select("id, question, answer1, answer2, answer3, correct_answer, trivia_id, trivia(id, category)")
            .Get();

        // Guardar datos de trivia en GameManager
        GameManager.Instance.currentTriviaIndex = index;
        GameManager.Instance.responseList = response.Models;

        Debug.Log($"Response from query: {response.Models.Count} questions loaded.");
    }

    internal void RegisterUser(string username, string password)
    {
        throw new NotImplementedException();
    }

}
    // Método para registrar un usuario
    /* public async void RegisterUser(string username, string password)
    {
    User newUser = new User
    {
        Username = username,
        Password = password
    };

    var response = await clientSupabase
        .From<User>()
        .Insert(newUser);

    if (response.Error != null)
    {
        Debug.LogError($"Error registering user: {response.Error.Message}");
    }
    else
    {
        Debug.Log("User registered successfully!");
    }
}

// Clase que representa un usuario
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}
 */
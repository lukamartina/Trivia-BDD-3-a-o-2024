using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultScreenText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = GameManager.Instance.gameResult;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

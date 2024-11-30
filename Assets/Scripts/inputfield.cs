using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldExample : MonoBehaviour
{
    public InputField inputField;

    void Update()
    {
        string inputText = inputField.text;
        Debug.Log("Input text: " + inputText);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{
    static public string email;
    static public string pw;
    void Update()
    {

    }

    static public void GetDetails()
    {
        email = GameObject.FindGameObjectWithTag("email").GetComponent<UnityEngine.UI.Text>().text;
        pw = GameObject.FindGameObjectWithTag("pw").GetComponent<UnityEngine.UI.InputField>().text;
        PlayerPrefs.SetString("email", email);
        PlayerPrefs.SetString("pw", pw);
    }

}

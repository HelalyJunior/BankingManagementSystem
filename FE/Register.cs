using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MakeRegister()
    {
        string email = GameObject.FindGameObjectWithTag("email").GetComponent<UnityEngine.UI.Text>().text;
        string username = GameObject.FindGameObjectWithTag("username").GetComponent<UnityEngine.UI.Text>().text;
        string pw = GameObject.FindGameObjectWithTag("pw").GetComponent<UnityEngine.UI.InputField>().text;
        string income = GameObject.FindGameObjectWithTag("balance").GetComponent<UnityEngine.UI.Text>().text;

        string json = string.Format("{{\"income\":\"{0}\",\"username\":\"{1}\",\"password\":\"{2}\",\"email\":\"{3}\"}}"
            ,income,username,pw,email);
        StartCoroutine(User.register(json));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

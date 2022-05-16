using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class createAccountScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void BackIntoLogin()
    {
        SceneManager.LoadScene("LoginScenee");
    }
    public void BackIntoClientFirstScene()
    {
        SceneManager.LoadScene("Client firstScene");
    }
    public void BackIntoMakeTransaction()
    {
        SceneManager.LoadScene("Make transaction");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

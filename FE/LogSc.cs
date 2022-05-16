using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LogSc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Login()
    {
        Controller.GetDetails();
        string json = string.Format("{{\"email\" : \"{0}\" , \"pw\" :\"{1}\"}}", PlayerPrefs.GetString("email")
        , PlayerPrefs.GetString("pw"));
        PlayerPrefs.SetString("getuser", json);
        StartCoroutine(User.getUser(json));
    }
    public void CreateAccount()
    {
        SceneManager.LoadScene("Create Account");
    }
    // Update is called once per frame
    void Update()
    {
        switch(PlayerPrefs.GetInt("result"))
        {
            case 1:
                SceneManager.LoadScene("Client firstscene");
                break;
            case -1:
                //display network_error
                break;
            case -2:
                //display credentials_error
                break;
            default:
                break;
        }
    }
}

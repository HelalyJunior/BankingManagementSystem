using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{

    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("LoginScenee");

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

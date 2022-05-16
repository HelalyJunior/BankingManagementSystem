using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateAcc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void GoCreate()
    {
        SceneManager.LoadScene("Create Account");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

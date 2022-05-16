using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLoan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoLoan()
    {
        SceneManager.LoadScene("Request screen");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

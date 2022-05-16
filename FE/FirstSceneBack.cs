using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FirstSceneBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void FirstSceneClientBack(){
        SceneManager.LoadScene("Client firstscene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

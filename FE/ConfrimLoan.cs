using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfrimLoan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

     public void AddLoan()
    {
        User user = JsonUtility.FromJson<User>(PlayerPrefs.GetString("json"));
        string json = string.Format("{{\"id\":\"{0}\" ,\"interest_rate\":0.6 ,\"amount\":1500}}",user.id);
        StartCoroutine(User.requestLoan(json));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

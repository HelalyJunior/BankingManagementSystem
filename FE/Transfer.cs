using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MakeTransfer()
    {
        User user = JsonUtility.FromJson<User>(PlayerPrefs.GetString("json"));
        string amount = GameObject.FindGameObjectWithTag("amount").GetComponent<UnityEngine.UI.Text>().text;
        string email = GameObject.FindGameObjectWithTag("email").GetComponent<UnityEngine.UI.Text>().text;

        string json = string.Format("{{\"amount\" : \"{0}\" , \"id\" :\"{1}\",\"transfer_account\":\"{2}\",\"trans_type\":\"TRANSFER\"}}"
            , amount, user.id,email);
        StartCoroutine(User.transfer(json));
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("transfer") == 1)
        {
            StartCoroutine(User.getUser(PlayerPrefs.GetString("getuser")));
            PlayerPrefs.SetInt("transfer", 0);

        }
    }
}

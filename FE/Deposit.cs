using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MakeDeposit()
    {
        User user = JsonUtility.FromJson<User>(PlayerPrefs.GetString("json"));
        string amount = GameObject.FindGameObjectWithTag("amount").GetComponent<UnityEngine.UI.Text>().text;
        string json = string.Format("{{\"amount\" : \"{0}\" , \"id\" :\"{1}\",\"trans_type\":\"DEPOSIT\"}}", amount
        , user.id);
        StartCoroutine(User.deposit(json));
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("deposit") == 1)
        {
            StartCoroutine(User.getUser(PlayerPrefs.GetString("getuser")));
            PlayerPrefs.SetInt("deposit", 0);

        }
    }
}

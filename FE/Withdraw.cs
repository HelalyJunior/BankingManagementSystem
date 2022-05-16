using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Withdraw : MonoBehaviour
{
    // Start is called before the first frame update

    public void MakeWithdraw()
    {
        User user = JsonUtility.FromJson<User>(PlayerPrefs.GetString("json"));
        string amount = GameObject.FindGameObjectWithTag("amount").GetComponent<UnityEngine.UI.Text>().text;
        string json = string.Format("{{\"amount\" : \"{0}\" , \"id\" :\"{1}\",\"trans_type\":\"WITHDRAW\"}}", amount
        , user.id);
        StartCoroutine(User.withdraw(json));
        StartCoroutine(User.getUser(PlayerPrefs.GetString("getuser")));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetInt("withdraw") == 1)
        {
            StartCoroutine(User.getUser(PlayerPrefs.GetString("getuser")));
            PlayerPrefs.SetInt("withdraw", 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReq : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddCard()
    {
        User user = JsonUtility.FromJson<User>(PlayerPrefs.GetString("json"));
        UnityEngine.UI.Dropdown comp = GameObject.FindGameObjectWithTag("cards").GetComponent<UnityEngine.UI.Dropdown>();
        string card_type = comp.options[comp.value].text;
        string ccv = GameObject.FindGameObjectWithTag("ccv").GetComponent<UnityEngine.UI.Text>().text;

        string json = string.Format("{{\"ccv\":\"{0}\",\"card_type\":\"{1}\",\"id\":\"{2}\"}}", ccv, card_type,user.id );
        StartCoroutine(User.requestCard(json));
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("addCard") == 1)
        {
            StartCoroutine(User.getUser(PlayerPrefs.GetString("getuser")));
            PlayerPrefs.SetInt("addCard", 0);

        }
    }
}

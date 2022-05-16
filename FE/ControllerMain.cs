using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


public class ControllerMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sprite GOLD = Resources.Load<Sprite>("gold");
        Sprite SILVER = Resources.Load<Sprite>("silver");
        Sprite BRONZE = Resources.Load<Sprite>("bronze");
        Sprite PLATINUIM = Resources.Load<Sprite>("platinum");



        User user = JsonUtility.FromJson<User>(PlayerPrefs.GetString("json"));
        GameObject.FindGameObjectWithTag("balance").GetComponent<UnityEngine.UI.Text>().text+=user.balance.ToString();
        StringBuilder s = new StringBuilder();
        foreach (Card card in user.cards)
        {
            s.Append(string.Format("card of type : {0} , ccv : {1} ", card.card_type, card.ccv));
        }
        GameObject.FindGameObjectWithTag("cards").GetComponent<UnityEngine.UI.Text>().text += s.ToString();

        if (user.income > 3000)
        {
            GameObject.FindGameObjectWithTag("status").GetComponent<UnityEngine.UI.Image>().sprite = PLATINUIM;
            return;
        }
        else if (user.income > 2000)
        {
            GameObject.FindGameObjectWithTag("status").GetComponent<UnityEngine.UI.Image>().sprite = GOLD;
            return;

        }
        else if (user.income>1000)
        {
            GameObject.FindGameObjectWithTag("status").GetComponent<UnityEngine.UI.Image>().sprite = SILVER;
            return;

        }

        else
        {
            GameObject.FindGameObjectWithTag("status").GetComponent<UnityEngine.UI.Image>().sprite = BRONZE;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

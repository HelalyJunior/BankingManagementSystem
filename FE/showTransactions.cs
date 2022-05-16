using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class showTransactions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        User user = JsonUtility.FromJson<User>(PlayerPrefs.GetString("json"));
        int counter = 0;

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("table"))
        {
            if(counter>user.transactions.Count-1)
            {
                break;
            }
            Transaction transaction = user.transactions[counter];
            StringBuilder s = new StringBuilder();
            s.Append(string.Format("id:{0} amount:{1} type:{2} transfer_to:{3}", transaction.id, transaction.amount, transaction
                .trans_type, transaction.transfer_account));
            print(s.ToString());
            obj.GetComponent<UnityEngine.UI.Text>().text += s.ToString();
            counter++;
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

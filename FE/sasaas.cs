using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sasaas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OpenWithDrawScene()
    {
        SceneManager.LoadScene("WithdrawScene");
    }
    public void OpenTransferMoneyScene()
    {
        SceneManager.LoadScene("TransferMoneyScene");
    }
    public void OpenPrevTransactionsScene()
    {
        SceneManager.LoadScene("Previous transactions");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

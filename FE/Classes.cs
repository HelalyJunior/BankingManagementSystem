using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;


[System.Serializable]
public class Transactions
{
    public List<Transaction> transactions;
}

[System.Serializable]
public class Transaction
{
    public float amount;
    public int id;
    public String trans_type;
    public String transfer_account;
}


[System.Serializable]
public class Cards
{
    public List<Card> cards;
}


[System.Serializable]
public class Card
{
    public String ccv;
    public int id;
    public String issue_date;
    public String end_date;
    public string card_type;
}



[System.Serializable]
public class Loans
{
    public List<Loan> loans;
}

[System.Serializable]
public class Loan
{
    public float amount;
    public int id;
    public String interest_rate;
}


[System.Serializable]
public class User
{
    public float balance;
    public String birthDate;
    public List<Card> cards;
    public String email;
    public int id;
    public int income;
    public List<Loan> loans;
    public String password;
    public List<Transaction> transactions;
    public String username;
    public static IEnumerator getUser(string json)
    {
        String url = "http://127.0.0.1:5000/getUser";
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
            PlayerPrefs.SetInt("result", -1); // network_error
        }
        else
        {
            if (uwr.downloadHandler.text.Length < 4)
            {
                PlayerPrefs.SetInt("result", -2); //wrong credentials

                Debug.Log("Error ! ");
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);
                PlayerPrefs.SetInt("result", 1); //success

                PlayerPrefs.SetString("json", uwr.downloadHandler.text);
            }

        }
    }
    public static IEnumerator deposit(string json)
    {
        String url = "http://127.0.0.1:5000/addTransaction";
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
            PlayerPrefs.SetInt("deposit", -1); // network_error
        }
        else
        {
            if (uwr.downloadHandler.text.Length < 4)
            {
                PlayerPrefs.SetInt("deposit", -2); //wrong operation

                Debug.Log("Error ! ");
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);
                PlayerPrefs.SetInt("deposit", 1); //success

            }

        }
    }
    public static IEnumerator withdraw(string json)
    {
        String url = "http://127.0.0.1:5000/addTransaction";
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
            PlayerPrefs.SetInt("withdraw", -1); // network_error
        }
        else
        {
            if (uwr.downloadHandler.text.Length < 4)
            {
                PlayerPrefs.SetInt("withdraw", -2); //wrong operation

                Debug.Log("Error ! ");
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);
                PlayerPrefs.SetInt("withdraw", 1); //success

            }

        }
    }

    public static IEnumerator transfer(string json)
    {
        String url = "http://127.0.0.1:5000/addTransaction";
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
            PlayerPrefs.SetInt("transfer", -1); // network_error
        }
        else
        {
            if (uwr.downloadHandler.text.Length < 4)
            {
                PlayerPrefs.SetInt("transfer", -2); //wrong operation

                Debug.Log("Error ! ");
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);
                PlayerPrefs.SetInt("transfer", 1); //success

            }

        }
    }

    public static IEnumerator register(string json)
    {
        String url = "http://127.0.0.1:5000/Register";
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
            PlayerPrefs.SetInt("register", -1); // network_error
        }
        else
        {
            if (uwr.downloadHandler.text.Length < 4)
            {
                PlayerPrefs.SetInt("register", -2); //wrong operation

                Debug.Log("Error ! ");
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);
                PlayerPrefs.SetInt("register", 1); //success

            }

        }
    }

    public static IEnumerator requestCard(string json)
    {
        String url = "http://127.0.0.1:5000/addCard";
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
            PlayerPrefs.SetInt("addCard", -1); // network_error
        }
        else
        {
            if (uwr.downloadHandler.text.Length < 4)
            {
                PlayerPrefs.SetInt("addCard", -2); //wrong operation

                Debug.Log("Error ! ");
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);
                PlayerPrefs.SetInt("addCard", 1); //success

            }

        }
    }

    public static IEnumerator requestLoan(string json)
    {
        String url = "http://127.0.0.1:5000/addLoan";
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
            PlayerPrefs.SetInt("addLoan", -1); // network_error
        }
        else
        {
            if (uwr.downloadHandler.text.Length < 4)
            {
                PlayerPrefs.SetInt("addLoan", -2); //wrong operation

                Debug.Log("Error ! ");
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);
                PlayerPrefs.SetInt("addLoan", 1); //success

            }

        }
    }
}



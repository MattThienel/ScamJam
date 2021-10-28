using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGameButton : MonoBehaviour
{
    public string ccn;
    public string expMonth, expYear;
    public string name;
    public string pin;

    private InputField ccnField;
    private InputField expMonthField;
    private InputField expYearField;
    private InputField nameField;
    private InputField pinField;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TaskOnClick);

        ccnField = GameObject.Find("/Desktop Background/Scam Game Window/Canvas/Credit Card Number Field").GetComponent<InputField>();
        expMonthField = GameObject.Find("/Desktop Background/Scam Game Window/Canvas/Expiration Date Month Field").GetComponent<InputField>();
        expYearField = GameObject.Find("/Desktop Background/Scam Game Window/Canvas/Expiration Date Year Field").GetComponent<InputField>();
        nameField = GameObject.Find("/Desktop Background/Scam Game Window/Canvas/Card Holder Name Field").GetComponent<InputField>();
        pinField = GameObject.Find("/Desktop Background/Scam Game Window/Canvas/Pin Number Field").GetComponent<InputField>();

        string ccn_temp = GameObject.Find("/Credit Card/Credit Card Front/Credit Card Number").GetComponent<TextMesh>().text;
        name =  GameObject.Find("/Credit Card/Credit Card Front/Credit Card Name").GetComponent<TextMesh>().text;
        pin = GameObject.Find("/Credit Card/Credit Card Back/Credit Card Security Number").GetComponent<TextMesh>().text;

        string exp = GameObject.Find("/Credit Card/Credit Card Front/Credit Card Exp Date").GetComponent<TextMesh>().text;

        int delimeterIndex = exp.IndexOf("/");
        expMonth = exp.Substring(0, delimeterIndex);
        expYear = exp.Substring( delimeterIndex+1 );

        ccn = ccn_temp.Replace( " ", "" );
    }

    void TaskOnClick() {
        bool ccnTest = ccnField.text.Equals(ccn);
        bool nameTest = nameField.text.Equals(name);
        bool expMonthTest = expMonthField.text.Equals(expMonth);
        bool expYearTest = expYearField.text.Equals(expYear);
        bool pinTest = pinField.text.Equals(pin);

        if( ccnTest && nameTest && expMonthTest && expYearTest && pinTest ) {
            GameObject.Find("Desktop Background").SetActive(false);
        } else {
            Debug.Log("Incorrect Info");
        }
    }
}

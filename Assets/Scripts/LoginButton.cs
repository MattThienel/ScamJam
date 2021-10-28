using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour
{

    private TextMesh username;
    private TextMesh password;
    private InputField usernameField;
    private InputField passwordField;

    public GameObject usernameFieldGameObject;
    public GameObject passwordFieldGameObject;

    public GameObject creditCard;
    public GameObject desktopBackground;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TaskOnClick);

        usernameFieldGameObject = GameObject.Find("/Canvas/Username Field");
        passwordFieldGameObject = GameObject.Find("/Canvas/Password Field");

        username = GameObject.Find("/Username").GetComponent<TextMesh>();
        password = GameObject.Find("/Password").GetComponent<TextMesh>();
        usernameField = usernameFieldGameObject.GetComponent<InputField>();
        passwordField = passwordFieldGameObject.GetComponent<InputField>();

        creditCard = GameObject.Find("/Credit Card");
        creditCard.SetActive(false);

        desktopBackground = GameObject.Find("/Desktop Background");
        desktopBackground.SetActive(false);
    }

    void TaskOnClick() {
        if( username.text.Equals(usernameField.text) && password.text.Equals(passwordField.text) ) {
            usernameFieldGameObject.SetActive(false);
            passwordFieldGameObject.SetActive(false);
            GameObject.Find("/Canvas/Username").SetActive(false);
            GameObject.Find("/Canvas/Password").SetActive(false);
            GameObject.Find("/Login Background").SetActive(false);
            GameObject.Find("/Canvas/Button").SetActive(false);
            creditCard.SetActive(true);
            desktopBackground.SetActive(true);
        } else {
            Debug.Log("Incorrect credentials");
        }
    }
}

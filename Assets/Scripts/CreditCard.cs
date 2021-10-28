using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCard : MonoBehaviour
{

    private string creditCardNameString = "Credit Card";

    private GameObject creditCardFront;
    private GameObject creditCardBack;
    private GameObject creditCardNumber;
    private GameObject creditCardName;
    private GameObject creditCardExpDate;
    private GameObject creditCardSecurityNumber;
    private GameObject creditCardSignature;

    bool displayingFront = true;

    void Start()
    {
        creditCardFront = GameObject.Find("/Credit Card/Credit Card Front");
        creditCardBack = GameObject.Find("/Credit Card/Credit Card Back");
        creditCardNumber = GameObject.Find("/Credit Card/Credit Card Front/Credit Card Number");
        creditCardName = GameObject.Find("/Credit Card/Credit Card Front/Credit Card Name");
        creditCardExpDate = GameObject.Find("/Credit Card/Credit Card Front/Credit Card Exp Date");
        creditCardSecurityNumber = GameObject.Find("/Credit Card/Credit Card Back/Credit Card Security Number");
        creditCardSignature = GameObject.Find("/Credit Card/Credit Card Back/Credit Card Signature");
        DisplayFrontOfCreditCard();
    }
    
    void Update()
    {
        if( Input.GetMouseButtonDown(0) ) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2( mousePos.x, mousePos.y );

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero );
            if( hit.collider && hit.collider.gameObject.name.Equals(creditCardNameString) ) {

                if( displayingFront ) {
                    DisplayBackOfCreditCard();
                    displayingFront = false;
                } else {
                    DisplayFrontOfCreditCard();
                    displayingFront = true;
                }
            }    
        }
    }

    void DisplayFrontOfCreditCard() {
        creditCardFront.GetComponent<Renderer>().enabled = true;
        creditCardNumber.GetComponent<Renderer>().enabled = true;
        creditCardName.GetComponent<Renderer>().enabled = true;
        creditCardExpDate.GetComponent<Renderer>().enabled = true;
        creditCardBack.GetComponent<Renderer>().enabled = false;
        creditCardSecurityNumber.GetComponent<Renderer>().enabled = false;
        creditCardSignature.GetComponent<Renderer>().enabled = false;
    }

    void DisplayBackOfCreditCard() {
        creditCardFront.GetComponent<Renderer>().enabled = false;
        creditCardNumber.GetComponent<Renderer>().enabled = false;
        creditCardName.GetComponent<Renderer>().enabled = false;
        creditCardExpDate.GetComponent<Renderer>().enabled = false;
        creditCardBack.GetComponent<Renderer>().enabled = true;
        creditCardSecurityNumber.GetComponent<Renderer>().enabled = true;
        creditCardSignature.GetComponent<Renderer>().enabled = true;
    }
}

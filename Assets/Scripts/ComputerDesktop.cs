using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ComputerDesktop : MonoBehaviour
{

    public string scamGameIconName = "Scam Game Icon";
    public string xButtonName = "X Button";
    public string minButtonName = "Min Button";

    public GameObject gameWindow;
    private TextMesh clock;

    void Start()
    {   
        gameWindow = GameObject.Find("/Desktop Background/Scam Game Window");
        gameWindow.SetActive(false);
        clock = GameObject.Find("/Desktop Background/Clock").GetComponent<TextMesh>();
    }

    void Update()
    {
        if( Input.GetMouseButtonDown(0) ) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2( mousePos.x, mousePos.y );

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero );
            if( hit.collider ) {
                if( hit.collider.gameObject.name.Equals(scamGameIconName) ) {
                    gameWindow.SetActive(true);
                } else if( hit.collider.gameObject.name.Equals(xButtonName) ||  hit.collider.gameObject.name.Equals(minButtonName) ) {
                    gameWindow.SetActive(false);
                }
            }
        }

        clock.text = DateTime.Now.ToString("h:mm:ss tt");
    }
}

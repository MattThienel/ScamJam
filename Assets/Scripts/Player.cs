using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float movementSpeed = 3.0f;
    private float sprintSpeed = 5.0f;
    private bool isSprinting = false;
    private bool hasStickyNote = false;
    private bool hasCreditCard = false;
    private bool hasSocks = false;
    private string sockName = "Sock";
    private string purseName = "Purse";
    private string stickyNoteName = "Sticky Note";
    private string keyboardName = "Keyboard";

    Rigidbody2D playerBody;
    Collider2D coll;

    [SerializeField]
    [HideInInspector]
    public int rayCount = 360;
    [SerializeField]
    [HideInInspector]
    public RaycastHit2D[] rays; 

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        rayCount = 360;
        rays = new RaycastHit2D[rayCount];
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.LeftShift ) ) {
            isSprinting = true;
        } else if( Input.GetKeyUp( KeyCode.LeftShift ) ) {
            isSprinting = false;
        }

        // Perform raycasting for the vision mask, data is used in the file VisionMask.cs
        int j = 0;
        float i = 0.0f;
        for( ; j < rayCount && i < 2.0f * 3.14f; ++j, i += 2.0f * 3.14f / rayCount ) {
            float currentAngle = i;
            float x = Mathf.Cos(currentAngle);
            float y = Mathf.Sin(currentAngle);
            Vector2 directionVector = new Vector2( x, y );
            
            int layerMask = 1 << 6;
            RaycastHit2D hit = Physics2D.Raycast( (Vector2)transform.position, directionVector, Mathf.Infinity, layerMask );
            ;
            rays[j] = hit;
            /*if( hit && hit.collider.gameObject.tag == "Walls" ) {
                //Debug.DrawLine( transform.position, hit.point, Color.white, 0.01f);
            }*/

        }

        // Check if interactable object is nearby and do some action
        if( Input.GetKey( KeyCode.F ) ) {
            j = 0;
            i = 0.0f;
            for( ; j < rayCount && i < 2.0f * 3.14f; ++j, i += 2.0f * 3.14f / 8 ) {
                float currentAngle = i;
                float x = Mathf.Cos(currentAngle);
                float y = Mathf.Sin(currentAngle);
                Vector2 directionVector = new Vector2( x, y );
                
                int layerMask = 1 << 7;
                RaycastHit2D hit = Physics2D.Raycast( (Vector2)transform.position, directionVector, 1.0f, layerMask );
                ;
                Vector2 endPoint = new Vector2( transform.position.x + x, transform.position.y + y );
                Debug.DrawLine( transform.position, endPoint, Color.red, 0.01f);
                if( hit && hit.collider.gameObject.tag == "Interactable" ) {
                    Debug.DrawLine( transform.position, hit.point, Color.white, 0.01f);
                    //Debug.Log(hit.collider.gameObject.name);
                    if( hit.collider.gameObject.name.Equals(purseName) ) {
                        hasCreditCard = true;
                        Debug.Log("Player got credit card");   
                    } else if( hit.collider.gameObject.name.Equals(stickyNoteName) ) {
                        hasStickyNote = true;
                        Debug.Log("Player got password");
                    } else if( hit.collider.gameObject.name.Equals(sockName) ) {
                        hasSocks = true;
                        Debug.Log("Player got socks");
                    } else if( hit.collider.gameObject.name.Equals(keyboardName) ) {
                        if( hasStickyNote && hasCreditCard ) {
                            SceneManager.LoadScene("Ending Scene");
                        }
                    }
                }

            }
        }

    }

    void FixedUpdate() {

        Vector2 movement = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") );

        if( isSprinting ) {
            playerBody.velocity = movement * sprintSpeed;
        } else {
            playerBody.velocity = movement * movementSpeed;
        }

        // Rotate the player towards the direction the player is moving
        if( !( Mathf.Abs(playerBody.velocity.x) <= 0.1f && Mathf.Abs(playerBody.velocity.y) <= 0.1f ) ) {
            float angle = 1.57f;
            if( Mathf.Abs(playerBody.velocity.x) <= 0.1f ) {
                angle += 1.57f;    
            } else {
                angle += Mathf.Atan( playerBody.velocity.y / playerBody.velocity.x );
            }

            if( playerBody.velocity.x < 0.0f ) {
                angle += 3.14f;
            }

            if( Mathf.Abs(angle) >= 0.1f ) {
                playerBody.rotation = angle * 180.0f / 3.14f;
            }
        }

    }
}

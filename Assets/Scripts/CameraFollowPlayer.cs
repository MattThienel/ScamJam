using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3( transform.position.x, 0.5f, transform.position.z );
    }

    // Update is called once per frame
    void Update()
    {
        if( player.transform.position.y > 0.5f && player.transform.position.y < 17.5f ) {
            transform.position = new Vector3( transform.position.x, player.transform.position.y, transform.position.z );
        }
    }
}

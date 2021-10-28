using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionMask : MonoBehaviour
{

    private GameObject player;
    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;

    private int verticeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        verticeCount = player.GetComponent<Player>().rayCount;
        verticeCount = 360; // Should be getting verticeCount from player but wasn't working
        Debug.Log(verticeCount);

        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh.Clear();
    }

    void LateUpdate() {
        meshFilter.mesh.Clear();
        
        Vector3[] vertices = new Vector3[verticeCount + 1];
        vertices[0] = new Vector3(player.transform.position.x, player.transform.position.y, -1.0f);

        for( int i = 1; i < verticeCount; ++i ) {
            vertices[i] = new Vector3( player.GetComponent<Player>().rays[verticeCount-i-1].point.x, player.GetComponent<Player>().rays[verticeCount-i-1].point.y, -1.0f);
        }

        int[] indices = new int[(verticeCount-1) * 3];
        for( int i = 0, j = 1; i < (verticeCount-1) * 3; i+=3 ) {
            indices[i] = 0;
            indices[i+1] = j;
            j += 1;
            indices[i+2] = j;
        }

        indices[(verticeCount-1)*3 - 1] = 1;
        indices[(verticeCount-1)*3 - 2] = verticeCount-1;
        indices[(verticeCount-1)*3 - 3] = 0;


        Color[] colors = new Color[verticeCount+1];
        for( int i = 0; i < verticeCount+1; ++i ) {
            colors[i] = Color.white;
        }

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.colors = colors;
        meshFilter.mesh.triangles = indices;

        meshFilter.mesh.RecalculateBounds();
        meshFilter.mesh.RecalculateNormals();
    }
}

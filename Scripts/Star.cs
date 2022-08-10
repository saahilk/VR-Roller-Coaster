using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    Vector3[] vertices;
    public Material mat;
    int[] faces;
    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject);
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        mesh = mf.mesh;
        GenerateMesh();
    }

    void GenerateMesh(){
        vertices = new Vector3[]{
            //front & back center vertex
            new Vector3(0.0f,0.0f,1.0f),new Vector3(0.0f,0.0f,-1.0f),
            //5 outside pointy vertices
            new Vector3(0.0f,4.0f,0.0f),new Vector3(3.804f,1.236f,0.0f),new Vector3(2.351f,-3.236f,0.0f),new Vector3(-2.351f,-3.236f,0.0f),new Vector3(-3.804f,1.236f,0.0f),
            //5 inside vertices
            new Vector3(1.75f,1.618f,0.0f),new Vector3(1.902f,-0.618f,0.0f),new Vector3(0.0f,-2.0f,0.0f),new Vector3(-1.902f,-0.618f,0.0f),new Vector3(-1.175f,1.618f,0.0f)
        };

        faces = new int[]{
            //front
            0,7,2 , 0,3,7 , 0,8,3 ,0,4,8 , 0,9,4 , 0,5,9 , 
            0,10,5 , 0,6,10 , 0,11,6 , 0,2,11 ,
            //back
            1,2,7 , 1,7,3 , 1,3,8 , 1,8,4 , 1,4,9 , 1,9,5 ,
            1,5,10, 1,10,6 , 1,6,11 , 1,11,2   
        };
        mesh.vertices = vertices;
        mesh.triangles = faces;
        mesh.RecalculateNormals();
        gameObject.transform.localScale = new Vector3(10.0f,10.0f,10.0f);
        gameObject.AddComponent<UnityEngine.MeshRenderer>();
        gameObject.AddComponent<UnityEngine.MeshCollider>();
        gameObject.GetComponent<UnityEngine.MeshCollider>().convex = true;
        var renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material = mat;

    }
}

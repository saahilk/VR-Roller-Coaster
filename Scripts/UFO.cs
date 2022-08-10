using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    Vector3[] vertices;
    public Material[] mat = new Material[2];
    int[] body;
    int[] cockpit;
    Mesh mesh;

    void Start()
    {
        Debug.Log(gameObject);
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        mesh = mf.mesh;
        GenerateMesh();
    }

    void GenerateMesh(){
        mesh.Clear();
        vertices = new Vector3[]{
            //bottom vertex
            //0
            new Vector3(0.0f,-1.0f,0.0f),
             //Body
            //1-8
            new Vector3(0.0f,0.0f,6.0f),new Vector3(4.242f,0.0f,4.242f),new Vector3(6.0f,0.0f,0.0f),new Vector3(4.242f,0.0f,-4.242f),
            new Vector3(0.0f,0.0f,-6.0f),new Vector3(-4.242f,0.0f,-4.242f),new Vector3(-6.0f,0.0f,0.0f),new Vector3(-4.242f,0.0f,4.242f),
            //cockpit
            //9-16
            new Vector3(0.0f,1.0f,3.0f),new Vector3(2.121f,1.0f,2.121f),new Vector3(3.0f,1.0f,0.0f),new Vector3(2.121f,1.0f,-2.121f),
            new Vector3(0.0f,1.0f,-3.0f),new Vector3(-2.121f,1.0f,-2.121f),new Vector3(-3.0f,1.0f,0.0f),new Vector3(-2.121f,1.0f,2.121f),
            //top vertex
            //17
            new Vector3(0.0f,2.5f,0.0f) ,
            //mid cockpit
            //18-25
            new Vector3(0.0f,2.0f,2.0f),new Vector3(1.414f,2.0f,1.414f),new Vector3(2.0f,2.0f,0.0f),new Vector3(1.414f,2.0f,-1.414f),
            new Vector3(0.0f,2.0f,-2.0f),new Vector3(-1.414f,2.0f,-1.414f),new Vector3(-2.0f,2.0f,0.0f),new Vector3(-1.414f,2.0f,1.414f),
            //26
            new Vector3(0.0f,1.0f,0.0f)

        };
        body = new int[]{
            //body
            //lower
            0,2,1 , 0,3,2 , 0,4,3 , 0,5,4 , 0,6,5 , 0,7,6 , 0,8,7 , 0,1,8 ,  
            //mid
            //half 1
            9,1,2 , 9,2,10 , 10,2,3 , 10,3,11 , 11,3,4 , 11,4,12 , 12,4,5 , 12,5,13 ,
            //half2
            13,5,6 , 13,6,14 , 14,6,7 , 14,7,15 , 15,7,8 , 15,8,16 , 16,8,1 , 16,1,9 , 

            9,10,26 , 10,11,26 , 11,12,26 , 12,13,26 , 
            13,14,26 , 14,15,26 , 15,16,26 , 16,9,26
        };
        cockpit = new int[]{
        //cockpit
            9,19,18 , 9,10,19 , 10,20,19 , 10,11,20 , 11,21,20 , 11,12,21 , 12,22,21 , 12,13,22 ,
            13,23,22 , 13,14,23 , 14,24,23 , 14,15,24 , 15,25,24 , 15,16,25 , 16,18,25 , 16,9,18 ,
            //ceiling
            17,18,19 , 17,19,20 , 17,20,21 , 17,21,22 , 17,22,23 , 17,23,24 , 17,24,25 ,17,25,18
        };
        mesh.subMeshCount = 2;
        mesh.vertices = vertices;
        mesh.SetTriangles(body,0);
        mesh.SetTriangles(cockpit,1);
        mesh.RecalculateNormals();
        gameObject.AddComponent<UnityEngine.MeshRenderer>();
        gameObject.AddComponent<UnityEngine.MeshCollider>();
        gameObject.GetComponent<UnityEngine.MeshCollider>().convex = true;
        var renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.materials = mat;
        gameObject.transform.localScale = new Vector3(6.0f,6.0f,6.0f);
    }
}

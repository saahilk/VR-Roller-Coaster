using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using PathCreation;
using SplineMesh;
using UnityEditor;

public class CreatePath : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spline;
    Vector3[] pts;
    void Start()
    {
        string file_path = "Assets/Prefabs/Path.prefab";
        List<SplineNode> Spts = spline.GetComponent<Spline>().nodes;
        pts = new Vector3[Spts.Count];
        for(var i = 0;i<Spts.Count;i++){
            var s = Spts[i];
            // var pos = s.get
            pts[i] = new Vector3(s.Position.x,s.Position.y,s.Position.z);
            Debug.Log(pts[i]);
        }
        BezierPath bezierPath = new BezierPath (pts, true, PathSpace.xyz);
        gameObject.GetComponent<PathCreator>().bezierPath = bezierPath;
        //uncomment next line to save path prefab
        // PrefabUtility.SaveAsPrefabAsset(gameObject,file_path);
        // Debug.Log(pts);
    }
}

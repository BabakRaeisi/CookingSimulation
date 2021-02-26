using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellymesh : MonoBehaviour
{
    public float Intensity = 1f;
    public float Mass = 1f;
    public float stifness = 1f;
    public float damping = 0.75f;
    private Mesh OriginalMesh, MeshClone;
    private MeshRenderer renderer;
    private JellyVertex[] jv;
    private Vector3[] vertexArray; 
    // Start is called before the first frame update
    void Start()
    {
        OriginalMesh = GetComponent<MeshFilter>().sharedMesh;
        MeshClone = Instantiate(OriginalMesh);
        GetComponent<MeshFilter>().sharedMesh = MeshClone;
        renderer = GetComponent<MeshRenderer>();
        jv = new JellyVertex[MeshClone.vertices.Length]; 
        for (int i = 0; i < MeshClone.vertices.Length; i++)
        {
            jv[i] = new JellyVertex(i, transform.TransformPoint(MeshClone.vertices[i])); 
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vertexArray = OriginalMesh.vertices;
        for (int i = 0; i < jv.Length; i++)
        {
            Vector3 target = transform.TransformPoint(vertexArray[jv[i].ID]);
            float intesity = (1 - (renderer.bounds.max.y - target.y) / renderer.bounds.size.y) * Intensity;
            jv[i].shake(target, Mass, stifness, damping);
            target = transform.InverseTransformPoint(jv[i].position);
            vertexArray[jv[i].ID ]= Vector3.Lerp(vertexArray[jv[i].ID], target, intesity);

        }
        MeshClone.vertices = vertexArray; 
    }
    public class JellyVertex
    {
        public int ID;
        public Vector3 position;
        public Vector3 velocity, Force;
        public JellyVertex(int _id, Vector3 _pos)
        { ID = _id;
            position = _pos; 
        }
        public void shake(Vector3 target, float m, float s, float d)
        {
            Force = (target - position) * s;
            velocity = (velocity + Force / m) * d;
            position += velocity;
            if ((velocity + Force + Force / m).magnitude < 0.001f)
                position = target;
        

        }

    }
}

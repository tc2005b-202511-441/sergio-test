using UnityEngine;

public class MyMesh : MonoBehaviour
{
    void Esferita(Vector3 pos, int num)
    {
        GameObject mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mySphere.name = "LaEsferita_" + num;
        mySphere.transform.position = pos;

        MeshRenderer mr = mySphere.GetComponent<MeshRenderer>();
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        mr.material.color = new Color(r, g, b);

        Rigidbody rb = mySphere.AddComponent<Rigidbody>();
        rb.mass = 1.0f;
    }

    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(8.0f, 12.0f);
            float z = Random.Range(-5.0f, 5.0f);
            Esferita(new Vector3(x, y, z), i);
        }
    }

    void Update()
    {
        
    }
}

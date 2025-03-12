using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;

public class Visual : MonoBehaviour
{
    public int TABIQUES;
    public GameObject shape;
    void Suelo()
    {
        GameObject suelo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        suelo.transform.position = new Vector3(0, -0.3f, 0);
        suelo.transform.localScale = new Vector3(30.0f, 0.1f, 10.0f);
        Rigidbody rb = suelo.AddComponent<Rigidbody>();
        rb.mass = 1000.0f;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        PhysicsMaterial pm = new PhysicsMaterial();
        suelo.GetComponent<Collider>().material = pm;
        pm.bounciness = 0.0f;
        pm.dynamicFriction = 1.0f;
        pm.staticFriction = 1.0f;
        pm.frictionCombine = PhysicsMaterialCombine.Average;
        pm.bounceCombine = PhysicsMaterialCombine.Minimum;

    }
    void Tabique(Vector3 pos, int num)
    {
        //GameObject tab = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject tab = Instantiate(shape);
        //tab.transform.localScale = new Vector3(0.98f, 0.5f, 0.5f);
        tab.transform.position = pos;
        tab.transform.localScale = new Vector3(5, 5, 5);
        tab.name = "Tabique_" + num;

        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        //MeshRenderer mr = tab.GetComponent<MeshRenderer>();
        //mr.material.color = new Color(0.97f, 0.46f, 0.0f);
        //mr.material.color = new Color(r, g, b);
        GameObject bunny = tab.transform.GetChild(0).gameObject;
        MeshRenderer mr = bunny.GetComponent<MeshRenderer>();
        mr.material.color = new Color(r, g, b);
        MeshCollider mc = bunny.AddComponent<MeshCollider>();
        mc.convex = true;
        Rigidbody rb = bunny.AddComponent<Rigidbody>();
        rb.mass = 5.0f;
    }
    void Start()
    {
        Suelo();
        List<int> lugares = Logic.GeneratePlaces(TABIQUES);
        for (int i = 0; i < lugares.Count; i++)
        {
            if (lugares[i] == 1)
            {
                Tabique(new Vector3(i, 0, 0), i);
            }
        }
    }

    void Update()
    {
        Debug.DrawLine(Vector3.zero, new Vector3(10, 0, 0), Color.red);
        Debug.DrawLine(Vector3.zero, new Vector3(0, 10, 0), Color.green);
        Debug.DrawLine(Vector3.zero, new Vector3(0, 0, 10), Color.blue);
    }
}

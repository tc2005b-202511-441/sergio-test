using UnityEngine;

public class Pared : MonoBehaviour
{
    public int WIDTH;
    public int HEIGHT;
    // Todo: Crear Suelo, con medidas (30, 0.1, 10)
    // Debe estar justo abajo del tabique
    void Suelo()
    {
        GameObject suelo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        suelo.transform.localScale = new Vector3(30.0f, 0.1f, 10.0f);
        suelo.transform.position = new Vector3(0, -0.3f, 0);
        Rigidbody sueloRB = suelo.AddComponent<Rigidbody>();
        sueloRB.mass = 1000.0f;
        sueloRB.constraints = RigidbodyConstraints.FreezeAll;

        PhysicsMaterial pm = new PhysicsMaterial();
        suelo.GetComponent<Collider>().material = pm;
        pm.dynamicFriction = 0;
        pm.staticFriction = 0;
        pm.bounciness = 1;
        pm.frictionCombine = PhysicsMaterialCombine.Minimum;
        pm.bounceCombine = PhysicsMaterialCombine.Maximum;
    }

    // ToDo: Crear "Tabique" con medidas (1, 0.5, 0.5) centrado en el origen. Naranja.
    void Tabique(Vector3 pos)
    {
        GameObject tab = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tab.transform.localScale = new Vector3(0.99f, 0.5f, 0.5f);
        tab.transform.position = pos;
        MeshRenderer mr = tab.GetComponent<MeshRenderer>();
        mr.material.color = new Color(0.97f, 0.51f, 0);
        Rigidbody tabRB = tab.AddComponent<Rigidbody>();
        tabRB.mass = 1.0f;
    }

    void Bala()
    {
        GameObject bala = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bala.transform.position = new Vector3(0, 1, -5.0f);
        Rigidbody balaRB = bala.AddComponent<Rigidbody>();
        balaRB.mass = 5.0f;
        balaRB.AddForce(new Vector3(0,0,200), ForceMode.Impulse);
    }

    void LaPared()
    {
        for(float r = 0; r < HEIGHT; r++)
        {
            for(float c = 0; c < WIDTH; c++)
            {
                float x = c - WIDTH / 2.0f;
                if (r % 2 != 0) x += 0.5f; // Intercalar
                float y = r / 2.0f;
                float z = 0.0f;
                Tabique(new Vector3(x, y, z));
            }
        }
    }

    void Start()
    {
        Suelo();
        // ToDo: Construir una pared de 10x4 tabiques
        LaPared();

        // Investigar en el API el método Rigidbody.AddForce().
        // Codifica una bala que rompa la pared.
        // Esfera en (0, 1, -5) con fuerza hacia Z+
        //Bala();
    }

    void Update()
    {
        // Donde comenzar, Donde terminar, Color
        Debug.DrawLine(Vector3.zero, new Vector3(10, 0, 0), Color.red);
        Debug.DrawLine(Vector3.zero, new Vector3(0, 10, 0), Color.green);
        Debug.DrawLine(Vector3.zero, new Vector3(0, 0, 10), Color.blue);
        // Solamente se ven en el tab de "Scene" no en el de "Game"
    }
}

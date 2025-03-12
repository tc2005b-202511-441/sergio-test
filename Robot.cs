using TMPro;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    GameObject ModeloBala;
    GameObject drone;
    //public float smoothTime;
    private Vector3 velocity;
    int contador;
    
    void Start()
    {
        contador = 0;

        //smoothTime = 5.0f;
        velocity = Vector3.zero;

        drone = new GameObject(); // Equivalente a Empty Game Object
        drone.name = "DRONE";

        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        body.name = "BODY";
        body.transform.parent = drone.transform;
        
        GameObject lArm = GameObject.CreatePrimitive(PrimitiveType.Cube);
        lArm.name = "LARM";
        lArm.transform.position = new Vector3(-0.6f, 0, 0.2f);
        lArm.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
        lArm.transform.parent = drone.transform;

        GameObject rArm = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rArm.name = "RARM";
        rArm.transform.position = new Vector3(0.6f, 0, 0.2f);
        rArm.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
        rArm.transform.parent = drone.transform;

        drone.transform.position = new Vector3(0, 1, -5);
    }

    void Disparo()
    {
        GameObject bala = Instantiate(ModeloBala);
        if (contador % 2 == 0)
            bala.transform.position = drone.transform.position + new Vector3(-0.6f, 0, 1.2f);
        else
            bala.transform.position = drone.transform.position + new Vector3(0.6f, 0, 1.2f);
        bala.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 200), ForceMode.Impulse);
        Destroy(bala, 3);
    }

    void Update()
    {
        /*Vector3 target = new Vector3(Random.Range(-3.0f, 3.0f), 1, -5);
          drone.transform.position = Vector3.SmoothDamp(
            drone.transform.position, 
            target, 
            ref velocity, 
            smoothTime      );*/
        if(Input.GetKey(KeyCode.A))
        {
            Vector3 p = drone.transform.position;
            p.x -= 0.01f;
            drone.transform.position = p;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 p = drone.transform.position;
            p.x += 0.01f;
            drone.transform.position = p;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 p = drone.transform.position;
            p.z += 0.01f; // p.z = p.z + 0.01
            drone.transform.position = p;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 p = drone.transform.position;
            p.z -= 0.01f; // p.z = p.z - 0.01
            drone.transform.position = p;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            contador++;
            Disparo();
        }
    }
}

using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class Controlador : MonoBehaviour
{
    public TMP_InputField grupo;
    public TMP_InputField lista;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator AskForLogin()
    {
        WWWForm form = new WWWForm();
        /////////////////////////////////////
        Usuario u = new Usuario();
        u.listNumber = int.Parse(lista.text);
        u.group = grupo.text;        
        form.AddField("datos", JsonUtility.ToJson(u));
        /////////////////////////////////////
        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8001/login", form))
        {
            yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string txt = www.downloadHandler.text;
                SceneManager.LoadScene("Logic");
                Debug.Log(txt);
            }
        }
    }

    public void VamosAJugar()
    {
        // ToDo: Check against DB!
        if (grupo.text.All(char.IsLetterOrDigit) && grupo.text.Length == 2)
        {
            if (lista.text.All(char.IsNumber) && lista.text.Length > 0)
            {
                StartCoroutine(AskForLogin());
            }
            else Debug.Log("No pasa por el número de lista");
        }
        else Debug.Log("No pasa por el grupo");
    }
}






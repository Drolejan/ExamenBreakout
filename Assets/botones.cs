using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botones : MonoBehaviour
{
    public void abrirEscena(string nombre)//Esta función abre una escena al ser llamada
    {
        SceneManager.LoadScene(nombre);//Aqui colocamos la variable del nombre de la escena
    }
}

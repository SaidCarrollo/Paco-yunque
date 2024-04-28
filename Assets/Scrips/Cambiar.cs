using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiar : MonoBehaviour
{
    [SerializeField] private GameObject BotonPausa;
    [SerializeField] private GameObject BotonDespausar;
    public void cambiar()
    {
        SceneManager.LoadScene("2");
    }
    public void pausa()
    {
        Time.timeScale = 0f;
        BotonPausa.SetActive(false);
        BotonDespausar.SetActive(true);
    }
    public void reanudar()
    {
        Time.timeScale = 1f;
        BotonPausa.SetActive(true);
        BotonDespausar.SetActive(false);
    }
}

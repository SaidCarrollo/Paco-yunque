using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class Cambiar : MonoBehaviour
{
    [SerializeField] private GameObject BotonPausa;
    [SerializeField] private GameObject BotonDespausar;
    public Volume volume;
    Bloom bloom;

    private void Start()
    {
        //volume = GetComponent<Volume>();
        if (volume.profile.TryGet(out bloom))
        {
            Debug.Log("waza");
        }
    }

    public void pausa()
    {
        Time.timeScale = 0f;
        BotonPausa.SetActive(false);
        BotonDespausar.SetActive(true);
        if (bloom != null)
        {
            bloom.intensity.value = 13f;
        }
    }

    public void reanudar()
    {
        Time.timeScale = 1f;
        BotonPausa.SetActive(true);
        BotonDespausar.SetActive(false);
        if (bloom != null)
        {
            bloom.intensity.value = 0f;
        }
    }
}





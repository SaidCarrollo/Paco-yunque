using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public static MaterialManager Instance { get; private set; }

    [SerializeField] private Material material;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateMaterial(Color color)
    {
        if (material != null)
        {
            if (material.HasProperty("_MainColor"))
            {
                material.SetColor("_MainColor", color);
            }
            if (material.HasProperty("_emisionColor"))
            {
                material.SetColor("_emisionColor", color);
            }
            if (material.HasProperty("_Color"))
            {
                material.SetColor("_Color", color);
            }
        }
        else
        {
            Debug.LogError("Material not assigned.");
        }
    }
}

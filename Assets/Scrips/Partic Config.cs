using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ColorConfigurations : MonoBehaviour
{
    public Material[] particleMaterials;
    private ParticleSystemRenderer particleRenderer;

    void Start()
    {
        particleRenderer = GetComponent<ParticleSystemRenderer>();
        if (particleRenderer != null)
        {
            ChangeMaterial();
        }

    }

    public void CambioP(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (particleRenderer != null)
            {
                ChangeMaterial();
            }
        }
    }

    void ChangeMaterial()
    {
        int randomIndex = Random.Range(0, particleMaterials.Length);
        particleRenderer.sharedMaterial = particleMaterials[randomIndex];
    }
}
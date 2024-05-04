using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;


public class Player : MonoBehaviour
{
    public Volume volume;
    [SerializeField]private Rigidbody myRB;
    [SerializeField] private float velocity;
    [SerializeField] private float CheckDistance=5f;
    [SerializeField] private Vector2 _movement;
    [SerializeField] private AudioSource caminar;
    [SerializeField] private AudioSource Entrar;
    [SerializeField] private AudioSource Salir;
    public FadeController fadeController;
    private bool isMoving = false;
    public Image dialogImage;
    private float dialogo = 0f;
    private bool isInteracting = false;
    private bool isCollidingWithNPC = false;
    Vignette vignette;
    private void Start()
    {
        //volume = GetComponent<Volume>();
        if (volume.profile.TryGet(out vignette))
        {
            Debug.Log("waza");
        }
    }
    private void Update()
    {
        if (_movement != Vector2.zero)
        {
            isMoving = true;
            if (!caminar.isPlaying)
            {
                caminar.Play();
            }
        }
        else
        {
            isMoving = false;
            if (caminar.isPlaying)
            {
                caminar.Stop();
            }
        }
        if (isInteracting)
        {
            dialogImage.gameObject.SetActive(true); 
        }
        else
        {
            dialogImage.gameObject.SetActive(false); 
        }
    }
    void FixedUpdate()
    {
        myRB.velocity = new Vector3(_movement.x, myRB.velocity.y, _movement.y);
     
    }
    public void Movement(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>() * velocity;
    }
    public void Dialogar(InputAction.CallbackContext context)
    {
        if (context.performed && isCollidingWithNPC)
            isInteracting = true;
        else if (context.canceled)
            isInteracting = false;
    }
    void FadeI()
    {
        dialogImage.gameObject.SetActive(true);
    }

    void FadeOut()
    {
        dialogImage.gameObject.SetActive(false); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "1")
        {
            fadeController.FadeInAndOut();
            Entrar.Play();
        }
        if (collision.gameObject.tag == "NPC")
        {
            isCollidingWithNPC = true;
            if (vignette != null)
            {
                vignette.intensity.value = 0.5f;
                vignette.intensity.value = 1f;
            }

        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "1")
        {
            fadeController.FadeInAndOut();
            Salir.Stop();
        }
        if (collision.gameObject.tag == "NPC")
        {
            isCollidingWithNPC = false;
            isInteracting = false;
            if (vignette != null)
            {
                vignette.intensity.value = 0.5f;
                vignette.intensity.value = 0f;
            }
        }
        }
    }




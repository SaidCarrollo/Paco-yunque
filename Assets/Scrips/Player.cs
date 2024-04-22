using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField]private Rigidbody myRB;
    [SerializeField] private float velocity;
    [SerializeField] private float CheckDistance=5f;
    [SerializeField] private Vector2 _movement;
    [SerializeField] private AudioSource caminar;
    [SerializeField] private AudioSource Entrar;
    [SerializeField] private AudioSource Salir;
    private bool isMoving = false;

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
    }
    void FixedUpdate()
    {
        myRB.velocity = new Vector3(_movement.x, myRB.velocity.y, _movement.y);
     
    }
    public void Movement(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>() * velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "1")
        {
            Entrar.Play();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "1")
        {
            Salir.Stop();
        }
    }
}

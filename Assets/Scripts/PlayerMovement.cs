using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private InputSystem_Actions controls;
    private Rigidbody rb;
    private Vector2 moveInput;

    private float speed = 10;

    public Transform particles;
    private ParticleSystem particlesSystem;
    private Vector3 position;

     private AudioSource audioCollected;

     public GameObject camera;

     public int puntos = 1;
     public int puntaje;


void Awake(){
        controls = new InputSystem_Actions();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }
void OnEnable(){

        controls.Enable();
    }

    void OnDisable(){
    
     controls.Disable();
    }

    void Start()
    {
    rb = GetComponent<Rigidbody>();

    particlesSystem = particles.GetComponent<ParticleSystem>();
    particlesSystem.Stop();

    audioCollected = GetComponent<AudioSource>();

        
    }


    


    

    void FixedUpdate(){

        Vector3 movement = new Vector3(moveInput.x, 0.0f, moveInput.y);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other){

       if(other.gameObject.CompareTag("PickUp")){
        position = other.gameObject.transform.position;
        particles.position = position;
        particlesSystem = particles.GetComponent<ParticleSystem>();
        particlesSystem.Play();
        audioCollected.Play();
        
        puntaje += puntos;
        Debug.Log("Puntaje: " + puntaje);
        other.gameObject.SetActive(false);
        particlesSystem.Stop();
        

       }else {


       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

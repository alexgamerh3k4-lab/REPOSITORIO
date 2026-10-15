using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Variables se escriben en camelCase (holaGenteComoEstais)
    //Los métodos, clases y funciones en PascalCase (HolaGenteComoEstais)


    Rigidbody rb; //Declara la variable
    private Vector3 movementDirection; //el serializefield es para que el editor cambie esas variables, pero sigan siendo privadas

    [Header("Movement Properties")]
    [SerializeField] private float horizontalMovement = 0;
    [SerializeField] private float forwardMovement = 0;
    [SerializeField] private float movementVelocity = 15;

    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Inicializa la variable
        movementDirection = new Vector3(horizontalMovement, 0, forwardMovement);
    }
    
    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        forwardMovement = Input.GetAxis("Vertical");
        movementDirection = new Vector3(horizontalMovement, 0, forwardMovement);


    }

    void FixedUpdate() // 100 Hz
    {
        rb.AddForce(movementDirection*movementVelocity, ForceMode.Acceleration);
        /*
        ForceMode.Acceleration; Aceleración constante -- Un coche
        ForceMode.Impulse; Da un solo iumpulso -- Si me empujan en hielo
        ForceMode.VelocityChange; Cambia la velocidad del rigidbody -- Si voy a una velocidad, me establece una velocidad concreta
        ForceMode.Force;  Añade una fuerza -- el da un empujón
        */
    }


}

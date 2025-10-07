using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float JumpForce = 5f;
    public float sensibility = 2f;
    public float limitX = 45f;
    //public Transform cam;

    private Rigidbody rb;  
    private bool grounded;

    private float rotX = 0f;

    public Transform SpawnPoint;

    public float a = 0.01f;
    float x = 1;
    float y = 1;
    float z = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //Raycast
        Debug.DrawRay(transform.position, Vector3.down * 1.8f, Color.red);
        Gizmos.color = Color.red;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 1.8f);

        //Mover
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, 0) * speed * Time.deltaTime);

        //Saltar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                rb = GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
                //rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }
        /*
        //Camara
        rotX += -Input.GetAxis("Mouse Y") * sensibility;
        rotX = Mathf.Clamp(rotX, -limitX, limitX);
        cam.localRotation = Quaternion.Euler(rotX,0,0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensibility, 0);
        */
        //Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        { speed = 12f; }
        else
        { speed = 5f; }

        //Rotar
        if (Input.GetKeyDown(KeyCode.X))
        { RotarX(); }
        if (Input.GetKeyDown(KeyCode.Y))
        { RotarY(); }
        if (Input.GetKeyDown(KeyCode.Z))
        { RotarZ(); }
        
        //Rescalar
        if (Input.GetKey(KeyCode.O))
        {
            transform.localScale = new Vector3(x,y,z);
            x += a;
            y += a;
            z += a;
        }

        if (Input.GetKey(KeyCode.I))
        {
            transform.localScale = new Vector3(x,y,z);
            x -= a;
            y -= a;
            z -= a;
        }
    }

    //Collision con objetos
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == ("DeathZone"))
        {
            transform.position = SpawnPoint.position;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    //Rotaciones
    private void RotarX()
    { transform.rotation = Quaternion.Euler(x,0,0); x += 45; }
    private void RotarY()
    { transform.rotation = Quaternion.Euler(0,y,0); y += 45; }
    private void RotarZ()
    { transform.rotation = Quaternion.Euler(0,0,z); z += 45; }
}

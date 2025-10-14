using Unity.VisualScripting;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private LayerMask CapaDetectable;
    public float rotacion = 0.1f;
    void Update()
    {
        transform.Rotate(new Vector3(0f, rotacion * Time.deltaTime, 0f));

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);
        }

    }
    

    
}

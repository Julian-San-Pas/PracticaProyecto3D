using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform Posicion;
    public GameObject player;

    private Camera mainCamera;
    private LineRenderer LineRenderer;
    private static Camera main;

    private void Start()
    {
        mainCamera = Camera.main;
        LineRenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        SegundaPersona();
       /*
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Vector3 rayOrigin = (new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z));
            Ray ray = new Ray(rayOrigin,mainCamera.transform.forward);
            LineRenderer.SetPosition(0, Posicion.position);

            if (Physics.Raycast(ray, out hit))
            {
                LineRenderer.SetPosition(1, hit.point);
                Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);
                Destroy(hit.transform.gameObject);
            }
        }*/
    }

    void SegundaPersona()
    {
        Vector3 position = transform.position;
        position.x = player.transform.position.x;
        position.y = player.transform.position.y + 1.5f;
    }



}

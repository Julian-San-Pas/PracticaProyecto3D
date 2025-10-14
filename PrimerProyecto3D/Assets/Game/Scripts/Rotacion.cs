using System.Security.Cryptography;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public float velocidad = 100f;

    void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, velocidad * Time.deltaTime, 0f);
    }
}

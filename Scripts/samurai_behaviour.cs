using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samurai_behaviour : MonoBehaviour
{
    public float smoothing = 1.0f; 
    public float aceletationFactor = 5f;
    public Transform rotator;

    // Rango de latitud y longitud
    public float minLatitude = -90f;
    public float maxLatitude = 90f;
    public float minLongitude = -180f;
    public float maxLongitude = 180f;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        Input.location.Start();
        Input.compass.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotacion hacia el norte
        Quaternion attitude = Input.gyro.attitude;

        rotator.rotation = attitude; // Usar rotator como Transform
        rotator.Rotate(0f, 0f, 180f, Space.Self);
        rotator.Rotate(90f, 180f, 0f, Space.World);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotator.rotation, smoothing);

        // Movimiento basado en la aceleracion del dispositivo
        Vector3 movement = transform.forward * -Input.acceleration.z * Time.deltaTime * aceletationFactor;
        transform.position += movement;

        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);

        // Comprobar si el dispositivo esta dentro de los limites
        if (Input.location.status == LocationServiceStatus.Running) {
            float latitude = Input.location.lastData.latitude;
            float longitude = Input.location.lastData.longitude;

            if (latitude < minLatitude || latitude > maxLatitude || longitude < minLongitude || longitude > maxLongitude) {
                Debug.Log("Fuera de los limites. Samurai detenido.");
                enabled = false; // Detener el script
                Input.location.Stop();
            }
        }
    }
}

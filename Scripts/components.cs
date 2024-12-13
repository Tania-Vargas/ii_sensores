using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class components : MonoBehaviour
{
    public TextMeshProUGUI velocidad;
    public TextMeshProUGUI aceleracion;
    public TextMeshProUGUI altitud;
    public TextMeshProUGUI gravedad;
    public TextMeshProUGUI longitud;
    public TextMeshProUGUI latitud;

    // Start is called before the first frame update
    void Start()
    {
        velocidad.text = "Velocidad: 0 m/s";
        aceleracion.text = "Aceleracion: 0 m/s^2";
        altitud.text = "Altitud: 0 m";
        gravedad.text = "Gravedad: 9.8 m/s^2";
        longitud.text = "Longitud: 0";
        latitud.text = "Latitud: 0";

        Input.gyro.enabled = true;
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        // Velocidad
        velocidad.text = "Velocidad: " + Input.gyro.rotationRate + " m/s";
        // Aceleracion
        aceleracion.text = "Aceleracion: " + Input.gyro.userAcceleration + " m/s^2";
        // Altitud
        altitud.text = "Altitud: " + Input.location.lastData.altitude + " m";
        // Gravedad
        gravedad.text = "Gravedad: " + Input.gyro.gravity + " m/s^2";
        // Longitud
        longitud.text = "Longitud: " + Input.location.lastData.longitude; 
        // Latitud
        latitud.text = "Latitud: " + Input.location.lastData.latitude;
    }
}

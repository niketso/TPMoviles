using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    float verticalAngle = 0;

    [SerializeField] float speed;
    [SerializeField] Transform cameraAxis;
    [SerializeField] float verticalRange = 90;

    void Update()
    {
        //Calculo la rotación en cada eje según el input
        float horRot = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        float verRot = -Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        //Aplico la rotación a un contador de angulo vertical
        verticalAngle += verRot;

        //Limito el angulo vertical de mi contador entre el rango especificado en el editor
        verticalAngle = Mathf.Clamp(verticalAngle, -verticalRange, verticalRange);

        //Seteo la rotación relativa a mi padre segun el contador de angulo vertical
        cameraAxis.localEulerAngles = new Vector3(verticalAngle, 0, 0);

        //Me roto a mi horizontalmente según el mouse
        transform.Rotate(0, horRot, 0);
    }
}
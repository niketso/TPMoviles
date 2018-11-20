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
        float horRot = InputManager.Instance.GetHorizontalCameraAxis() * speed * Time.deltaTime;
        // Debug.Log(InputManager.Instance.GetHorizontalCameraAxis());
        float verRot = -InputManager.Instance.GetVerticalCameraAxis() * speed * Time.deltaTime;
        //Debug.Log(InputManager.Instance.GetVerticalCameraAxis());

        //Aplico la rotación a un contador de angulo vertical
        verticalAngle += verRot;

        //Limito el angulo vertical de mi contador entre el rango especificado en el editor
        verticalAngle = Mathf.Clamp(verticalAngle, -verticalRange, verticalRange);

        //Seteo la rotación relativa a mi padre segun el contador de angulo vertical
        cameraAxis.localEulerAngles = new Vector3(verticalAngle, 0, 0);

        //Me roto a mi horizontalmente según el mouse
        transform.localRotation *= Quaternion.AngleAxis(horRot, Vector3.up);
    }
}
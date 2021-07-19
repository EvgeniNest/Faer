using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMouseScript : MonoBehaviour
{
    [SerializeField] private GameObject targetCam;
    [SerializeField] private GameObject target;
    [SerializeField] private float rotateSpeed = 5;
    [SerializeField] private float distance = 3.0f;
    [SerializeField] private float targetHeight = 2.0f;
    [SerializeField] private float yMinLimit = -40;
    [SerializeField] private float yMaxLimit = 80;
    private float x = 0.0f; //Угол поворота по Y?
    private float y = 0.0f; //Уго поворота по X?




    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

    }

    void LateUpdate()
    {
        y = Mathf.Clamp(y, yMinLimit, yMaxLimit); //Вызов самописной функции для ограничения углов поврот
       
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        x += Input.GetAxis("Mouse X") * rotateSpeed;
        y -= Input.GetAxis("Mouse Y") * rotateSpeed;

        target.transform.Rotate(0, horizontal, 0);

        //Повернуть камеру согласно поченым данным
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        transform.rotation = rotation;

        //Двигаем камеру и следим за персонажем
        Vector3 position = rotation * new Vector3(0.0f, targetHeight + 0.5f, -distance) + target.transform.position;
        transform.position = position;

        transform.LookAt(targetCam.transform);
    }
}


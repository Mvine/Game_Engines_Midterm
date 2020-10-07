using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FpsCamera : MonoBehaviour
{
    private const float m_MouseSensConversion = 500.0f;
    private float m_MouseX;
    private float m_MouseY;

    public float m_MouseSensitivity;
    public Transform m_PlayerBody;

    private float m_XRotation = 0.0f;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        m_MouseSensitivity += m_MouseSensConversion;
    }

    // Update is called once per frame
    private void Update()
    {
        m_MouseX = Input.GetAxis("Mouse X") * m_MouseSensitivity * Time.deltaTime;
        m_MouseY = Input.GetAxis("Mouse Y") * m_MouseSensitivity * Time.deltaTime;

        m_XRotation -= m_MouseY;
        m_XRotation = Mathf.Clamp(m_XRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(m_XRotation, 0.0f, 0.0f);
        m_PlayerBody.Rotate(Vector3.up * m_MouseX);
    }
}
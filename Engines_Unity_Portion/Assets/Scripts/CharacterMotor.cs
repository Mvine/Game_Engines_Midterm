using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 m_MovementDir;
    private bool m_Grounded = true;
    private float m_X;
    private float m_Z;
    private Vector3 m_Velocity;

    public CharacterController m_Controller;
    public Transform m_GroundCheck;
    public LayerMask m_GroundMask;

    public float m_GroundCheckRadius = 0.5f;
    public float m_MoveSpeed = 10.0f;
    public float m_Gravity = -9.81f;
    public float m_JumpHeight = 2.0f;

// Update is called once per frame
    private void Update()
    {
        m_Grounded = Physics.CheckSphere(m_GroundCheck.position, m_GroundCheckRadius, m_GroundMask);


        if (m_Grounded && m_Velocity.y < 0) m_Velocity.y = -2.0f;

        m_X = Input.GetAxis("Horizontal"); //Horizontal returns A value between -1, 1 not really needed here but a nice feature
        m_Z = Input.GetAxis("Vertical"); //Vetical returns A value between -1, 1

        m_MovementDir = transform.right * m_X + transform.forward * m_Z;

        m_Controller.Move(m_MovementDir * m_MoveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)) m_Velocity.y = Mathf.Sqrt(m_JumpHeight * -2.0f * m_Gravity);

        m_Velocity.y += m_Gravity * Time.deltaTime;

        m_Controller.Move(m_Velocity * Time.deltaTime);
    }
}
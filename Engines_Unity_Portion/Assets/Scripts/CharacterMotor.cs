using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    //Private Variables
    private Vector3 m_MovementDir;
    private Vector3 m_Velocity;
    private float m_X;
    private float m_Z;
    private bool m_Grounded = false;
    private bool m_Sprinting = false;

    //Public References
    public CharacterController m_Controller;
    public Transform m_GroundCheck;
    public LayerMask m_GroundMask;
    public LayerMask m_DeathMask;

    //Public Variables
    public float m_SprintMultiplier = 10.0f;
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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_Sprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            m_Sprinting = false;
        }

        if (m_Sprinting)
        {
            m_Controller.Move(m_MovementDir * m_MoveSpeed * m_SprintMultiplier * Time.deltaTime);
        }
        else
        {
            m_Controller.Move(m_MovementDir * m_MoveSpeed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Space)) m_Velocity.y = Mathf.Sqrt(m_JumpHeight * -2.0f * m_Gravity);

        m_Velocity.y += m_Gravity * Time.deltaTime;

        m_Controller.Move(m_Velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider p_collider)
    {
        if (p_collider.tag == "Death")
        {
            Debug.Log("Hey you died");
        }
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public int playerNum;

    //movement variables
    public float thrust = 2;
    public float torque = 1;
    Rigidbody rb;
    private Animator anim;
    bool toggleWings = false;

    // Fire variables
    private float timer = 0;
    public float shotRate = 0.2f;
    public GameObject[] laserSpawnPoints;
    public float laserDmg = 3;
    private int laserpoint = 0;
    public GameObject laser;

    // Lock mouse
    public bool lockCursor = true;
    private bool m_cursorIsLocked = true;

    // Input
    float roll;
    float pitch;
    float throttle;
    float fire;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        roll = Input.GetAxis("Horizontal"+playerNum);
        pitch = Input.GetAxis("Vertical" + playerNum);
        throttle = Input.GetAxis("Throttle" + playerNum);

        rb.AddRelativeTorque(-Vector3.back * torque * roll*300f);
        rb.AddRelativeTorque(Vector3.right * torque * pitch*200f);

        if(throttle >= 0)
        {
            rb.AddRelativeForce(Vector3.forward * thrust * throttle*150f);
        }
    }

    void Fire()
    {
            Instantiate(laser, laserSpawnPoints[laserpoint].transform.position, laserSpawnPoints[laserpoint].transform.rotation, null);
            laserpoint++;
            if (laserpoint >= laserSpawnPoints.Length)
            {
                laserpoint = 0;
            }

    }
    void SetCursorLock(bool value)
    {
        lockCursor = value;
        if (!lockCursor)
        {//we force unlock the cursor if the user disable the cursor locking helper
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void UpdateCursorLock()
    {
        //if the user set "lockCursor" we check & properly lock the cursos
        if (lockCursor)
            InternalLockUpdate();
    }

    void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
        }

        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Toggle wings" + playerNum) != 0 && timer >= shotRate)
        {
            toggleWings = !toggleWings;
            anim.SetBool("Toggle wings", toggleWings);
            timer = 0;
        }
        /*RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward, out hit, Camera.main.farClipPlane))
        {
            foreach (GameObject point in laserSpawnPoints)
            {
                if(hit.point != null)
                {
                    point.transform.LookAt(hit.point);
                }
                
            }
        }*/
        //else {
            //foreach (GameObject point in laserSpawnPoints)
            //{

                //point.transform.LookAt(transform.forward*Camera.main.farClipPlane);
            //}
        //}
        timer += Time.deltaTime;
        fire = Input.GetAxis("Fire" + playerNum);
        if (fire != 0 && timer >= shotRate / laserSpawnPoints.Length)
        {
            timer = 0;
            Fire();
        }
        
        UpdateCursorLock();
    }
}

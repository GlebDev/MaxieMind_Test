using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    const string PLATFORM = "Platform";

    private float zrotate;
    public float Zrotate { get => zrotate; set => zrotate = value; }
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float minZrotate, maxZrotate;

    private Transform hitedObject;

    void Update()
    {
        if (InputManager.CursorDown)
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(InputManager.CursorPoint);
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);
            if (hit.collider != null && hit.transform.tag == PLATFORM)
            {
                hitedObject = hit.transform;
            }
            else {
                hitedObject = null;
            }
        }

        if (hitedObject != null && InputManager.CursorPressed)
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(InputManager.CursorPoint);
            Vector2 platformVector = hitedObject.position - transform.position;
            Vector2 mouseVector = mousePoint - (Vector2)transform.position;

            float angle_dif = Vector2.SignedAngle(platformVector, mouseVector);
            float new_angle = Mathf.Sign(angle_dif) * rotateSpeed * Time.deltaTime;
            new_angle = Mathf.Abs(angle_dif) < Mathf.Abs(new_angle) ? angle_dif : new_angle;    //Choosing a number with a smaller absolute
            Zrotate += new_angle;
            Zrotate = Mathf.Clamp(Zrotate, minZrotate, maxZrotate);
        }

    }

    private void FixedUpdate()
    {
        this.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zrotate);
    }
}

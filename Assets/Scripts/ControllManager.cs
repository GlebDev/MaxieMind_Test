using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllManager : MonoBehaviour
{
    [SerializeField]private PlatformController controller;
    private Vector3 firstTouchPosition;

    private Transform hitedObject;
    // Update is called once per frame
    void Update()
    {
        /*
                if (Input.GetMouseButtonDown(0)) {

                    Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);
                    if (hit.collider != null)
                    {
                        hitedObject = hit.transform;
                    }
                }

                if (hitedObject != null && Input.GetMouseButton(0))
                {
                    Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 platformVector = hitedObject.position - controller.transform.position;
                    Vector2 mouseVector = mousePoint - new Vector2(controller.transform.position.x, controller.transform.position.y);

                    float needAngle = Vector2.SignedAngle(platformVector, mouseVector);
                    controller.Zrotate += needAngle * 2f * Time.deltaTime;
                }


                if (Control_enabled && Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        FirstTouchPosition = Input.GetTouch(0).position;
                        int layer = 1 << LayerMask.NameToLayer(layerThatReactsOnMouseClick);
                        Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                        Vector2 origin = new Vector2(mousePosition3D.x, mousePosition3D.y);
                        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f, layer);
                        if (hit.collider != null && hit.transform.root.gameObject.GetComponent<BoxController>())
                        {
                            TempBC = hit.transform.root.gameObject.GetComponent<BoxController>();
                            ComponentControl_enabled = false;
                        }
                        else
                        {
                            ComponentControl_enabled = true;
                            TempBC = null;
                        }
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                        Vector2 TouchDeltaPosition = Input.GetTouch(0).position - FirstTouchPosition;
                        if (TempBC != null && TouchDeltaPosition.x >= BoxDragDistance)
                        {
                            TempBC.SendBox();
                            FirstTouchPosition = Vector2.zero;
                            TempBC = null;
                        }
                        if (ComponentControl_enabled && Mathf.Abs(touchDeltaPosition.x) > Mathf.Abs(touchDeltaPosition.y))
                        {
                            SetCurComponentProperties(touchDeltaPosition.x, 0);
                        }
                        else
                        {
                            SetCurComponentProperties(0, touchDeltaPosition.y);
                        }
                    }
                }*/
    }
}

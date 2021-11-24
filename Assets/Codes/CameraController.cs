using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera PCamera;
    public Camera FCamera;
    Vector3 touchStart;
    public int maxX = 7;
    public int maxZ = 4;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = FCamera.WorldToScreenPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - (FCamera.WorldToScreenPoint(Input.mousePosition));
            float x = (float)(direction.x * 0.0005);
            float y = (float)(direction.y * 0.0005);
            float z = 0;
            //PCamera.transform.position += new Vector3(x,y,z);

            float Cx = PCamera.transform.position.x;
            float Cz = PCamera.transform.position.z;
            float Sx = Cx + x;
            float Sz = Cz + y;
            if ((-maxX<Sx && Sx<maxX)&& (-maxZ < Sz && Sz < maxZ))
            {
                PCamera.transform.position += new Vector3(x, z, y);
            }
        }
        zoom(Input.GetAxis("Mouse ScrollWheel")*15);
    }

    void zoom(float increment)
    {
        float field = (PCamera.fieldOfView - increment);
        if (10 < field && field< 70)
        {
            PCamera.fieldOfView -= increment;
        }
    }
}

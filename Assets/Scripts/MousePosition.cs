using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    Vector3 position;
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 newpos = position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.Translate(newpos);
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Camera.main.transform.position.x < 8)
            {
                Camera.main.transform.position = new Vector3(8, Camera.main.transform.position.y, -10);
            }
            if (Camera.main.transform.position.x > 42)
            {
                Camera.main.transform.position = new Vector3(42, Camera.main.transform.position.y, -10);
            }
            if (Camera.main.transform.position.y < 4)
            {
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 4, -10);
            }
            if (Camera.main.transform.position.y > 46)
            {
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 46, -10);
            }
        }
    }
}

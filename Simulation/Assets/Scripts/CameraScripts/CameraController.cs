using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// controls camera in gameview
public class CameraController : MonoBehaviour
{
        public float zoomSpeed = 1;
        public float targetOrtho;
        public float smoothSpeed = 2.0f;
        public float minOrtho = 1.0f;
        public float maxOrtho = 20.0f;

        void Start()
        {
            targetOrtho = Camera.main.orthographicSize;
        }

        void Update()
        {

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0.0f)
            {
                targetOrtho -= scroll * zoomSpeed;
                targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
            }

            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);

            float xAxisValue = Input.GetAxis("Horizontal");
            float yAxisValue = Input.GetAxis("Vertical");
            if (Camera.current != null)
            {
            Camera.current.transform.Translate(new Vector3(xAxisValue*0.1f, yAxisValue*0.1f,0.0f));
            }
    }
    
}

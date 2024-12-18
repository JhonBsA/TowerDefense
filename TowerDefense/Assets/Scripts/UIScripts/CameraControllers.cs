using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera Camera;
    private bool MouseControl = false;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 23f;

    public float minX = -7f;
    public float maxX = 7f;
    public float minZ = -22f;
    public float maxZ = -5f;

    public Vector3 pos;
    

    // Update is called once per frame
    void Update()
    {
        // Verificar si el MMB está presionado para habilitar el control con el ratón
        if (MouseControl)
        {
            if (Input.GetMouseButton(2))
            {
                MouseControl = false;
            }
        } 
        else
        {
            if (Input.GetMouseButton(2))
            {
                MouseControl = true;
            }

        }

        // Mover la cámara con WASD 
        Vector3 pos = transform.position;

        if (MouseControl)
        {
            useMouseMov();          
        }
        else 
        {
            useWASDMov();
        }

        void useWASDMov() 
        {
            if (Input.GetKey("w"))
            {
                pos += Vector3.forward * panSpeed * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                pos += Vector3.back * panSpeed * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                pos += Vector3.right * panSpeed * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                pos += Vector3.left * panSpeed * Time.deltaTime;
            }
        }

        void useMouseMov()
        {
            if (Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                pos += Vector3.forward * panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.y <= panBorderThickness)
            {
                pos += Vector3.back * panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                pos += Vector3.right * panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x <= panBorderThickness)
            {
                pos += Vector3.left * panSpeed * Time.deltaTime;
            }

        }


        // Zoom en posicion del mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        Vector2 mousePosition = Input.mousePosition;


        // Aplicar límites en los ejes X Y Z
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        // Actualizar la posición de la cámara
        transform.position = pos;
    }
}

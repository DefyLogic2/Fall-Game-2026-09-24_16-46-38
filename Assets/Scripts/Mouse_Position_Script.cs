using UnityEngine;

public class Mouse_Position_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float x_coordinate;
    public float y_coordinate;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0f;

        Vector3 worldPosition = cam.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0f; // Ensure it's on the correct layer

        transform.position = worldPosition;
    }


    void Start()
    {
        cam = Camera.main;
    }

   /* void OnGUI()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }*/
  


}
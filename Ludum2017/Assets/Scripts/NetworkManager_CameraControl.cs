
using UnityEngine.Networking;
using UnityEngine;

public class NetworkManager_CameraControl : NetworkManager
{
    [Header("Scene Camera Properties")]
    // SceneCamera
    [SerializeField]
    private Transform sceneCamera;
    // The radius of the camera's roatation
    [SerializeField]
    private float cameraRotationRadius = 35f;
    // the speed of the camera rotation
    [SerializeField]
    private float cameraRotationSpeed = 20f;
    //Can the camera rotate
    [SerializeField]
    private bool canRotate = true;

    // Current rotation of the camera
    private float rotation;

    
    public override void OnStartClient(NetworkClient client)
    {
        canRotate = false;
    }

    public override void OnStartHost()
    {
        canRotate = false;
    }

    public override void OnStopClient()
    {
        canRotate = true;
    }

    public override void OnStopHost()
    {
        canRotate = true;
    }

    private void Update()
    {
        //can't rotate, leave
        if (!canRotate)
            return;

        //calculate the new rotation 
        rotation += cameraRotationSpeed + Time.deltaTime;
        if (rotation >= 360f)
            rotation -= 360f;

        //rotate the camera around the center of the scene
        sceneCamera.position = Vector3.zero;
        sceneCamera.rotation = Quaternion.Euler(0f, rotation, 0f);
        sceneCamera.Translate(0f, cameraRotationRadius, -cameraRotationRadius);
        sceneCamera.LookAt(Vector3.zero);
    }



}

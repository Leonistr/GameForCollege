using CameraSpace;
using Interfaces;
using Player;
using UnityEngine;
using Extensions;


public class CameraController : IExecutable, ICleanable, IInitializable
{
    #region Fields

    private CameraModel cameraModel;
    private CameraView cameraView;
    private PlayerView playerView;
    private Camera _camera;
    private ICameraProvider _cameraProvider;
    private MeshRenderer[] _objects;

    #endregion

    #region Constructor

    public CameraController(CameraModel cameraModel, CameraView cameraView, PlayerView playerView, ICameraProvider cameraProvider)
    {
        this.cameraModel = cameraModel;
        this.cameraView = cameraView;
        this.playerView = playerView;
        this.cameraView.OnCameraChange += CameraBackgroundChange;
        _camera = cameraView.gameObject.GetOrAddComponent<Camera>();
        _cameraProvider = cameraProvider;
        _cameraProvider.OnPlayerTeleport += CameraBackgroundChange;
    }



    #endregion

    #region Methods 

    private void CameraBackgroundChange()
    {
        GUI.DrawTexture(_camera.rect, cameraModel.CameraStruct.Image);
    }

    public void Clean()
    {
        
    }

    public void Execute(float deltaTime)
    {
        RaycastHit hit;
        Ray ray = new Ray(cameraView.transform.position, playerView.transform.position - cameraView.transform.position);
        _camera.transform.position = new Vector3(Mathf.Clamp(this.playerView.transform.position.x + cameraModel.CameraStruct.Offset.x, cameraModel.CameraStruct.LeftMaximum, cameraModel.CameraStruct.RightMaximum), this.playerView.transform.position.y + cameraModel.CameraStruct.Offset.y, cameraModel.CameraStruct.Offset.z);
        if (Physics.Raycast(ray, out hit, (cameraView.transform.position - playerView.transform.position).magnitude))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                _objects = hit.collider.gameObject.GetComponentsInChildren<MeshRenderer>();
                foreach (var item in _objects)
                {
                    item.enabled = false;
                }
            }
            if (!hit.collider.CompareTag("Wall") && _objects != null)
            {
                foreach (var item in _objects)
                {
                    item.enabled = true;
                }
            }
            Debug.LogError(hit.collider.tag);
        }
        
        
    }

    

    public void Initialize()
    {
        
    }

    #endregion
}

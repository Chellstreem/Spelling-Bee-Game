using UnityEngine;
using Zenject;

public abstract class Billboard : MonoBehaviour
{
    protected IActiveCamera activeCamera;
    protected Transform targetCameraTransform;
    [SerializeField, Range(-180, 180)] protected float horizontalAngleOffset = 0f;

    [Inject]
    public virtual void Construct(IActiveCamera activeCamera)
    {
        this.activeCamera = activeCamera;
    }

    protected void UpdateTargetCamera()
    {
        targetCameraTransform = activeCamera.ActiveCamera.transform;
    }

    private void LateUpdate()
    {
        Vector3 directionToCamera = targetCameraTransform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(directionToCamera);
        lookRotation *= Quaternion.Euler(0, horizontalAngleOffset, 0);
        transform.rotation = lookRotation;
    }
}

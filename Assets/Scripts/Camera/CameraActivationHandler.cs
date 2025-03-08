using UnityEngine;

namespace Cameras
{
    public class CameraActivationHandler
    {
        private readonly IEventManager eventManager;
        private readonly ICameraSwitcher cameraSwitcher;

        public CameraActivationHandler(IEventManager eventManager, ICameraSwitcher cameraSwitcher)
        {
            this.eventManager = eventManager;
            this.cameraSwitcher = cameraSwitcher;

            this.cameraSwitcher.SwitchCamera(CameraType.MainCamera);
        }
    }
}

using UnityEngine;
using Pools;

namespace Spawn
{
    public class SceneObjectSpawner : IEventSubscriber<OnVictory>, IEventSubscriber<OnBeingDamaged>
    {
        private ISceneObjectProvider sceneObjectProvider;
        private IEventManager eventManager;

        public SceneObjectSpawner(ISceneObjectProvider sceneObjectProvider, IEventManager eventManager)
        {
            this.sceneObjectProvider = sceneObjectProvider;
            this.eventManager = eventManager;

            eventManager.Subscribe<OnVictory>(this);
            eventManager.Subscribe<OnBeingDamaged>(this);
        }

        public void OnEvent(OnVictory eventData)
        {
            GameObject[] victoryObjects = sceneObjectProvider.GetObjects(SceneObjectType.victoryObject);
            ToggleObjectActivation(victoryObjects, true);
        }

        public void OnEvent(OnBeingDamaged eventData)
        {
            GameObject[] lossObjects = sceneObjectProvider.GetObjects(SceneObjectType.lossObject);
            ToggleObjectActivation(lossObjects, true);
        }

        private void ToggleObjectActivation(GameObject[] gameObjects, bool SetActive)
        {
            foreach (GameObject obj in gameObjects)
                obj.SetActive(SetActive);
        }

        private void OnDestroy()
        {
            eventManager.Unsubscribe<OnVictory>(this);
            eventManager.Unsubscribe<OnBeingDamaged>(this);
        }
    }
}

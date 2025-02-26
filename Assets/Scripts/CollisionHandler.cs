using UnityEngine;

public class CollisionHandler : IEventSubscriber<OnLetterCollision>
{
    private readonly IEventManager eventManager;
    private readonly IHiddenIndexGetter indexGetter;

    public CollisionHandler(IEventManager eventManager, IHiddenIndexGetter indexGetter)
    {
        this.eventManager = eventManager; 
        this.indexGetter = indexGetter;

        this.eventManager.Subscribe<OnLetterCollision>(this);        
    }

    public void OnEvent(OnLetterCollision eventData)
    {
        CheckLetter(eventData.Value, eventData.Position);
    }

    private void CheckLetter(string letter, Vector3 position)
    {        
        int index = indexGetter.GetHiddenIndex(letter);
        if (index != -1)
        {           
            eventManager.Publish(new OnLetterChecked(letter, true, position));            
        }
        else
        {
            eventManager.Publish(new OnBeingDamaged());
        }        
    }   
}

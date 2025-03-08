using System;
using Zenject;

namespace InteractableObjects
{
    public class OrbLetter : InteractableObject
    {
        private IEventManager eventManager;        
        private ISpawnableObjectReturner returner;
        private ILetterProvider letterProvider;

        public string Value { get; private set; }
        public event Action<string> OnLetterSet;

        [Inject]
        public void Construct(IEventManager eventManager, ISpawnableObjectReturner returner, ILetterProvider letterProvider)
        {
            this.eventManager = eventManager;  
            this.letterProvider = letterProvider;
            this.returner = returner;              
        }

        private void OnEnable() => SetRandomLetter();

        private void SetRandomLetter()
        {            
            string randomLetter = letterProvider.GetRandomLetter();
            OnLetterSet?.Invoke(randomLetter);
            Value = randomLetter.ToLower();
        }        

        protected override void OnPlayerCollision()
        {
            eventManager.Publish(new OnLetterCollision(Value, transform.position));
            returner.ReturnObject(gameObject);            
        }
    }
}

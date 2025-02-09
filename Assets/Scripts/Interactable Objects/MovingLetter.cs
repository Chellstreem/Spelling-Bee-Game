using UnityEngine;
using TMPro;
using System.Text;
using Zenject;

namespace InteractableObjects
{
    public class MovingLetter : InteractableObject
    {
        public string Value { get; private set; }

        private IEventManager eventManager;
        [SerializeField] private TextMeshProUGUI valueText;

        private int extraLettersCount; // Дополнительное количество букв для небольшого усложнения игры   
        private string availableLetters;             

        [Inject]
        public void Construct(IEventManager eventManager, GameConfig gameConfig)
        {
            this.eventManager = eventManager;
            extraLettersCount = gameConfig.ExtraLettersCount;
            availableLetters = gameConfig.AvailableLetters;
        }

        private void OnEnable() => SetRandomLetter();        

        private void SetRandomLetter()
        {
            string letters = GenerateExtraLetters(LetterCollisionHandler.CurrentWord, extraLettersCount);
            char randomLetter = letters[Random.Range(0, letters.Length)];
            valueText.text = randomLetter.ToString().ToUpper();
            Value = randomLetter.ToString().ToLower();
        }

        private string GenerateExtraLetters(string baseWord, int extraAmount)
        {
            StringBuilder sb = new StringBuilder(baseWord);
            while (sb.Length < baseWord.Length + extraAmount)
            {
                sb.Append(availableLetters[Random.Range(0, availableLetters.Length)]);
            }
            return sb.ToString();
        }

        protected override void OnPlayerCollision()
        {
            eventManager.Publish(new OnLetterCollision(Value, transform.position));
            eventManager.Publish(new OnReturnedToPool(gameObject));
        }
    }
}

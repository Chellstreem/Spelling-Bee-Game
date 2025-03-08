using System.Collections;
using UnityEngine;
using Zenject;

namespace PlayerMobility
{
    public class PlayerMovement : IPlayerMover
    {
        private readonly ICoroutineRunner coroutineRunner;
        private readonly Transform playerTransform;
        private readonly Vector3 lowerPosition;
        private readonly Vector3 upperPosition;
        private readonly float moveSpeed;
        private readonly float positionThreshold;

        private Vector3 currentPosition;
        private Coroutine moveCoroutine;

        public PlayerMovement(ICoroutineRunner coroutineRunner,
            [Inject(Id = InstantiatedObjectType.Player)] Transform playerTransform,
            PlayerMobilityConfig config)
        {
            this.coroutineRunner = coroutineRunner;
            this.playerTransform = playerTransform;
            lowerPosition = config.LowerPlayerPosition;
            upperPosition = config.UpperPlayerPosition;
            moveSpeed = config.MoveSpeed;
            positionThreshold = config.PositionThreshold;
        }

        public void GoUp() => MoveTo(upperPosition);

        public void GoDown() => MoveTo(lowerPosition);

        private IEnumerator MoveCoroutine(Vector3 targetPosition)
        {
            while ((playerTransform.position - targetPosition).sqrMagnitude > positionThreshold)
            {
                playerTransform.position = Vector3.MoveTowards(playerTransform.position,
                    targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            playerTransform.position = targetPosition;
        }

        private void MoveTo(Vector3 position)
        {
            if (currentPosition == position) return;
            if (moveCoroutine != null) coroutineRunner.StopCor(moveCoroutine);
            moveCoroutine = coroutineRunner.StartCor(MoveCoroutine(position));
            currentPosition = position;
        }
    }
}

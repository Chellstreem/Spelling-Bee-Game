using System.Collections;
using UnityEngine;

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

        public PlayerMovement(ICoroutineRunnerProvider runnerProvider, IPlayerGetter playerGetter, GameConfig gameConfig)
        {
            coroutineRunner = runnerProvider.GetCoroutineRunner();
            playerTransform = playerGetter.GetPlayer().transform;
            lowerPosition = gameConfig.LowerPlayerPosition;
            upperPosition = gameConfig.UpperPlayerPosition;
            moveSpeed = gameConfig.MoveSpeed;
            positionThreshold = gameConfig.PositionThreshold;
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

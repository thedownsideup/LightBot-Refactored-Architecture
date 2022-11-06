using System.Collections;
using Foundation.ScheduleSystem;
using Foundation.ServiceLocator;
using UnityEngine;

namespace Character.Presentation
{
    public class CharacterPresentation
    {
        private enum ObstacleType
        {
            Block,
            Wall
        }
	
        private const float RAYCAST_MAX_DISTANCE = 1.7f;
        private const float RAYCAST_ORIGIN_BLOCK_Y = -0.6f;
        private const float RAYCAST_ORIGIN_WALL_Y = 1.7f;
	
        private float duration = 0.5f;
        private float stepSize = -1.7f;
        private float jumpHeight = 1f;

        private GameObject character;
        private Scheduler scheduler;
        
        public CharacterPresentation(GameObject characterPrefab, Vector3 startingPosition, float startingRotation)
        {
            character = Object.Instantiate(characterPrefab, startingPosition, 
                Quaternion.Euler(new Vector3(0, startingRotation, 0)));
            character.GetComponent<CapsuleCollider>().enabled = false;
            scheduler = ServiceLocator.Find<Scheduler>();
        }

        public IEnumerator Walk(Vector3 targetPosition)
        {
            if (!CheckForObstacle(ObstacleType.Block) && !CheckForObstacle(ObstacleType.Wall))
            {
                Vector3 startPosition  = character.transform.position;
                targetPosition = targetPosition + (character.transform.right * stepSize); //how does logic calculate this
                float elapsedTime = 0;
         
                while (elapsedTime < duration)
                {
                    character.transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / duration));
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
            }
        }

        public void Light()
        {
            character.GetComponent<CapsuleCollider>().enabled = true;
        }

        public IEnumerator Turn(float degree)
        {
            float startRotation = character.transform.eulerAngles.y;
            float elapsedTime = 0;
            //Logic should also calculate end rotation
            while (elapsedTime  < duration)
            {
                elapsedTime += Time.deltaTime;
                float yRotation = Mathf.Lerp(startRotation, startRotation + degree, elapsedTime / duration);
                character.transform.eulerAngles = new Vector3(character.transform.eulerAngles.x, yRotation, character.transform.eulerAngles.z);
                yield return null;
            }
        }

        public IEnumerator Jump()
        {
            if (CheckForObstacle(ObstacleType.Wall))
            {
                yield return scheduler.StartCoroutine(JumpDirection(character.transform.up));
                yield return scheduler.StartCoroutine(JumpDirection(-character.transform.up));
            }
            else
            {
                if (CheckForObstacle(ObstacleType.Block))
                {
                    yield return scheduler.StartCoroutine(JumpDirection(character.transform.up));
                    yield return scheduler.StartCoroutine(Walk(character.transform.right));
                }
                else
                {
                    yield return scheduler.StartCoroutine(Walk(character.transform.right));
                    yield return scheduler.StartCoroutine(JumpDirection(-character.transform.up));
                }
            }	
        }
        
        private IEnumerator JumpDirection(Vector3 targetPosition)
        {
            Vector3 startPosition  = character.transform.position;
            targetPosition = targetPosition + (character.transform.right * jumpHeight);
            float elapsedTime = 0;
         
            while (elapsedTime < duration)
            {
                character.transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / duration));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
        
        private bool CheckForObstacle(ObstacleType obstacleType)
        {
            Vector3 raycastOriginPoint = character.transform.position;
            RaycastHit hit;

            switch (obstacleType)
            {
                case ObstacleType.Block:
                    raycastOriginPoint += new Vector3(0, RAYCAST_ORIGIN_BLOCK_Y, 0);
                    break;
                case ObstacleType.Wall:
                    raycastOriginPoint += new Vector3(0, RAYCAST_ORIGIN_WALL_Y, 0);
                    break;
            }
		
            if (Physics.Raycast(origin: raycastOriginPoint, direction: -character.transform.right, out hit, 
                    maxDistance: RAYCAST_MAX_DISTANCE, layerMask: Physics.AllLayers,
                    queryTriggerInteraction: QueryTriggerInteraction.UseGlobal))
            {
                return true;
            }
            return false;
        }
    }
}

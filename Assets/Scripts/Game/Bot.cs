using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using static UnityEngine.Mathf;
using Vector3 = UnityEngine.Vector3;

public class Bot : MonoBehaviour
{
	private float duration = 0.5f;
	private float step = -1.7f;
	private float jumpHeight = 1f;
	private Vector3 targetPosition;
	private float endRotation;

	private const float RAYCAST_MAX_DISTANCE = 1.7f;
	private const float RAYCAST_ORIGIN_BLOCK_Y = -0.6f;
	private const float RAYCAST_ORIGIN_WALL_Y = 1.7f;

	enum Moves
	{
		Walk,
		Light,
		TurnLeft,
		TurnRight,
		Jump
	}

	enum Obstacles
	{
		Block,
		Wall
	}

	void Awake()
	{
		GetComponent<CapsuleCollider>().enabled = false;
		targetPosition = transform.position;
		endRotation = transform.eulerAngles.y;
	}


	public IEnumerator Move (List<Command> commands)
	{
		foreach (Command command in commands)
		{
			Vector3 currentPosition = transform.position;
			switch (command.value)
			{
				case (int)Moves.Walk:
					yield return StartCoroutine(Walk(transform.right));
					break;
				case (int)Moves.Light:
					Light();
					break;
				case (int)Moves.TurnLeft:
					yield return StartCoroutine(Turn(-90f));
					break;
				case (int)Moves.TurnRight:
					yield return StartCoroutine(Turn(90f));
					break;
				case (int)Moves.Jump:
					yield return StartCoroutine(Jump());
					break;
			}
			yield return new WaitForSeconds(0.2f);
		}
	}
	
	private IEnumerator Walk(Vector3 direction)
	{
		if (!CheckForObstacle((int) Obstacles.Block) && !CheckForObstacle((int) Obstacles.Wall))
		{
			Vector3 startPosition  = transform.position;
			targetPosition = targetPosition + (direction * step);
			float elapsedTime = 0;
         
			while (elapsedTime < duration)
			{
				transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / duration));
				elapsedTime += Time.deltaTime;
				yield return null;
			}
		}
	}

	private IEnumerator Turn(float degree)
	{
		float startRotation = transform.eulerAngles.y;
		endRotation = startRotation + degree;
		float elapsedTime = 0;
		
		while (elapsedTime  < duration)
		{
			elapsedTime += Time.deltaTime;
			float yRotation = Mathf.Lerp(startRotation, endRotation, elapsedTime / duration);
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
			yield return null;
		}
	}

	private void Light()
	{
		GetComponent<CapsuleCollider>().enabled = true;
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("Block"))
		{
			Block block = collider.transform.GetComponent<Block>();
			block.Light();
		}
	}

	private IEnumerator Jump()
	{
		if (CheckForObstacle((int) Obstacles.Wall))
		{
			yield return StartCoroutine(JumpDirection(transform.up));
			yield return StartCoroutine(JumpDirection(-transform.up));
		}
		else
		{
			if (CheckForObstacle((int)Obstacles.Block))
			{
				yield return StartCoroutine(JumpDirection(transform.up));
				yield return StartCoroutine(Walk(transform.right));
			}
			else
			{
				yield return StartCoroutine(Walk(transform.right));
				yield return StartCoroutine(JumpDirection(-transform.up));
			}
		}	
		
	}

	private IEnumerator JumpDirection(Vector3 direction)
	{
		Vector3 startPosition  = transform.position;
		targetPosition = targetPosition + (direction * jumpHeight);
		float elapsedTime = 0;
         
		while (elapsedTime < duration)
		{
			transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / duration));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}

	private bool CheckForObstacle(int obstacleType)
	{
		Vector3 raycastOriginPoint = transform.position;

		switch (obstacleType)
		{
			case (int)Obstacles.Block:
				raycastOriginPoint += new Vector3(0, RAYCAST_ORIGIN_BLOCK_Y, 0);
				break;
			case (int)Obstacles.Wall:
				raycastOriginPoint += new Vector3(0, RAYCAST_ORIGIN_WALL_Y, 0);
				break;
		}
		
		RaycastHit hit;
		if (Physics.Raycast(origin: raycastOriginPoint, direction: -transform.right, out hit, 
			    maxDistance: RAYCAST_MAX_DISTANCE, layerMask: Physics.AllLayers,
			    queryTriggerInteraction: QueryTriggerInteraction.UseGlobal))
		{
			return true;
		}

		else
		{
			return false;
		}
	}
}

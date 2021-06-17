using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Camera_St : MonoBehaviour
/*{
	public Transform[] movePoints;
	public float moveSpeed;

	private int currentPoint;

	void Start()
	{
		transform.position = movePoints[0].position; currentPoint = 0;
		currentPoint = 0;
	}
	void Update()
    {
		if (transform.position == movePoints[currentPoint].position) 
			currentPoint++;

		if (currentPoint >= movePoints.Length)
			currentPoint = 0;

		transform.position = Vector3.MoveTowards(transform.position, movePoints[currentPoint].position, moveSpeed * Time.deltaTime);
	}
}*/

{
	public Transform target;

	private Vector3 offset;

	void Start()
	{
		offset = transform.position;    // 현재 위치
	}
	void Update()
	{
		transform.position = target.position;
		transform.position = target.position + offset;
	}
}
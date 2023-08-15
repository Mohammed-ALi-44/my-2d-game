using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
	 WaveConfig waveConfigs;
	List<Transform> wayPoints;
	int wayPointsIndex = 0;

	// Use this for initialization
	void Start () 
	{
		wayPoints = waveConfigs.GetWayPoints();
		transform.position = wayPoints[wayPointsIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move();
	
	}
	private void Move()
    {
		if (wayPointsIndex <= wayPoints.Count - 1)
		{
			var targetPosition = wayPoints[wayPointsIndex].transform.position;
			var movmentThisFrame = waveConfigs.GetMoveSpeed() * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, targetPosition, movmentThisFrame);
			if (transform.position == targetPosition)
			{
				wayPointsIndex++;

			}
		}
		else
		{
			Destroy(gameObject);

		}
	}
	public void SetWaveConfig(WaveConfig waveconfig)
    {
		this.waveConfigs = waveconfig;
    }
}

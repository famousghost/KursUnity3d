using UnityEngine;
using System.Collections.Generic;

public class FlappyObstaclesSpawner : MonoBehaviour {

	public GameObject obstaclePrefab;

    [SerializeField]
	List<GameObject> spawnedObstacles = new List<GameObject>();

    private float randGapHeight;

    private float randYValue;

    private float maxValueGapHeight = 4.0f;

    private float minValueGapHeight = 8.0f;

    private float minValueY = 3.0f;

    private float maxValueY = -3.0f;

    private int multiplieValue = 1;

    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            randGapHeight = Random.Range(minValueGapHeight, maxValueGapHeight);
            randYValue = Random.Range(minValueY, maxValueY);
            Spawn(8.0f * multiplieValue, randYValue, randGapHeight);
        }
    }

	void Spawn( float x, float y, float gapHeight ) {
        GameObject spawned = GameObject.Instantiate( obstaclePrefab );
        spawned.transform.parent = transform;
		spawned.transform.position = new Vector3( x, y, 0 );
        if(spawnedObstacles.Count <= 14)
		    spawnedObstacles.Add( spawned );
        else
        {
            Destroy(spawnedObstacles[0]);
            spawnedObstacles.RemoveAt(0);
            spawnedObstacles.Add(spawned);
        }

        Transform bottomTransform = spawned.transform.FindChild( "Bottom" );
        Transform topTransform = spawned.transform.FindChild( "Top" );
        float bottomY = -gapHeight/2;
        float topY = +gapHeight/2;
        bottomTransform.localPosition = Vector3.up * bottomY;
        topTransform.localPosition = Vector3.up * topY;
        multiplieValue++;
    }

    public void SpawnObstacle()
    {
        randGapHeight = Random.Range(minValueGapHeight, maxValueGapHeight);
        randYValue = Random.Range(minValueY, maxValueY);
        Spawn(8.0f * multiplieValue, randYValue, randGapHeight);
    }

}

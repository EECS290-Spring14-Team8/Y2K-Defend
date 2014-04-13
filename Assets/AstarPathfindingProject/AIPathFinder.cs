using UnityEngine;
using System.Collections;
using Pathfinding;

public class AIPathFinder : MonoBehaviour {
	public Transform target;
	Seeker seeker;
	Path path;
	int currentWaypoint;
	public float speed = 20;
	public float wayPointDist = 2f;
	CharacterController charctlr;

	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker>();
		seeker.StartPath(transform.position,target.transform.position,OnPathComplete);
		charctlr = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPathComplete(Path p){
		if(!p.error){
			path = p;
			currentWaypoint = 0	;
		}
		else{

		}

	}
	void FixedUpdate(){
		if(path == null){
			return;
		}
		if(currentWaypoint >=path.vectorPath.Count){
			return;
		}
		Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized * speed;
		charctlr.SimpleMove(dir);
		if(Vector3.Distance(transform.position,path.vectorPath[currentWaypoint]) < wayPointDist){
			currentWaypoint++;
		}
	}
}

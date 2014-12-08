using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class move : MonoBehaviour {
	public List<int> seed1;
	public List<int> seed2;
	public List<int> path;
	GameObject checker;
	GameObject goal;
	public List<GameObject> openlist;
	int xi = 0;
	public bool run = false;
	public bool fin = false;
	float time;
	public float cd,temp;
	public bool done = false;
	// Use this for initialization
	void Start () {
		time = Time.time;
		checker = GameObject.FindGameObjectWithTag("check");
		goal = GameObject.FindGameObjectWithTag("goal");
		checker.transform.position = new Vector3(transform.position.x,transform.position.y, 1); 
		GameObject[] test = GameObject.FindGameObjectsWithTag("floor");
		for(int i = 0; i < test.Length; i++){
			openlist.Add(test[i]);
		}


	}
	public void seeds(List<int> a,List<int> b,int k){
		seed1 = a;
		seed2 = b;
		path.Clear();
		xi = 0;

		int xz = Random.Range(0,seed1.Count);
		for(int i = 0; i < xz;i++){
			path.Add(seed1[i]);
		}
		for(int i = xz; i < seed2.Count;i++){
			path.Add(seed2[i]);
		}

		//Debug.Log(path.Count);

		for(int i = 0; i < path.Count;i++){
			int rand = Random.Range(0,5);
			if(rand == 4){
				path[i] = Random.Range(0,4);
			}
			
		}
		run = true;
		fin = false;
	}
	// Update is called once per frame
	void Update () {
		if(transform.position == goal.transform.position){
			done = true;
			Debug.Log("done");
		}

		if(done == false && cd <= Time.time - time){
			checker.transform.position = new Vector3(transform.position.x,transform.position.y, 1);

			time = Time.time;
			if(run && path[xi] == 0){
				checker.transform.position = new Vector3(transform.position.x + 1,transform.position.y, 1); 
				for(int j = 0; j < openlist.Count -1; j++){
					if(openlist[j].transform.position == checker.transform.position){
						transform.position = new Vector3(transform.position.x + 1,transform.position.y, 0);
						break;
					}
				}

			}
			if(run && path[xi] == 1){
				checker.transform.position = new Vector3(transform.position.x,transform.position.y + 1, 1); 
				for(int j = 0; j < openlist.Count -1; j++){
					if(openlist[j].transform.position == checker.transform.position){
						transform.position = new Vector3(transform.position.x,transform.position.y + 1, 0);
						break;
					}
				}
			}
			if(run && path[xi] == 2){
				checker.transform.position = new Vector3(transform.position.x - 1,transform.position.y, 1); 
				for(int j = 0; j < openlist.Count -1; j++){
					if(openlist[j].transform.position == checker.transform.position){
						transform.position = new Vector3(transform.position.x - 1,transform.position.y, 0);
						break;
					}
				}
			}
			if(run && path[xi] == 3){
				checker.transform.position = new Vector3(transform.position.x,transform.position.y - 1, 1); 
				for(int j = 0; j < openlist.Count -1; j++){
					if(openlist[j].transform.position == checker.transform.position){
						transform.position = new Vector3(transform.position.x,transform.position.y-1, 0);
						break;
					}
				}
			}
			if(xi < path.Count -1){
				xi++;
			}else{

				temp = Vector3.Distance(transform.position,goal.transform.position);
				run = false;
				fin = true;
			}
		}
	}

}


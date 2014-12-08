using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.IO; 

public class instance : MonoBehaviour {
	public GameObject wall;
	public GameObject floor;
	public GameObject player;
	public GameObject goal;
	public List<GameObject> aplayer;
	public int runs;
	public string name;
	public float d1,d2;
	public List<int>s1;
	public List<int>s2;
	public List<int>bs1;
	public List<int>bs2;
	int sx = 0;
	int sy = 0;
	GameObject something;
	public int amount;
	int aamount;
	// Use this for initialization
	void Start () {
		aamount = amount;
		for(int i = 0; i < runs;i++){
			s1.Add(Random.Range(0,4));
			s2.Add(Random.Range(0,4));
		}
		d1 = 99f;
		d2 = 99f;
		string line = "";
		int x = 0;
		int y = 0;
		string final = "Assets/" + name + ".txt";
		StreamReader theReader = new StreamReader(final, Encoding.Default);
		while ((line = theReader.ReadLine()) != null)
		{
			
			for(int i = 0; i < line.Length;i++){
				if (line[i] == '.'){
					Instantiate(floor, new Vector3(x, -y, 1), Quaternion.identity);
				}
				if(line[i] == 'w'){
					Instantiate(wall, new Vector3(x, -y, 0), Quaternion.identity);
				}
				if(line[i] == 'p'){
					sx = x;
					sy = -y;
					Instantiate(floor, new Vector3(x, -y, 1), Quaternion.identity);
					for(int iz = 0; iz < 8; iz++){
						something = Instantiate(player, new Vector3(x, -y, 0), Quaternion.identity) as GameObject;
						something.GetComponent<move>().seeds(s1,s2,runs);
						aplayer.Add (something);
						aamount--;
					}
				}
				if(line[i] == 'f'){
					Instantiate(floor, new Vector3(x, -y, 1), Quaternion.identity);
					Instantiate(goal, new Vector3(x, -y, 0), Quaternion.identity);
				}
				x++;
			}
			
			//Instantiate(bwall, new Vector3(x, -y, .5f), Quaternion.identity);
			
			x = 0;
			y++;
		}


		theReader.Close();
		
	}

	
	// Update is called once per frame
	void Update () {
		for(int iz = 0; iz < aplayer.Count;iz++){
			if(aplayer[iz].GetComponent<move>().done == true){
				for(int kk = 0; kk < aplayer.Count;kk++){
					aplayer[kk].GetComponent<move>().done = true;
				}
			}
			if(aamount > 0 && aplayer[iz].GetComponent<move>().fin == true){
				//print (aplayer[iz].GetComponent<move>().temp );
				if(aplayer[iz].GetComponent<move>().temp < d1){
					d2 = d1;
					bs2.Clear();
					for (int i = 0; i < bs1.Count;i++){
						bs2.Add(bs1[i]);
					} 
					bs1.Clear();
					for (int i = 0; i < aplayer[iz].GetComponent<move>().path.Count;i++){
						//print (aplayer[iz].GetComponent<move>().path.Count);
						bs1.Add(aplayer[iz].GetComponent<move>().path[i]);
					} 
					d1 = aplayer[iz].GetComponent<move>().temp;
				}else if(aplayer[iz].GetComponent<move>().temp <= d2){
					d2 = aplayer[iz].GetComponent<move>().temp;
					bs2.Clear();
					for (int i = 0; i < aplayer[iz].GetComponent<move>().path.Count;i++){
						bs2.Add(aplayer[iz].GetComponent<move>().path[i]);
					}
				}
				aplayer[iz].GetComponent<move>().fin = false;
				aplayer[iz].transform.position = new Vector3(sx,sy,0);
				aplayer[iz].GetComponent<move>().seeds(s1,s2,runs);
				aamount--;
			}
		}
		if(aamount <= 0){
			int l = 0;
			//print(l);
			for(int iz = 0; iz < aplayer.Count;iz++){
				if(aplayer[iz].GetComponent<move>().fin == true){
					l++;
				}
			}
			//d1 = 99f;
			//d2 = 99f;
			if(l >= aplayer.Count-1){
				s1.Clear();
				for (int i = 0; i < bs1.Count;i++){
					s1.Add(bs1[i]);
				}
				s2.Clear();
				for (int i = 0; i < bs2.Count;i++){
					s2.Add(bs2[i]);
				}
				aamount = amount;
				for(int iz = 0; iz < aplayer.Count;iz++){
					aplayer[iz].GetComponent<move>().fin = false;
					aplayer[iz].transform.position = new Vector3(sx,sy,0);
					aplayer[iz].GetComponent<move>().seeds(s1,s2,runs);
					aamount--;
				}
			}
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using SimpleJSON;
using Summarize;

public class main : MonoBehaviour {
	SaveExample save = new SaveExample();
	ruins Treasure = new ruins();
	public struct FarmStatus
	{
			public bool reclaim;
			public bool harvest;
			public bool plant;
	}
	FarmStatus farm1;
	string[] character_array = new string[]{"cq", "sy", "tong"};

	void Start () {

		//string time = System.DateTime.Now.AddMinutes(5).ToString("yyyyMMddHHmmss");
		
		//Debug.Log (time);

		string filepath = Application.persistentDataPath  + @"/save.txt";		//set path to save the file, another path will be set for iOS
		if (File.Exists (filepath)) {								//To see whether the path exists or not
			save.load_file (filepath);	//If existing, load file

			camera.transform.position = new Vector3(-256.1298f,218.9613f,34.28522f);     //need the camera postion in the save file to replace these numbers

			System.DateTime currentTime = new System.DateTime();
			currentTime = System.DateTime.Now;
			int year = currentTime.Year;
			int month = currentTime.Month;
			int day = currentTime.Day;
			if((year != save.N["SaveTime"]["Year"].AsInt || month!=save.N["SaveTime"]["Month"].AsInt)||day!=save.N["SaveTime"]["Day"].AsInt)
			{
				Treasure.getTreasure();
			}

			farm1.reclaim = false;   // in fact, should get the value from the save file
			farm1.plant = false;
			farm1.harvest = false;

			
		} else {													//If not existing, initialize the JSONNode and save the initial data to the save file 
			
			string initialize_string = "{\"number\":0}";			//initialize JSONNode N----need update
			
			save.N = JSON.Parse (initialize_string);						//Parse, i.e. let the string to be JSON format

			initialize_json ();

			save.save_file (filepath);											//save the file
			camera.transform.position = new Vector3(-256.1298f,218.9613f,34.28522f);

			/*starting movies*/
			/*teaching*/



		}

		/*Testing
		save.N ["Food"].AsInt = 1;
		save.N ["Money"].AsInt = 2;
		save.N ["Wood"].AsInt = 3;
		save.N ["Stone"].AsInt = 4;

		save.N ["Control"] = "cq";
		save.N ["ActiveCharacter"].AsInt = 2;
		*/

		save.N ["ActiveCharacter"].AsInt = 3;
		save.N ["Control"] = "cq";
		save.N ["Character"] ["sy"] ["Active"].AsBool = true;
		save.N ["Character"] ["tong"] ["Active"].AsBool = true;

		/*
		Debug.Log (save.N ["Character"] ["cq"] ["Active"].AsBool);
		Debug.Log (save.N ["Character"] ["sy"] ["Active"].AsBool);
		Debug.Log (save.N ["Character"] ["tong"] ["Active"].AsBool);
		*/

	}

	void Update(){

		material_number ();		//would like to put this function in "Start()", but need to call this function everytime when the number of food/money/wood/stone is changed. Just have a discuss later.
		character_select ();	//would like to put this function in "Start()", but need to call this function everytime when the SP of the character is changed. Just have a dicuss later.
		character_show ();		//would like to put this function in "Start()", but need to call this function everytime when the SP of the character is changed. Just have a dicuss later.

		if (Input.GetMouseButtonDown (0)) {  
			//摄像机到点击位置的的射线  
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);  
			RaycastHit hit;  
			if (Physics.Raycast (ray, out hit)) {  
			    
				Vector3 hitpoint = hit.point;
			switch (hit.transform.gameObject.tag)
				{
				case "farm":
					if (farm1.reclaim == false)
					{
						Debug.Log("reclaim");  
						farm1.reclaim = true;
						break;
					}
						if(farm1.plant == false)
					{
						Debug.Log ("plant");
						farm1.plant = true;
						break;
					}
					else
						if(farm1.harvest ==false)
					{
						farm1.harvest = true;     //this should after sometime
						break;
					}
					else
					{
						Debug.Log ("harvest");
						farm1.plant = false;
						farm1.harvest = false;
						break;
					}
					break;
				case "forest":
					Debug.Log("felling");
					break;
				case "ruins":
					//Debug.Log ("ruins");
					Treasure.dig(hitpoint);
					break;
					//more activities to add
				}

			}  
		}
		//		if (Input.touchCount == 1) {
		//			Touch touch = Input.GetTouch (0);
						//			if (touch.phase == TouchPhase.Began) {
						//					Ray ray = Camera.main.ScreenPointToRay (touch.position);
						//					RaycastHit hit;
						//					if (Physics.Raycast (ray, out hit)) {
						//						GameObject obj = hit.transform.gameObject; 
						//						if (obj.name == "Terrain") {
						//							man.SetDestination (hit.point);
						//						}
						//					}		
						//				}
						//			}	
	}

	public void initialize_json(){

		save.N["Camera"]["Position"]["x"].AsFloat = 0;
		save.N["Camera"]["Position"]["y"].AsFloat = 0;
		save.N["Camera"]["Position"]["z"].AsFloat = 0;
		save.N["Camera"]["Rotation"]["x"].AsFloat = 0;
		save.N["Camera"]["Rotation"]["y"].AsFloat = 0;
		save.N["Camera"]["Rotation"]["z"].AsFloat = 0;
		
		save.N["Gold"].AsInt = 0;
		save.N["Wood"].AsInt = 0;
		save.N["Food"].AsInt = 0;
		save.N["Stone"].AsInt = 0;
		
		save.N["Control"] = "cq";
		
		save.N["Character"]["sy"]["SP"].AsInt = 8;
		save.N["Character"]["sy"]["RecoverLastTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Character"]["sy"]["Sick"].AsBool = false;
		save.N["Character"]["sy"]["Active"].AsBool = false;
		save.N["Character"]["sy"]["position"]["scence"] = "scence1";
		save.N["Character"]["sy"]["position"]["x"].AsFloat = 0;
		save.N["Character"]["sy"]["position"]["y"].AsFloat = 0;
		save.N["Character"]["sy"]["position"]["z"].AsFloat = 0;
		
		save.N["Character"]["cq"]["SP"].AsInt = 10;
		save.N["Character"]["cq"]["RecoverLastTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Character"]["cq"]["Sick"].AsBool = false;
		save.N["Character"]["cq"]["Active"].AsBool = true;
		save.N["Character"]["cq"]["position"]["scence"] = "scence1";
		save.N["Character"]["cq"]["position"]["x"].AsFloat = 0;
		save.N["Character"]["cq"]["position"]["y"].AsFloat = 0;
		save.N["Character"]["cq"]["position"]["z"].AsFloat = 0;
		
		save.N["Character"]["tong"]["SP"].AsInt = 7;
		save.N["Character"]["tong"]["RecoverLastTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Character"]["tong"]["Sick"].AsBool = false;
		save.N["Character"]["tong"]["Active"].AsBool = false;
		save.N["Character"]["tong"]["position"]["scence"] = "scence1";
		save.N["Character"]["tong"]["position"]["x"].AsFloat = 0;
		save.N["Character"]["tong"]["position"]["y"].AsFloat = 0;
		save.N["Character"]["tong"]["position"]["z"].AsFloat = 0;
		
		save.N["Character"]["xe1"]["SP"].AsInt = 9;
		save.N["Character"]["xe1"]["RecoverLastTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Character"]["xe1"]["Sick"].AsBool = false;
		save.N["Character"]["xe1"]["Active"].AsBool = false;
		save.N["Character"]["xe1"]["position"]["scence"] = "scence1";
		save.N["Character"]["xe1"]["position"]["x"].AsFloat = 0;
		save.N["Character"]["xe1"]["position"]["y"].AsFloat = 0;
		save.N["Character"]["xe1"]["position"]["z"].AsFloat = 0;
		
		save.N["Character"]["xe2"]["SP"].AsInt = 10;
		save.N["Character"]["xe2"]["RecoverLastTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Character"]["xe2"]["Sick"].AsBool = false;
		save.N["Character"]["xe2"]["Active"].AsBool = false;
		save.N["Character"]["xe2"]["position"]["scence"] = "scence1";
		save.N["Character"]["xe2"]["position"]["x"].AsFloat = 0;
		save.N["Character"]["xe2"]["position"]["y"].AsFloat = 0;
		save.N["Character"]["xe2"]["position"]["z"].AsFloat = 0;
		
		save.N["Character"]["ssy"]["SP"].AsInt = 6;
		save.N["Character"]["ssy"]["RecoverLastTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Character"]["ssy"]["Sick"].AsBool = false;
		save.N["Character"]["ssy"]["Active"].AsBool = false;
		save.N["Character"]["ssy"]["position"]["scence"] = "scence1";
		save.N["Character"]["ssy"]["position"]["x"].AsFloat = 0;
		save.N["Character"]["ssy"]["position"]["y"].AsFloat = 0;
		save.N["Character"]["ssy"]["position"]["z"].AsFloat = 0;
		
		save.N["Character"]["ll"]["SP"].AsInt = 12;
		save.N["Character"]["ll"]["RecoverLastTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Character"]["ll"]["Sick"].AsBool = false;
		save.N["Character"]["ll"]["Active"].AsBool = false;
		save.N["Character"]["ll"]["position"]["scence"] = "scence1";
		save.N["Character"]["ll"]["position"]["x"].AsFloat = 0;
		save.N["Character"]["ll"]["position"]["y"].AsFloat = 0;
		save.N["Character"]["ll"]["position"]["z"].AsFloat = 0;

		save.N ["ActiveCharacter"].AsInt = 1;
		
		save.N["Impression"]["sy"]["cq"].AsInt = 0;
		save.N["Impression"]["sy"]["tong"].AsInt = 0;
		save.N["Impression"]["sy"]["xe1"].AsInt = 0;
		save.N["Impression"]["sy"]["xe2"].AsInt = 0;
		save.N["Impression"]["sy"]["ssy"].AsInt = 0;
		save.N["Impression"]["sy"]["ll"].AsInt = 0;
		
		save.N["Impression"]["cq"]["sy"].AsInt = 0;
		save.N["Impression"]["cq"]["tong"].AsInt = 0;
		save.N["Impression"]["cq"]["xe1"].AsInt = 0;
		save.N["Impression"]["cq"]["xe2"].AsInt = 0;
		save.N["Impression"]["cq"]["ssy"].AsInt = 0;
		save.N["Impression"]["cq"]["ll"].AsInt = 0;
		
		save.N["Impression"]["tong"]["sy"].AsInt = 0;
		save.N["Impression"]["tong"]["cq"].AsInt = 0;
		save.N["Impression"]["tong"]["xe1"].AsInt = 0;
		save.N["Impression"]["tong"]["xe2"].AsInt = 0;
		save.N["Impression"]["tong"]["ssy"].AsInt = 0;
		save.N["Impression"]["tong"]["ll"].AsInt = 0;
		
		save.N["Impression"]["xe1"]["sy"].AsInt = 0;
		save.N["Impression"]["xe1"]["cq"].AsInt = 0;
		save.N["Impression"]["xe1"]["tong"].AsInt = 0;
		save.N["Impression"]["xe1"]["xe2"].AsInt = 0;
		save.N["Impression"]["xe1"]["ssy"].AsInt = 0;
		save.N["Impression"]["xe1"]["ll"].AsInt = 0;
		
		save.N["Impression"]["xe2"]["sy"].AsInt = 0;
		save.N["Impression"]["xe2"]["cq"].AsInt = 0;
		save.N["Impression"]["xe2"]["tong"].AsInt = 0;
		save.N["Impression"]["xe2"]["xe1"].AsInt = 0;
		save.N["Impression"]["xe2"]["ssy"].AsInt = 0;
		save.N["Impression"]["xe2"]["ll"].AsInt = 0;
		
		save.N["Impression"]["ssy"]["sy"].AsInt = 0;
		save.N["Impression"]["ssy"]["cq"].AsInt = 0;
		save.N["Impression"]["ssy"]["tong"].AsInt = 0;
		save.N["Impression"]["ssy"]["xe1"].AsInt = 0;
		save.N["Impression"]["ssy"]["xe2"].AsInt = 0;
		save.N["Impression"]["ssy"]["ll"].AsInt = 0;
		
		save.N["Impression"]["ll"]["sy"].AsInt = 0;
		save.N["Impression"]["ll"]["cq"].AsInt = 0;
		save.N["Impression"]["ll"]["tong"].AsInt = 0;
		save.N["Impression"]["ll"]["xe1"].AsInt = 0;
		save.N["Impression"]["ll"]["xe2"].AsInt = 0;
		save.N["Impression"]["ll"]["ssy"].AsInt = 0;
		
		save.N["Farmland"]["Farm1"]["Status"].AsInt = 1;
		save.N["Farmland"]["Farm1"]["PlantTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Farmland"]["Farm1"]["PlantType"] = "None";
		
		save.N["Farmland"]["Farm2"]["Status"].AsInt = 1;
		save.N["Farmland"]["Farm2"]["PlantTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Farmland"]["Farm2"]["PlantType"] = "None";
		
		save.N["Farmland"]["Farm3"]["Status"].AsInt = 1;
		save.N["Farmland"]["Farm3"]["PlantTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Farmland"]["Farm3"]["PlantType"] = "None";
		
		save.N["Farmland"]["Farm4"]["Status"].AsInt = 1;
		save.N["Farmland"]["Farm4"]["PlantTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Farmland"]["Farm4"]["PlantType"] = "None";
		
		save.N["Farmland"]["Farm5"]["Status"].AsInt = 1;
		save.N["Farmland"]["Farm5"]["PlantTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Farmland"]["Farm5"]["PlantType"] = "None";
		
		save.N["Farmland"]["Farm6"]["Status"].AsInt = 1;
		save.N["Farmland"]["Farm6"]["PlantTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Farmland"]["Farm6"]["PlantType"] = "None";
		
		save.N["Farmland"]["Farm7"]["Status"].AsInt = 1;
		save.N["Farmland"]["Farm7"]["PlantTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Farmland"]["Farm7"]["PlantType"] = "None";
		
		save.N["Farmland"]["Farm8"]["Status"].AsInt = 1;
		save.N["Farmland"]["Farm8"]["PlantTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		save.N["Farmland"]["Farm8"]["PlantType"] = "None";
		
		save.N["Forest"]["Tree1"]["Felling"].AsBool = true;
		save.N["Forest"]["Tree1"]["StartTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		
		save.N["Forest"]["Tree2"]["Felling"].AsBool = true;
		save.N["Forest"]["Tree2"]["StartTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		
		save.N["Forest"]["Tree3"]["Felling"].AsBool = true;
		save.N["Forest"]["Tree3"]["StartTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		
		save.N["Forest"]["Tree4"]["Felling"].AsBool = true;
		save.N["Forest"]["Tree4"]["StartTime"] = System.DateTime.Now.ToString ("yyyyMMddHHmmss");
		
		save.N["Yan"]["Type1"].AsInt = 0;
		
		save.N["Building"]["Building1"].AsInt = 0;
		save.N["Building"]["Building2"].AsInt = 0;
		save.N["Building"]["Building3"].AsInt = 0;
		save.N["Building"]["Building4"].AsInt = 0;
		save.N["Building"]["Building5"].AsInt = 0;
		
		save.N["Achievement"]["1"].AsBool = false;
		save.N["Achievement"]["2"].AsBool = false;
		save.N["Achievement"]["3"].AsBool = false;
		save.N["Achievement"]["4"].AsBool = false;
		save.N["Achievement"]["5"].AsBool = false;
		save.N["Achievement"]["6"].AsBool = false;
		save.N["Achievement"]["7"].AsBool = false;
		save.N["Achievement"]["8"].AsBool = false;
		save.N["Achievement"]["9"].AsBool = false;
		save.N["Achievement"]["10"].AsBool = false;
		
		save.N["SaveTime"]["Year"].AsInt = System.DateTime.Now.Year;
		save.N["SaveTime"]["Month"].AsInt = System.DateTime.Now.Month;
		save.N["SaveTime"]["Day"].AsInt = System.DateTime.Now.Day;
		
		save.N["Counter"]["MushroomGain"].AsInt = 0;
		save.N["Counter"]["TreeFell"].AsInt = 0;
		save.N["Counter"]["Mushroom1Plant"].AsInt = 0;
		save.N["Counter"]["Mushroom2Plant"].AsInt = 0;
		save.N["Counter"]["Mushroom3Plant"].AsInt = 0;
		save.N["Counter"]["Mushroom4Plant"].AsInt = 0;
		save.N["Counter"]["GoldGain"].AsInt = 0;
		save.N["Counter"]["StoneGain"].AsInt = 0;
		save.N["Counter"]["BuildingLevel1"].AsInt = 0;
		save.N["Counter"]["ImpressionLevel1"].AsInt = 0;
		
	}

	public void material_number(){

		GameObject.Find ("Label_Food").GetComponentInChildren<UILabel> ().text = save.N["Food"].AsInt.ToString();
		GameObject.Find ("Label_Money").GetComponentInChildren<UILabel> ().text = save.N["Money"].AsInt.ToString();
		GameObject.Find ("Label_Wood").GetComponentInChildren<UILabel> ().text = save.N["Wood"].AsInt.ToString();
		GameObject.Find ("Label_Stone").GetComponentInChildren<UILabel> ().text = save.N["Stone"].AsInt.ToString ();

	}

	public void character_select(){

		switch (save.N ["Control"]) {
		case "sy":
			GameObject.Find ("Sprite_Character_Icon").GetComponentInChildren<UISprite> ().spriteName = "Character_Icon_sy";
			GameObject.Find ("Label_Character_SP").GetComponentInChildren<UILabel>().text = save.N["Character"]["sy"]["SP"].AsInt.ToString() + " / " + Summarize.character_sp.sy_total.ToString ();
			if ( save.N["ActiveCharacter"].AsInt == 1 ){
				GameObject.Find ("Button_Character_Select_Background").GetComponentInChildren<UISprite>().spriteName = "SY_Name_1";
			} else{
				GameObject.Find ("Button_Character_Select_Background").GetComponentInChildren<UISprite>().spriteName = "SY_Name_2";
			}
			break;
		case "cq":
			GameObject.Find ("Sprite_Character_Icon").GetComponentInChildren<UISprite> ().spriteName = "Character_Icon_cq";
			GameObject.Find ("Label_Character_SP").GetComponentInChildren<UILabel>().text = save.N["Character"]["cq"]["SP"].AsInt.ToString() + " / " + Summarize.character_sp.cq_total.ToString ();
			if ( save.N["ActiveCharacter"].AsInt == 1 ){
				GameObject.Find ("Button_Character_Select_Background").GetComponentInChildren<UISprite>().spriteName = "CQ_Name_1";
			} else{
				GameObject.Find ("Button_Character_Select_Background").GetComponentInChildren<UISprite>().spriteName = "CQ_Name_2";
			}
			break;
		case "tong":
			GameObject.Find ("Sprite_Character_Icon").GetComponentInChildren<UISprite> ().spriteName = "Character_Icon_tong";
			GameObject.Find ("Label_Character_SP").GetComponentInChildren<UILabel>().text = save.N["Character"]["tong"]["SP"].AsInt.ToString() + " / " + Summarize.character_sp.tong_total.ToString ();
			if ( save.N["ActiveCharacter"].AsInt == 1 ){
				GameObject.Find ("Button_Character_Select_Background").GetComponentInChildren<UISprite>().spriteName = "TONG_Name_1";
			} else{
				GameObject.Find ("Button_Character_Select_Background").GetComponentInChildren<UISprite>().spriteName = "TONG_Name_2";
			}
			break;
		}

	}

	public void character_show(){

		GameObject.Find ("Label_SP_sy").GetComponentInChildren<UILabel>().text = save.N["Character"]["sy"]["SP"].AsInt.ToString() + " / " + Summarize.character_sp.sy_total.ToString ();
		GameObject.Find ("Label_SP_cq").GetComponentInChildren<UILabel>().text = save.N["Character"]["cq"]["SP"].AsInt.ToString() + " / " + Summarize.character_sp.cq_total.ToString ();
		GameObject.Find ("Label_SP_tong").GetComponentInChildren<UILabel>().text = save.N["Character"]["tong"]["SP"].AsInt.ToString() + " / " + Summarize.character_sp.tong_total.ToString ();

	}

	void Awake () 
	{	
		//获取需要监听的按钮对象
		GameObject button = GameObject.Find("Button_Character_Select");
		//设置这个按钮的监听，指向本类的ButtonClick方法中。
		UIEventListener.Get(button).onClick = ButtonClick;
	}

	void ButtonClick(GameObject button)
	{

		/*Testing

		UIPlayTween script = GetComponent<UIPlayTween>();

		script.enabled = true;

		GameObject.Find ("Sprite_Character_SP_CQ").GetComponent<TweenPosition> ().to.y = -290;

		script.Play (true);

		*/

		if( save.N["ActiveCharacter"].AsInt > 1 ){

			int i = 1;

			for ( int a = 0; a < 3; a++ ){

				if ( save.N["Character"][character_array[a]]["Active"].AsBool == true && character_array[a].CompareTo (save.N["Control"]) != 0 ){
					
					show_sp_bar( character_array[a], i );

					//Debug.Log (character_array[a] + " " + save.N["Control"]);

					i = i + 1;
					
				}

			}

		}
		
	}

	void show_sp_bar(string character, int i){

		//Debug.Log (character);

		//Debug.Log (character +  i);

		//Debug.Log (GameObject.Find ("Sprite_Character_SP_" + character).GetComponent<TweenPosition> ().to.y);

		UIPlayTween playtween = GameObject.Find ("Trigger_Character_SP_" + character).GetComponent<UIPlayTween>();

		GameObject.Find ("Sprite_Character_SP_" + character).GetComponent<TweenPosition> ().to.y = ( -145 * i );

		playtween.Play (true);



	}

}


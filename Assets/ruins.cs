using UnityEngine;
using System.Collections;
using Summarize;

public class ruins : MonoBehaviour {

	Vector2[] Position = new Vector2[5];
	bool[] DigOrNot = {false,false,false,false,false};
	void start()
	{
		for (int i=0; i<5; i++) {
			Position[i] = new Vector2(0.0f,0.0f);
				}
	}
	private float GetDistance(Vector2 pointA, Vector2 pointB)
	{
		float x = pointA.x-pointB.x;
		float y = pointA.y - pointB.y;
		return Mathf.Sqrt (x*x+y*y);
	}
	public void getTreasure()
	{
		for (int i=0; i<5; i++) {
		//	Debug.Log ("Treasure");
			Position[i] = new Vector2(Random.Range (-0.16f,0.17f),Random.Range (-0.11f,0.03f));
			DigOrNot[i] = true;
			//Add Markers here.
				}
	}
	public void dig(Vector3 hitposition)
	{
		Vector2 hitposition2D = new Vector2 (hitposition.x,hitposition.z);
		float Distance;
		for (int i=0; i<5; i++) {
			Distance = GetDistance(hitposition2D,Position[i]);
			if(Distance < 0.1&&DigOrNot[i]==true)
			{

				Debug.Log ("dig");
				DigOrNot[i] = false;
				float ProbSum1 = 0.0f;
				float ProbSum2 = 0.0f;
				float rand = Random.Range (0.0f,1.0f);
				ProbSum1 = Summarize.excavation.buff_prob*Summarize.excavation.sp_buff*Summarize.excavation.sp_buff1_prob;
				if(rand>0.0f&&rand<ProbSum1)
					Debug.Log ("sp_buff1");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.buff_prob*Summarize.excavation.sp_buff*Summarize.excavation.sp_buff2_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("sp_buff2");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.buff_prob*Summarize.excavation.sp_buff*Summarize.excavation.sp_buff3_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("sp_buff3");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.buff_prob*Summarize.excavation.sp_buff*Summarize.excavation.sp_buff4_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("sp_buff4");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.buff_prob*Summarize.excavation.sp_buff*Summarize.excavation.sp_buff5_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("sp_buff5");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.buff_prob*Summarize.excavation.task_buff*Summarize.excavation.task_buff1_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("task_buff1");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.buff_prob*Summarize.excavation.task_buff*Summarize.excavation.task_buff1_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("task_buff1");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.buff_prob*Summarize.excavation.task_buff*Summarize.excavation.task_buff2_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("task_buff2");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.buff_prob*Summarize.excavation.task_buff*Summarize.excavation.task_buff3_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("task_buff3");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.buff_prob*Summarize.excavation.task_buff*Summarize.excavation.task_buff4_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("task_buff4");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.buff_prob*Summarize.excavation.task_buff*Summarize.excavation.task_buff5_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("task_buff5");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.wood_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("wood");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.food_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("food");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.money_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("money");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.money_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("money");
				ProbSum2 = ProbSum1;
				ProbSum1 = ProbSum1+Summarize.excavation.stone_prob;
				if(rand>ProbSum2&&rand<ProbSum1)
					Debug.Log ("stone");
				break;
			}
		}
	}
	
}

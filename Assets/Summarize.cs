using UnityEngine;
using System.Collections;

/*
！注意我！注意我！注意我！注意我！注意我！
如果要在其他SCRIPT引用這個SCRIPT裡的常數數據
請在該SCRIPT的HEADER加上　"using Summarize;"（不用加引號）
然後引用的例子（character class裡的cq_yan）：
Summarize.character.cq_yan
就會return 0.05這個數了～
*/

namespace Summarize
{
	public static class character{						//角色特殊屬性
		public const float cq_yan = 0.05f;				//初七偃術速度+5％
		public const float sy_sewing = 0.1f;				//沈夜縫紉速度+10％
		public const float sy_cooking = 0.1f;			//烹饪速度+10%
		public const float tong_yan = 0.05f;				//瞳偃术速度+5%
		public const float x1_yan = 0.15f;				//1.0偃术速度+15%
		public const float x2_yan = 0.1f;				//2.0偃术速度+10%
	}

	public static class character_sp{					//角色体力　total: 體力總值　recover：回恢一點體力所需時間（單位：秒）
		public const int cq_total = 10;					//初七體力總值
		public const int cq_recover = 240;				//初七回恢一點體力所需時間（單位：秒）
		public const int sy_total = 8;					//沈夜
		public const int sy_recover = 300;
		public const int tong_total = 7;				//瞳
		public const int tong_recover = 300;
		public const int x1_total = 9;					//1.0
		public const int x1_recover = 270;
		public const int x2_total = 10;					//2.0
		public const int x2_recover = 270;
		public const int ssy_total = 6;					//小沈夜
		public const int ssy_recover = 300;
		public const int ll_total = 12;					//麗麗
		public const int ll_recover = 240;
	}

	public static class character_sleep{				//角色睡眠時間		INT為時數（24小時制）
		public const int cq_start = 3;					//初七開始睡覺的時間（時）
		public const int cq_end = 6;					//初七結束睡覺的時間（時）
		public const int sy_start = 0;					//沈夜
		public const int sy_end = 8;
		public const int tong_start = 2;				//瞳
		public const int tong_end = 10;
		public const int x1_start = 1;					//1.0
		public const int x1_end = 8;
		public const int x2_start = 2;					//2.0
		public const int x2_end = 7;
		public const int ssy_start = 23;				//小沈夜
		public const int ssy_end = 8;
		
	}

	public static class impression{						//好感度
		public const int standard_1 = 100;				//中立或以下
		public const int standard_2 = 300;				//友好或以下
		public const int standard_3 = 600;				//尊敬或以下
		public const int standard_4 = 1000;				//崇敬或以下
		public const int standard_5 = 2000;				//崇拜或以下
	}

	public static class reclaiming{						//開墾
		public const int farm_1 = 30;					//第一塊地所用時間（單位：秒）
		public const int farm_2 = 300;					//第二塊……下面如此類推
		public const int farm_3 = 1800;
		public const int farm_4 = 3600;
		public const int farm_5 = 7200;
		public const int farm_6 = 10800;
		public const int farm_7 = 14400;
		public const int farm_8 = 21600;
	}

	public static class plant{							//農作物

		public const int mushroom1_consume = 2;			//A蘑菇消耗糧食量
		public const int mushroom2_consume = 4;			//B蘑菇
		public const int mushroom3_consume = 15;		//C蘑菇
		public const int mushroom1_gain = 4;			//A蘑菇收穫糧食量
		public const int mushroom2_gain = 8;			//B
		public const int mushroom3_gain = 30;			//C
		public const int mushroom1_time = 900;			//A蘑菇種植時間
		public const int mushroom2_time = 3600;			//B
		public const int mushroom3_time = 21600;		//C

	}

	public static class forest{							//伐木
		public const int gain = 2;						//每次伐木所得木材量
	}

	public static class building{						//建屋

		public static int b1_wood_consume = 50;			//木屋（１級）所需木材
		public static int b2_wood_consume = 100;		//木屋（２級）所需木材
		public static int b3_wood_consume = 100;		//醫務室所需木材
		public static int b4_wood_consume = 100;		//偃術實驗室所需木材

		public static int b1_food_consume = 0;			//木屋（１級）所需食物
		public static int b2_food_consume = 140;
		public static int b3_food_consume = 50;
		public static int b4_food_consume = 70;

		public static int b1_money_consume = 0;			//木屋（１級）所需金錢
		public static int b2_money_consume = 140;
		public static int b3_money_consume = 50;
		public static int b4_money_consume = 70;
		
		public static int b1_stone_consume = 0;			//木屋（１級）所需五色石
		public static int b2_stone_consume = 140;
		public static int b3_stone_consume = 50;
		public static int b4_stone_consume = 70;
		
		public static int b1_maximum_ppl = 1;			//木屋（１級）可容納人數
		public static int b2_maximum_ppl = 2;			//木屋（２級）
		public static int b3_maximum_ppl = 1;			//醫療室
		public static int b4_maximum_ppl = 0;			//偃術實驗室
		public static int b5_maximum_ppl = 2;			//靜水湖別墅
		public static int b6_maximum_ppl = 2;			//紀山
		public static int b7_maximum_ppl = 4;			//大祭司寢殿

	}

	public static class yan{							//偃甲人

		public const int y1_wood_consume = 70;			//偃甲人A所需木材

		public const int y1_food_consume = 50;			//偃甲人A所需食物

		public const int y1_money_consume = 0;			//偃甲人A所需金錢

		public const int y1_stone_consume = 0;			//偃甲人A所需石頭

		public const int y1_time = 360000;				//偃甲人A壽命

		public const int y1_maximum_v0 = 0;				//0%時可擁有數量

		public const int y1_maximum_v1 = 2;				//10%時可擁有數量

		public const int y1_maximum_v2 = 3;				//20%時可擁有數量

		public const int y1_efficiency = 3600;			//偃甲人A工作效率，此處所記載的是時間（單位：S）所需（詳見流月農場數值設計“偃甲人相關”）
	}

	public static class excavation{						//挖寶
		public const float buff_prob = 0.25f;			//獲得BUFF的機率
		public const float wood_prob = 0.15f;			//獲得木材的機率
		public const float food_prob = 0.3f;				//獲得糧食的機率
		public const float money_prob = 0.2f;			//獲得金錢的機率
		public const float stone_prob = 0.1f;			//獲得五色石的機率

		public const float sp_buff = 0.5f;				//獲得BUFF時該BUFF是行動值恢復的BUFF的機率
		public const float task_buff = 0.5f;				//獲得BUFF時該BUFF是任務速度增加的機率

		public const int wood_gain = 6;					//獲得木材的掉落量

		public const int food_gain = 10;				//獲得糧食的掉落量

		public const int money_gain = 100;				//獲得金錢的掉落量

		public const int stone_gain = 1;				//獲得五色石的掉落量

		public const float sp_buff1_prob = 0.7f;			//恢復行動力速度10%的機率
		public const float sp_buff1 = 0.1f;				//恢復行動力速度10%
		public const float sp_buff2_prob = 0.19f;		//恢復行動力速度20%的機率
		public const float sp_buff2 = 0.2f;				//恢復行動力速度20%
		public const float sp_buff3_prob = 0.07f;		//恢復行動力速度30%的機率
		public const float sp_buff3 = 0.3f;				//恢復行動力速度30%
		public const float sp_buff4_prob = 0.03f;		//恢復行動力速度50%的機率
		public const float sp_buff4 = 0.5f;				//恢復行動力速度50%
		public const float sp_buff5_prob = 0.01f;		//恢復行動力速度100%的機率
		public const float sp_buff5 = 1f;				//恢復行動力速度100%

		public const float task_buff1_prob = 0.7f;		//任務速度增加10%的機率
		public const float task_buff1 = 0.1f;			//任務速度增加10%
		public const float task_buff2_prob = 0.2f;		//任務速度增加20%的機率
		public const float task_buff2 = 0.2f;			//任務速度增加20%
		public const float task_buff3_prob = 0.06f;		//任務速度增加30%的機率
		public const float task_buff3 = 0.3f;			//任務速度增加30%
		public const float task_buff4_prob = 0.03f;		//任務速度增加50%的機率
		public const float task_buff4 = 0.5f;			//任務速度增加50%
		public const float task_buff5_prob = 0.01f;		//任務速度增加100%的機率
		public const float task_buff5 = 1f;				//任務速度增加100%
	}

	public static class debuff{							//DEBUFF

		public const float debuff1_50_prob = 0.4f;		//角色度力少於50%時觸發debuff1的機率
		public const float debuff2_50_prob = 0.3f;		//角色度力少於50%時觸發debuff2的機率
		public const float debuff3_50_prob = 0.15f;		//角色度力少於50%時觸發debuff3的機率
		public const float debuff4_50_prob = 0.1f;		//角色度力少於50%時觸發debuff4的機率
		public const float debuff5_50_prob = 0.04f;		//角色度力少於50%時觸發debuff5的機率
		public const float debuff6_50_prob = 0.01f;		//角色度力少於50%時觸發debuff6的機率

		public const float debuff1_20_prob = 0.15f;		//角色度力少於20%時觸發debuff1的機率
		public const float debuff2_20_prob = 0.1f;		//角色度力少於20%時觸發debuff2的機率
		public const float debuff3_20_prob = 0.15f;		//角色度力少於20%時觸發debuff3的機率
		public const float debuff4_20_prob = 0.2f;		//角色度力少於20%時觸發debuff4的機率
		public const float debuff5_20_prob = 0.25f;		//角色度力少於20%時觸發debuff5的機率
		public const float debuff6_20_prob = 0.15f;		//角色度力少於20%時觸發debuff6的機率

		public const float debuff1 = 0f;					//debuff1：體力恢復速度降低0%
		public const float debuff2 = 0.1f;				//debuff2：體力恢復速度降低10%
		public const float debuff3 = 0.2f;				//debuff3：體力恢復速度降低20%
		public const float debuff4 = 0.3f;				//debuff4：體力恢復速度降低30%
		public const float debuff5 = 0.5f;				//debuff5：體力恢復速度降低50%
		public const float debuff6 = 1f;					//debuff6：體力恢復速度降低100%

	}

	public static class achievement{					//成就
		public const int a1 = 6;						//a1(achievement1)：初步開墾	開墾6（即a1）塊田地		
		public const int a2 = 2;						//有一個建築物達到2（即a2）級
		public const int a3 = 100;						//收獲總計100（即a3）個蘑菇
		public const int a4 = 50;						//砍伐50（即a4）棵樹
		public const int a5 = 3;						//建造3（即a5）個低級偃甲人
		public const int a6 = 2;						//將偃術等級提高到中級　中級=>level 2（即a6）？
		public const int a7 = 1000;						//你有1000（即a7）個金幣
		public const int a8 = 2;						//建造2個（即a8）建築物
		public const int a10 = 10;						//完成俠義榜上10個成就
	}

	public static class game_percentage{				//遊戲進度
		public const int p1_criterion1 = 3;				//p1: percentage 10%	開墾3（即p1_criterion1）塊田地
		public const int p1_wood = 500;					//10% 所需木材
		public const int p1_food = 500;					//10% 所需糧食
		public const int p1_money = 1500;				//10% 所需金錢

		public const int p2_criterion1 = 6;				//開墾6（即p2_criterion2）塊田地
		public const int p2_wood = 700;					//20% 所需木材
		public const int p2_food = 700;					//20% 所需糧食
		public const int p2_money = 2000;				//20% 所需金錢

		public const int p3_criterion1 = 3;				//3（即p3_criterion1）個初級偃甲木人
		public const int p3_criterion2 = 8;				//開墾8（即p3_criterion2）塊田地
		public const int p3_wood = 1000;				//30% 所需木材
		public const int p3_food = 1000;				//30% 所需糧食
		public const int p3_money = 3000;				//30% 所需金錢
	}

}
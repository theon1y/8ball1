using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScalesLogic : MonoBehaviour 		//логика работы весов
{
	public Text countText;						//ссылка на текст с количеством взвешиваний
	int weighCount;								//количество взвешиваний, хранимое в объекте
	TriggerScript northTrigger;					//здесь будет ссылка на объект-логику тригерра северной чаши весов
	TriggerScript southTrigger;
	GameObject northScale;						//здесь будет ссылка на игровой объект северной чаши весов
	GameObject southScale;


	void Start () 								//при старте приложения
	{
		ChooseAHeavierBall ();					//выбираем из имеющихся шаров тот, который будет тяжелее
		weighCount = 0;							//сбрасываем счетчик взвешиваний
		SetText ();								//ставим сообщение об этом
		northTrigger = GameObject.FindWithTag ("NorthTrigger").GetComponent<TriggerScript> ();	//присваиваем ссылки
		southTrigger = GameObject.FindWithTag ("SouthTrigger").GetComponent<TriggerScript> ();
		northScale = GameObject.FindWithTag ("NorthScale");
		southScale = GameObject.FindWithTag ("SouthScale");
	}

	void SetText()								//установка текста о кол-ве взвещиваний
	{
		countText.text = "Weighs: " + weighCount.ToString ();
	}

	void ChooseAHeavierBall()													//выбор тяжелого шара
	{
		GameObject[] ballsArray = GameObject.FindGameObjectsWithTag ("Ball");	//находим все шары
		int b = Random.Range (0, 7);											//выбираем случайно число от 0 до 7 включительно
		ballsArray [b].GetComponent<BallLogic> ().SetHavier ();					//говорим какому-то из шаров, что он тяжелее
	}


	public void Weigh()																				//процедура взвешивания
	{
		if (Camera.main.GetComponent<Animator > ().GetCurrentAnimatorStateInfo(0).IsName("Empty")) 	//если никаких анимаций не просходит
		{
			float northBallCount = northTrigger.GetBallCount ();									//спрашиваем триггеры сколько в них шаров
			float southBallCount = southTrigger.GetBallCount ();
			weighCount++;																			//инкрементируем кол-во взвешиваний
			SetText ();																				//меням текст взвешиваний
			Camera.main.GetComponent<Animator> ().SetTrigger ("FlyIn");
			if (northBallCount > southBallCount)
				northScale.GetComponent<Animator> ().SetTrigger ("Weigh");
			if (northBallCount < southBallCount)
				southScale.GetComponent<Animator> ().SetTrigger ("Weigh");							//запускаем анимации в зависимости от результата взвешивания
			/*if (northBallCount == southBallCount) 
			{
				northScale.GetComponent<Animator> ().SetTrigger ("Weigh");
				southScale.GetComponent<Animator> ().SetTrigger ("Weigh");
			}*/
		}
	}

}

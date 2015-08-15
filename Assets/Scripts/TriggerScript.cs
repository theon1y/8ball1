using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour 				//логика триггеров
{
	
	float ballCount;									//количество шаров в триггере


	void Start () 										//в начале игры присваеваем количеству шаров 0
	{
		ballCount = 0;
	}
	
	void OnTriggerEnter(Collider other)					//вызывается каждый раз, когда какой-то объект входит в триггер
	{
		if (other.CompareTag ("Ball")) 
			AddBall (other.gameObject);					//если вошедший объект шар, то увеличиваем количество шаров в триггере
	}

	void OnTriggerExit(Collider other)					//вызывается каждый раз, когда какой-либо объект покидает триггер
	{
		if (other.CompareTag ("Ball")) 
			SubBall (other.gameObject);					//если исключенный объект шар, то уменьшаем количество шаров в триггере
	}

	void AddBall(GameObject ball)						//процедура добавления шаров
	{
		if (ball.GetComponent<BallLogic> ().IsHeavier ())//если добавляемый шар тяжелее
			ballCount += 1.5f;							//то увеличиваем кол-во на полторы единицы
		else
			ballCount += 1.0f;							//если шар обычный, то на одну единицу
	}

	void SubBall(GameObject ball)
	{
		if (ball.GetComponent<BallLogic > ().IsHeavier ())//так же для уменьшения
			ballCount -= 1.5f;
		else
			ballCount -= 1.0f;
	}


	public float GetBallCount()							//функция возвращает количество шаров в триггере
	{
		return ballCount;
	}

		
}

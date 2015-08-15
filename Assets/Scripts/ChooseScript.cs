using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChooseScript : MonoBehaviour 								//логика выбора
{

	public Text gameOverMessage;										//ссылка на сообщение о конце игры
	GameObject[] ballArray;												//здесь будет ссылка на массив шаров
	bool gameEnded;														//состояние конца игры


	void Start () 														//при старте игры
	{
		ballArray = GameObject.FindGameObjectsWithTag("Ball");			//находим все шары
		gameEnded = false;												//говорим, что игра не окончена
	}
	
	void Update () 														//происходит в начале каждого кадра
	{
		if (Input.GetMouseButtonDown(1)) 								//если опустилась ПКМ
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//послать луч из камеры с точки плоскости проецирования, на которую указывает курсор
			RaycastHit hit;												//в направлении вектора проецирования
			if (Physics.Raycast(ray, out hit, 50))						//если луч попадает по какому-то объекту на расстоянии до 50
			{
				if (hit.collider.CompareTag("Ball"))					//и если этот объект шар
				{
					foreach (GameObject ball in ballArray)				//то говорим всем шарам, что они теперь не выбраны
						ball.GetComponent<BallLogic> ().SetChosen(false);
					hit.collider.GetComponent<BallLogic> ().SetChosen(true);//и говорим шару, по которому попали, что он теперь выбтра
				}
			}
		}
	}

	public void MakeAChoise()									//процедура проверки правильности выбора
	{
		if (!gameEnded) 										//если игра не окончена
		{
			bool correct = false;								//создаем локальную переменную для хранения результата проверки со значением ложь
			foreach (GameObject ball in ballArray) 
			{
				if (ball.GetComponent<BallLogic> ().GetChosen () && ball.GetComponent<BallLogic> ().IsHeavier ())//если какой-то из шаров оказался и тяжелее и был выбран
					correct = true;								//переключам переменную на "истина"
			}
			if (correct) 										//если игрок угадал
			{
				gameOverMessage.color = Color.green;			//то меняем текст сообщения конца игры на зеленое "ура"
				gameOverMessage.text = "You guessed right!";
			} else 
			{
				gameOverMessage.color = Color.red;				//если не угадал, то на красное "не ура"
				gameOverMessage.text = "You guessed wrong...";
			}
			gameOverMessage.GetComponent<Animator> ().SetTrigger("GameOver");//выводим сообщение конца игры
			gameEnded = true;									//устанавливаем состояние игры на конец
		}
	}
}

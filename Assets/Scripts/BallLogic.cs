using UnityEngine;
using System.Collections;

public class BallLogic : MonoBehaviour 				//логика шаров
{
	
	public Material shinyMaterial;					//ссылка на материал для подсветки шара
	bool isHeavier;									//здесь будет храниться значение тяжелости
	bool isChosen;									//здесь будет храниться значение выбранности
	Material nativeMaterial;						//здесь будет ссылка на материал родительского шара
	Renderer ballRender;							//здесь будет ссылка на отобразитель шара

	void Start () 									//вызывается при старте игры
	{
		isHeavier = false;							//устанавливаем стандартные значения для свойств шара
		isChosen = false;
		ballRender = GetComponent<Renderer> ();
		nativeMaterial = ballRender.sharedMaterial;
	}

	public void SetHavier()							//через эту процедуру шару будут говорить, что он тяжелее
	{
		isHeavier = true;
	}

	public bool IsHeavier()							//через эту функцию шар будут опрашивать о состоянии его тяжелости
	{
		return isHeavier;
	}

	public bool GetChosen()							//через эту функцию шар будут опрашивать о его выбранности
	{
		return isChosen;
	}

	public void SetChosen(bool toBeChosen)				//через эту функцию можно будет намекнуть шару, что он больше не избран, или оповестить его о избрании
	{
		if (!isChosen && toBeChosen) 					//если шар не выбран и его хотят выбрать, то меняем соответствующее свойсто и материал на светящийся
		{
			isChosen = true;
			ballRender.material = shinyMaterial;
		}
		if (isChosen && !toBeChosen) 					//если шар выбран и его оповещают об его ненужности, то меняем все обратно
		{
			isChosen = false;
			ballRender.material = nativeMaterial;
		}												//в остальных случаях не делаем ничего
	}

}

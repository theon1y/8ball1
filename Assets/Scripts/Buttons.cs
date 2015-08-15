using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buttons : MonoBehaviour 				//фунционал меню
{

	public Text helpText;							//ссылка на текст помощи
	public Image helpBackground;					//ссылка на фон помощи
	bool isEnabled;									//состояние помощника

	void Start ()									//в начале игры говорим, что помошник не активен
	{
		isEnabled = false;
	}

	public void SwitchHelp ()						//процедура переключения помошника
	{
		if (isEnabled) 								//если активен, выключить
		{
			helpText.enabled = false;
			helpBackground.enabled = false;
			isEnabled = false;
		} 
		else 										//в противном случае, включить
		{
			helpText.enabled = true;
			helpBackground.enabled = true;
			isEnabled = true;
		}
	}
	
	public void Restart ()							//процедура, повешенная на кнопку рестарта игры
	{
		Application.LoadLevel (Application.loadedLevel);										
	}

	public void Exit ()								//процедура, привязанная к кнопке выхода
	{
		Application.Quit ();
	}
}

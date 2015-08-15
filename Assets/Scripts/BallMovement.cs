using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour 				//скрипт движения шара
{
	
	public float height;								//высота на которую поднимается шар при перетаскивании
	Rigidbody rb;										//здесь будет ссылка на "жесткое тело" шара, которое отвечает за физическую игровую сущность шара
	Vector3 startPos;									//здесь будет храниться начальная позиция шара
	
	void Start ()										//вызывается при старте игры
	{
		rb = GetComponent<Rigidbody>();					//заполняем нужные параметры
		startPos = rb.position;
	}
	
	void OnMouseDrag () 								//вызывается при попытке перетаскивании именно этого объекта мышью
	{
		Vector3 curPos = rb.position;					//узнаем настоящую позицию шара
		float mouseXDelta = Input.GetAxisRaw("Mouse X");//узнаем насколько изменились координаты мыши за кадр
		float mouseYDelta = Input.GetAxisRaw("Mouse Y");
		Vector3 newPos = new Vector3(curPos.x + mouseXDelta, height, curPos.z + mouseYDelta);	//считаем новую позицию
		rb.velocity = Vector3.zero;						//обнуляем скорость физического игрового тела, чтобы оно по инерции не плыло
		rb.position = newPos;							//меняем позицию тела на нового
	}
	
	void OnTriggerEnter (Collider other)				//вызывается при входе в триггер
	{
		if (other.gameObject.tag.Equals("Teleport")) 	//если мы вошли в телепорт
		{
			rb.position = startPos;						//сбрасываем скорости и меняем позицию на начальную
			rb.velocity = Vector3.zero;
			rb.angularDrag = 0f;
			rb.angularVelocity = Vector3.zero;
		}
	}
	
}

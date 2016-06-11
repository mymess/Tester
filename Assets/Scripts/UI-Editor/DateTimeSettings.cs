using UnityEngine;
using System.Collections;
using System;


[ExecuteInEditMode]
public class DateTimeSettings : MonoBehaviour
{
	private double jd;

	public int year;
	public int month;
	public int day;

	public int hour;
	public int minute;
	public int second;


	public bool gregorianCalendar;
	public bool playMode;


	void Awake(){
		Reset ();
		gregorianCalendar = true;
		playMode = false;
	}


	void Update(){
		if(playMode)
			Reset ();
	}


	public void Reset(){


		DateTime dt = DateTime.UtcNow;
		year = dt.Year;
		month = dt.Month;
		day = dt.Day;
		hour = dt.Hour;
		minute = dt.Minute;
		second = dt.Second;

	}
}
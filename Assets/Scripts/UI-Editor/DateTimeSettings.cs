using UnityEngine;
using System.Collections;
using System;
using AASharp;


[ExecuteInEditMode]
public class DateTimeSettings : MonoBehaviour
{
	private decimal jd;

	private double HOURS_PER_DAY = 24d;
	private double MINUTES_PER_DAY = 1440d;
	private double SECONDS_PER_DAY = 86400d;
	private double MILLISECONDS_PER_DAY = 86400000d;


	public bool gregorianCalendar;
	public bool playMode;
	public int timeScale;



	public DateTime localDatetime;

	void Awake(){
		Reset ();
		gregorianCalendar = true;
		playMode = false;
		timeScale = 1;	
	}		

	public void Play(decimal deltaTime){
		decimal scale = Convert.ToDecimal (timeScale);
		decimal secondsPerDay = 86400m;

		jd =  Decimal.Add(jd, deltaTime * scale / secondsPerDay); 
	}


	public void Reset(){
		DateTime dt   = DateTime.UtcNow;
		localDatetime = DateTime.Now;

		double dayDec = dt.Day + dt.Hour / HOURS_PER_DAY + dt.Minute / MINUTES_PER_DAY +
						dt.Second / SECONDS_PER_DAY + dt.Millisecond / MILLISECONDS_PER_DAY;
		
		jd = Convert.ToDecimal(AASDate.DateToJD (dt.Year, dt.Month, dayDec, gregorianCalendar));			
	}


	public int Year(){		
		return (int)Date().Year;
	}

	public int Month(){		
		return  (int)Date().Month;
	}

	public int Day(){		
		return  (int)Date().Day;
	}

	public int Hour(){		
		return  (int)Date().Hour;
	}

	public int Minute(){		
		return  (int) Date().Minute;
	}

	public float Second(){		
		return (float) Date().Second;
	}


	public AASDate Date (){
		return new AASDate (Convert.ToDouble(jd), gregorianCalendar);
	}

	public void UpdateJd(int year, int month, int day, int hour, int minute, double second){
		double dayDec = day + hour / HOURS_PER_DAY + minute / MINUTES_PER_DAY + second / SECONDS_PER_DAY;
		jd = Convert.ToDecimal( AASDate.DateToJD (year, month, dayDec, gregorianCalendar) );
	}

	public decimal JulianDay(){
		return jd;
	}

}
using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.IO;


[CustomEditor(typeof(DateTimeSettings))]
public class DateTimeEditor : Editor {

	DateTimeSettings dt;

	private int year;
	private int month;
	private int day;

	private int hour;
	private int minute;
	private float second;

	Texture playTex;
	Texture pauseTex;
	Texture playPauseTex;

	double lastUpdate;
	private int timeScaleIndex = 0;

	void OnEnable()
	{
		dt = (DateTimeSettings)target;
		//playTex = LoadPNG("Icons/play-button");
		//pauseTex = LoadPNG ("Icons/pause-button");

		dt.Reset ();
		playTex = Resources.Load ("Textures/play-button") as Texture;
		pauseTex = Resources.Load ("Textures/pause-button") as Texture;
		playPauseTex = playTex;
		lastUpdate = EditorApplication.timeSinceStartup;
	}


	void OnGUI(){
		//playMode = GUILayout.Button (playPause);
	}

	private Texture2D LoadPNG(string filePath) {

		Texture2D tex = null;
		byte[] fileData;

		if (File.Exists(filePath))     {
			fileData = File.ReadAllBytes(filePath);
			tex = new Texture2D(2, 2);
			tex.LoadImage(fileData); 
		}else{
			Debug.Log ("FILE not found-> " + filePath);
		}
		return tex;
	}


	//Refresh is done here
	public override void OnInspectorGUI()
	{
		GUILayout.Label ("Date/Time", EditorStyles.boldLabel);

		DisplayDateSettings ();
		DisplayTimeSettings ();
		//
		if (!dt.playMode){
			dt.UpdateJd (year, month, day, hour, minute, (double)second);
		}
		if (GUILayout.Button ("NOW")) {
			dt.Reset ();
		}
		dt.gregorianCalendar = EditorGUILayout.ToggleLeft ("Use Gregorian calendar", dt.gregorianCalendar, GUILayout.ExpandWidth(true));

		GUILayout.Space (20);

		DisplayPlayMode ();

		GUILayout.Space (20);


	}

	void DisplayPlayMode(){
		GUILayout.Label ("Play mode", EditorStyles.boldLabel);
		GUILayout.BeginHorizontal(GUILayout.MaxWidth(500));


		GUILayoutOption[] options = new GUILayoutOption[]{ GUILayout.Width(90), GUILayout.Height(40) };
		dt.playMode = GUILayout.Toggle (dt.playMode, playPauseTex, "Button", options);

		if (dt.playMode) {						
			playPauseTex = pauseTex;
			decimal deltaTime = Convert.ToDecimal (EditorApplication.timeSinceStartup - lastUpdate);
			dt.Play ( deltaTime );

			Repaint ();
		} else {	
			Repaint ();
			playPauseTex = playTex;
		}

		var textDimensions = GUI.skin.label.CalcSize(new GUIContent("Time scale: "));
		EditorGUIUtility.labelWidth = textDimensions.x;

		options = new GUILayoutOption[]{ GUILayout.Width(140) };
		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		myStyle.alignment = TextAnchor.MiddleRight;

		GUILayout.FlexibleSpace();

		GUILayout.BeginVertical();
		dt.timeScale = EditorGUILayout.IntField ("Time scale: ", dt.timeScale, myStyle, options);


		string[] timeScalesArray = new string[]{ "Natural", "one minute per second", "one hour per second", "one day per second",
			"one month per second", "one year per second"};
		
		GUIStyle style    = new GUIStyle ("Popup");
		style.alignment   = TextAnchor.MiddleRight;
		style.fontStyle = FontStyle.Bold;

		GUILayoutOption[] dropdownOptions = new GUILayoutOption[]{ GUILayout.MaxWidth(140), GUILayout.MinHeight(20) };
		timeScaleIndex = EditorGUILayout.Popup(timeScaleIndex, timeScalesArray, style, dropdownOptions);

		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		lastUpdate = EditorApplication.timeSinceStartup;
	}





	void DisplayTimeSettings(){
		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal(GUILayout.MaxWidth(500));

		string hourLabel = "Hour:";
		string minLabel = "Minute:";
		string secLabel = "Second:";

		GUILayoutOption[] options = new GUILayoutOption[]{ GUILayout.Width(90) };

		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		myStyle.alignment = TextAnchor.MiddleRight;


		var textDimensions = GUI.skin.label.CalcSize(new GUIContent(hourLabel));
		EditorGUIUtility.labelWidth = textDimensions.x;

		options = new GUILayoutOption[]{ GUILayout.Width(60) };
		hour  = EditorGUILayout.IntField ( hourLabel, dt.Hour(), myStyle, options);
		GUILayout.FlexibleSpace();

		textDimensions = GUI.skin.label.CalcSize(new GUIContent(minLabel));
		EditorGUIUtility.labelWidth = textDimensions.x;
		options = new GUILayoutOption[]{ GUILayout.Width(70) };
		minute = EditorGUILayout.IntField ( minLabel, dt.Minute(), myStyle, options);

		GUILayout.FlexibleSpace();

		textDimensions = GUI.skin.label.CalcSize(new GUIContent(secLabel));
		EditorGUIUtility.labelWidth = textDimensions.x;
		options = new GUILayoutOption[]{ GUILayout.Width(100) };

		string secondStr = dt.Second ().ToString ("##.###");
		float.TryParse (secondStr, out second);
		second = EditorGUILayout.FloatField (secLabel, second, myStyle, options);

		EditorGUILayout.EndHorizontal (  );
		GUILayout.EndVertical();

	}


	void DisplayDateSettings(){
		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal(GUILayout.MaxWidth(500));

		string yearLabel  = "Year:";
		string monthLabel = "Month:";
		string dayLabel   = "Day:";

		GUILayoutOption[] options = new GUILayoutOption[]{ GUILayout.Width(80) };

		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		myStyle.alignment = TextAnchor.MiddleRight;


		var textDimensions = GUI.skin.label.CalcSize(new GUIContent(yearLabel));
		EditorGUIUtility.labelWidth = textDimensions.x;

		year  = EditorGUILayout.IntField ( yearLabel, dt.Year(), myStyle, options);
		GUILayout.FlexibleSpace();

		textDimensions = GUI.skin.label.CalcSize(new GUIContent(monthLabel));
		EditorGUIUtility.labelWidth = textDimensions.x;

		month = EditorGUILayout.IntField ( monthLabel, dt.Month(), myStyle,options);

		GUILayout.FlexibleSpace();

		textDimensions = GUI.skin.label.CalcSize(new GUIContent(dayLabel));
		EditorGUIUtility.labelWidth = textDimensions.x;


		day = EditorGUILayout.IntField (dayLabel, dt.Day(), myStyle,options);

		EditorGUILayout.EndHorizontal (  );
		GUILayout.EndVertical();
	}

}

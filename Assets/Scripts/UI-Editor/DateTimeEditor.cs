using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;


[CustomEditor(typeof(DateTimeSettings))]
public class DateTimeEditor : Editor {

	DateTimeSettings dt;

	string playPause;


	Texture playTex;
	Texture pauseTex;
	Texture playPauseTex;


	void OnEnable()
	{
		dt = (DateTimeSettings)target;
		//playTex = LoadPNG("Icons/play-button");
		//pauseTex = LoadPNG ("Icons/pause-button");

		playTex = Resources.Load ("Textures/play-button") as Texture;
		pauseTex = Resources.Load ("Textures/pause-button") as Texture;
		playPauseTex = playTex;
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

	public override void OnInspectorGUI()
	{

		DisplayDateSettings ();
		DisplayTimeSettings ();

		dt.gregorianCalendar = EditorGUILayout.ToggleLeft ("Use Gregorian calendar", dt.gregorianCalendar, GUILayout.ExpandWidth(true));

		dt.playMode = GUILayout.Toggle (dt.playMode, playPauseTex, "Button");

		if (dt.playMode) {			
			playPause = "Pause";
			playPauseTex = pauseTex;
			dt.Reset ();
			Repaint ();

		} else {						
			playPause = "Play";
			playPauseTex = playTex;
		}

	}





	void DisplayLocationSettings(){

		GUILayout.Label ("Location", EditorStyles.boldLabel);

		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal(GUILayout.MaxWidth(500));
		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		myStyle.alignment = TextAnchor.MiddleRight;

		GUILayout.Label ("Longitude");

		GUILayout.EndHorizontal();
		GUILayout.EndVertical();


	}


	void DisplayTimeSettings(){
		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal(GUILayout.MaxWidth(500));


		string hourLabel = "Hour:";
		string minLabel = "Minute:";
		string secLabel = "Second:";



		GUILayoutOption[] options = new GUILayoutOption[]{ GUILayout.Width(80) };

		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		myStyle.alignment = TextAnchor.MiddleRight;


		var textDimensions = GUI.skin.label.CalcSize(new GUIContent(hourLabel));
		EditorGUIUtility.labelWidth = textDimensions.x;

		dt.hour  = EditorGUILayout.IntField ( hourLabel, dt.hour, myStyle, options);
		GUILayout.FlexibleSpace();

		textDimensions = GUI.skin.label.CalcSize(new GUIContent(minLabel));
		EditorGUIUtility.labelWidth = textDimensions.x;

		dt.minute = EditorGUILayout.IntField ( minLabel, dt.minute, myStyle, options);

		GUILayout.FlexibleSpace();

		textDimensions = GUI.skin.label.CalcSize(new GUIContent(secLabel));
		EditorGUIUtility.labelWidth = textDimensions.x;


		dt.second = EditorGUILayout.IntField (secLabel, dt.second, myStyle, options);

		EditorGUILayout.EndHorizontal (  );
		GUILayout.EndVertical();

	}


	void DisplayDateSettings(){
		GUILayout.Label ("Date/Time", EditorStyles.boldLabel);

		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal(GUILayout.MaxWidth(500));


		string yearLabel = "Year:";
		string monthLabel = "Month:";
		string dayLabel = "Day:";



		GUILayoutOption[] options = new GUILayoutOption[]{ GUILayout.Width(80) };

		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		myStyle.alignment = TextAnchor.MiddleRight;


		var textDimensions = GUI.skin.label.CalcSize(new GUIContent(yearLabel));
		EditorGUIUtility.labelWidth = textDimensions.x;

		dt.year  = EditorGUILayout.IntField ( yearLabel, dt.year, myStyle, options);
		GUILayout.FlexibleSpace();

		textDimensions = GUI.skin.label.CalcSize(new GUIContent(monthLabel));
		EditorGUIUtility.labelWidth = textDimensions.x;

		dt.month = EditorGUILayout.IntField ( monthLabel, dt.month, myStyle,options);

		GUILayout.FlexibleSpace();

		textDimensions = GUI.skin.label.CalcSize(new GUIContent(dayLabel));
		EditorGUIUtility.labelWidth = textDimensions.x;


		dt.day   = EditorGUILayout.IntField (dayLabel, dt.day, myStyle,options);

		EditorGUILayout.EndHorizontal (  );
		GUILayout.EndVertical();

		serializedObject.ApplyModifiedProperties();

	}

}

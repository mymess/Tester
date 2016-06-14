using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

[CustomEditor(typeof(LocationSettings))]
public class LocationEditor : Editor {

	LocationSettings locSettings;

	private bool west;
	private bool east;

	private int lonDegrees;
	private int lonMinutes;
	private float lonSeconds;

	private int latDegrees;
	private int latMinutes;
	private float latSeconds;

	void OnEnable()
	{
		locSettings = (LocationSettings) target;
	}

	public override void OnInspectorGUI()
	{
		DisplayLongitudeSettings();

		GUILayout.Space (10);

		DisplayLatitudeSettings ();

		GUILayout.Space (10);

		DisplayAltitudeSettings ();

		GUILayout.Space (10);

		DisplayCitySearch ();

		GUILayout.Space (10);

	}

	void DisplayCitySearch(){
		GUILayout.Label ("City", EditorStyles.boldLabel);
		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		myStyle.alignment = TextAnchor.MiddleRight;

		int textFieldWidth = 30;
		int textFieldHeight = 18;

		GUILayoutOption[] textFieldoptions = new GUILayoutOption[]{ GUILayout.MinWidth(textFieldWidth), GUILayout.MinHeight(textFieldHeight) };
		locSettings.searchInput = EditorGUILayout.TextField ( "", locSettings.searchInput, myStyle, textFieldoptions);



	}


	void DisplayAltitudeSettings(){
		int textFieldWidth = 30;
		int textFieldHeight = 18;

		GUILayout.Label ("Altitude", EditorStyles.boldLabel);
		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal(GUILayout.MinWidth(110));
		GUILayoutOption[] textFieldoptions = new GUILayoutOption[]{ GUILayout.MinWidth(textFieldWidth), GUILayout.MinHeight(textFieldHeight) };

		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		myStyle.alignment = TextAnchor.MiddleRight;

		locSettings.altitude = EditorGUILayout.IntField ( "", locSettings.altitude, myStyle, textFieldoptions);

		GUILayout.Label (" meters", GUI.skin.label);
		EditorGUILayout.EndHorizontal (  );
		GUILayout.EndVertical();
	}

	void DisplayLatitudeSettings (){
		GUILayout.Label ("Latitude", EditorStyles.boldLabel);

		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal(GUILayout.MaxWidth(300));

			GUILayoutOption[] options = new GUILayoutOption[]{ GUILayout.Width(90) };

			GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
			myStyle.alignment = TextAnchor.MiddleRight;

			GUIStyle shiftStyle = new GUIStyle ();
			shiftStyle.alignment = TextAnchor.UpperLeft; 
			shiftStyle.fontStyle = FontStyle.Bold;
			EditorGUIUtility.labelWidth = 0;

			int textFieldWidth = 30;
			int textFieldHeight = 18;
			GUILayoutOption[] textFieldoptions = new GUILayoutOption[]{ GUILayout.MinWidth(textFieldWidth), GUILayout.MinHeight(textFieldHeight) };

			latDegrees = EditorGUILayout.IntField ( "", locSettings.LatitudeDegrees(), myStyle, textFieldoptions);

			GUILayout.Label ("º", shiftStyle);


			//NORTH-SOUTH button
			options = new GUILayoutOption[]{ GUILayout.Width(50), GUILayout.Height(20) };
			bool toggleNorthSouth = GUILayout.Button(locSettings.NorthOrSouth(), options);

			GUILayout.FlexibleSpace();

			EditorGUIUtility.labelWidth = 0;
			options = new GUILayoutOption[]{ GUILayout.Width(textFieldWidth) };

			latMinutes = EditorGUILayout.IntField ("", locSettings.LatitudeMinutes (), myStyle, textFieldoptions);

			GUILayout.Label ("'", shiftStyle);
			GUILayout.FlexibleSpace();

			EditorGUIUtility.labelWidth = 0;
			options = new GUILayoutOption[]{ GUILayout.Width(60) };

			string secondStr = locSettings.LatitudeSeconds ().ToString ("##.##");
			float.TryParse (secondStr, out latSeconds);
			latSeconds = EditorGUILayout.FloatField ("", latSeconds, myStyle, textFieldoptions);

			GUILayout.Label ("\"", shiftStyle);

		EditorGUILayout.EndHorizontal (  );
		GUILayout.EndVertical();

		locSettings.UpdateLatitude (latDegrees, latMinutes, latSeconds, toggleNorthSouth);





	}

	void DisplayLongitudeSettings(){

		GUILayout.Label ("Longitude", EditorStyles.boldLabel);

		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal(GUILayout.MaxWidth(300));

		GUILayoutOption[] options = new GUILayoutOption[]{ GUILayout.Width(90) };

		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		myStyle.alignment = TextAnchor.MiddleRight;

		GUIStyle shiftStyle = new GUIStyle ();
		shiftStyle.alignment = TextAnchor.UpperLeft; 
		shiftStyle.fontStyle = FontStyle.Bold;
		EditorGUIUtility.labelWidth = 0;

		int textFieldWidth = 30;
		int textFieldHeight = 18;
		GUILayoutOption[] textFieldoptions = new GUILayoutOption[]{ GUILayout.MinWidth(textFieldWidth), GUILayout.MinHeight(textFieldHeight) };

		//locSettings.longitude  = EditorGUILayout.IntField ( "", Math.Abs(locSettings.LongitudeDegrees()), myStyle, options);

		lonDegrees = EditorGUILayout.IntField ( "", locSettings.LongitudeDegrees(), myStyle, textFieldoptions);

		GUILayout.Label ("º", shiftStyle);


		//WEST-EAST button
		options = new GUILayoutOption[]{ GUILayout.Width(50), GUILayout.Height(20) };
		bool toggleWestEast = GUILayout.Button(locSettings.WestOrEast(), options);

		GUILayout.FlexibleSpace();

		EditorGUIUtility.labelWidth = 0;
		options = new GUILayoutOption[]{ GUILayout.Width(textFieldWidth) };

		lonMinutes = EditorGUILayout.IntField ("", locSettings.LongitudeMinutes (), myStyle, textFieldoptions);

		GUILayout.Label ("'", shiftStyle);
		GUILayout.FlexibleSpace();

		EditorGUIUtility.labelWidth = 0;
		options = new GUILayoutOption[]{ GUILayout.Width(60) };

		string secondStr = locSettings.LongitudeSeconds ().ToString ("##.##");
		float.TryParse (secondStr, out lonSeconds);
		lonSeconds = EditorGUILayout.FloatField ("", lonSeconds, myStyle, textFieldoptions);

		GUILayout.Label ("\"", shiftStyle);
		EditorGUILayout.EndHorizontal (  );
		GUILayout.EndVertical();

		locSettings.UpdateLongitude (lonDegrees, lonMinutes, lonSeconds, toggleWestEast);

	}


}

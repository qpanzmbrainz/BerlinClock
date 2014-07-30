using UnityEngine;
using System.Collections;

public class UIBerlinClock : MonoBehaviour
{
	private string berlinTime = "Berlin Time";
	private string globalTime = "Global Time";
	private string currentTime = "";
	private BerlinClock berlinClock;
	private BerlinClockConverter berlinClockConverter;

	private void Start ()
	{
		this.berlinClock = new BerlinClock ();
		this.berlinClockConverter = new BerlinClockConverter ();
	}

	private void OnGUI ()
	{
		Rect textFieldSize = new Rect(10,10,400,30);
		berlinTime = GUI.TextField (textFieldSize, berlinTime);
		textFieldSize.y += 35;
		if(GUI.Button(textFieldSize,"Convert to Global Time"))
			currentTime = berlinClockConverter.GetTime(berlinTime);

		textFieldSize.y += 35;
		globalTime = GUI.TextField (textFieldSize, globalTime);
		textFieldSize.y += 35;
		if(GUI.Button(textFieldSize,"Convert to Berlin Time"))
		{
			string berlinTimeOutput = berlinClock.GetTime(globalTime);
			currentTime =  berlinTimeOutput.Replace("-","\n");
		}

		textFieldSize.y += 35;
		textFieldSize.height = 200;
		GUI.TextArea (textFieldSize,currentTime);
		textFieldSize.y += 205;
		textFieldSize.height = 30;

		if(GUI.Button(textFieldSize,"Remove Lines"))
			currentTime = currentTime.Replace("\n","");
	}
}

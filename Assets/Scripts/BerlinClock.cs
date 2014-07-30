using UnityEngine;
using System.Collections;

public class BerlinClock : BerlinClockBase
{
	private const string SEPARATOR = "-";

	public override string GetTime (string time)
	{
		string[] splittedTime = time.Split(':');

		int hours = int.Parse(splittedTime[0]);
		int minutes = int.Parse(splittedTime[1]);
		int seconds = int.Parse(splittedTime[2]);

		return ParseToBerlinTime(hours, minutes, seconds);
	}

	private string ParseToBerlinTime(int hours, int minutes, int seconds)
	{
		return GetSecondsRow(seconds) + SEPARATOR
			+ GetFiveHoursRow(hours) + SEPARATOR
			+ GetSingleHoursRow(hours) + SEPARATOR
			+ GetFiveMinutesRow(minutes) + SEPARATOR
			+ GetSingleMinutesRow(minutes);
	}

	public string GetSecondsRow (int seconds)
	{
		return seconds % 2 == 0 ? YELLOW : ORANGE;
	}

	public string GetSingleMinutesRow (int minutes)
	{
		return GetSingleUnit (minutes,YELLOW);
	}

	public string GetSingleHoursRow (int hours)
	{
		return GetSingleUnit (hours,RED);
	}

	public string GetFiveHoursRow (int hours)
	{
		return GetSingleUnit ( hours / 5 , RED);
	}

	public string GetFiveMinutesRow (int minutes)
	{
		string row = "";
		for(int i = 1; i <= 11; i++)
		{
			if(i <= minutes / 5)
				row += i % 3 == 0 ? RED : YELLOW;
			else
				row += ORANGE;
		}
		
		return row;
	}
	
	private string GetSingleUnit (int value,string valueOn)
	{
		string row = "";
		value %= 5;
		for(int i = 1; i <= 4; i++)
			row += i <= value? valueOn : ORANGE;
		
		return row;
	}
}
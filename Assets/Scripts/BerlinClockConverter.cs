using UnityEngine;
using System.Collections;
using System;

public class BerlinClockConverter : BerlinClockBase
{
	private int unitRowLeght = 4;
	private int fiveMinutesRowLeght = 11;

	public override string GetTime (string berlinTime)
	{
		berlinTime = RemoveSecondsChar (berlinTime);
		return  GetHoursFromBerlinTime (berlinTime) + ":" + GetMinutesFromBerlinTime (berlinTime);
	}

	private string RemoveSecondsChar (string berlinTime)
	{
		if (berlinTime.Length == 24)
			return berlinTime.Substring(1);
		else
			return berlinTime;
	}

	private string GetHoursFromBerlinTime (string currentTime)
	{
		string hours = currentTime.Substring (0, unitRowLeght * 2);
		return ConvertClockUnit (hours, GetHours);
	}

	private string GetMinutesFromBerlinTime (string currentTime)
	{
		string minutes = currentTime.Substring (unitRowLeght * 2, unitRowLeght + fiveMinutesRowLeght);
		return ConvertClockUnit (minutes, GetMinutes);
	}

	private string ConvertClockUnit (string time, Func<string, int> convert)
	{
		time = convert (time).ToString ();
		return time.Length == 1 ? "0" + time : time;
	}

	public int GetSingleMinutesRow (string minutes)
	{
		return GetSingleUnit (minutes , YELLOW);
	}
	
	public int GetSingleHourRow (string hours)
	{
		return GetSingleUnit (hours , RED);
	}
	
	public int GetFiveHourRow (string hours)
	{
		return GetSingleUnit (hours , RED) * 5;
	}

	public int GetFiveMinutesRow (string minutes)
	{
		int quantity = 0;
		for(int i = 0; i < minutes.Length; i++)
		{
			string currentChar = minutes[i].ToString ();
			if (currentChar == YELLOW || currentChar == RED)
				quantity++;
		}
		
		return quantity * 5;
	}

	public int GetMinutes (string minutes)
	{
		string fiveMinutes = minutes.Substring (0,fiveMinutesRowLeght);
		string singleMinutes = minutes.Substring (fiveMinutesRowLeght, unitRowLeght);
		return GetFiveMinutesRow(fiveMinutes) + GetSingleMinutesRow(singleMinutes);
	}

	public int GetHours (string hours)
	{
		string fiveHours = hours.Substring (0, unitRowLeght);
		string singleHours = hours.Substring (unitRowLeght, unitRowLeght);
		return GetFiveHourRow (fiveHours) + GetSingleHourRow (singleHours);
	}

	private int GetSingleUnit (string number , string letterForOn)
	{
		int quantity = 0;
		for(int i = 0; i < number.Length; i++)
		{
			if(number[i].ToString () == letterForOn)
				quantity++;
		}
		return quantity;
	}
}
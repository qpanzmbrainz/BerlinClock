using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class BerlinClockTest
{
	private BerlinClock clock;

	[SetUp]
	public void SetUp ()
	{
		clock = new BerlinClock();
	}

	[Test]
	public void SecondsRowReturnsYIn0()
	{
		string secondsRow = clock.GetSecondsRow(0);
		Assert.AreEqual("Y", secondsRow);
	}

	[Test]
	public void SecondsRowReturnsOIn1()
	{
		string secondsRow = clock.GetSecondsRow(1);
		Assert.AreEqual("O", secondsRow);
	}

	[Test]
	public void SecondsRowReturnsYIn4()
	{
		string secondsRow = clock.GetSecondsRow(4);
		Assert.AreEqual("Y", secondsRow);
	}

	[Test]
	public void SecondsRowReturnsYInEven()
	{
		for(int i = 0; i < 60; i += 2)
		{
			string secondsRow = clock.GetSecondsRow(i);
			Assert.AreEqual("Y", secondsRow);
		}
	}

	[Test]
	public void SingleMinutesRowReturnsYOOOIn1()
	{
		string singleMinutesRow = clock.GetSingleMinutesRow(1);
		Assert.AreEqual("YOOO", singleMinutesRow);
	}

	[Test]
	public void SingleMinutesRowReturnsYYOOIn2()
	{
		string singleMinutesRow = clock.GetSingleMinutesRow(2);
		Assert.AreEqual("YYOO", singleMinutesRow);
	}

	[Test]
	public void SingleMinutesRowReturnsYYYOIn3()
	{
		string singleMinutesRow = clock.GetSingleMinutesRow(3);
		Assert.AreEqual("YYYO", singleMinutesRow);
	}

	[Test]
	public void SingleMinutesRowReturnsYYYYIn4()
	{
		string singleMinutesRow = clock.GetSingleMinutesRow(4);
		Assert.AreEqual("YYYY", singleMinutesRow);
	}

	[Test]
	public void SingleMinutesRowReturnsOOOOIn5()
	{
		string singleMinutesRow = clock.GetSingleMinutesRow(5);
		Assert.AreEqual("OOOO", singleMinutesRow);
	}

	[Test]
	public void SingleMinutesRowReturnsOOOOIn35()
	{
		string singleMinutesRow = clock.GetSingleMinutesRow(35);
		Assert.AreEqual("OOOO", singleMinutesRow);
	}

	[Test]
	public void SingleMinutesRowReturnsYOOOIn6()
	{
		string singleMinutesRow = clock.GetSingleMinutesRow(6);
		Assert.AreEqual("YOOO", singleMinutesRow);
	}

	[Test]
	public void SingleMinutesRowReturnsYYOOIn17()
	{
		string singleMinutesRow = clock.GetSingleMinutesRow(17);
		Assert.AreEqual("YYOO", singleMinutesRow);
	}

	[Test]
	public void SingleMinutesRowReturnsYYYOIn38()
	{
		string singleMinutesRow = clock.GetSingleMinutesRow(38);
		Assert.AreEqual("YYYO", singleMinutesRow);
	}

	[Test]
	public void FiveMinutesRowReturnsYOOOOOOOOOOIn5()
	{
		string fiveMinutesRow = clock.GetFiveMinutesRow(5);
		Assert.AreEqual("YOOOOOOOOOO", fiveMinutesRow);
	}

	[Test]
	public void FiveMinutesRowReturnsYYOOOOOOOOOIn10()
	{
		string fiveMinutesRow = clock.GetFiveMinutesRow(10);
		Assert.AreEqual("YYOOOOOOOOO", fiveMinutesRow);
	}

	[Test]
	public void FiveMinutesRowReturnsYYROOOOOOOOIn15()
	{
		string fiveMinutesRow = clock.GetFiveMinutesRow(15);
		Assert.AreEqual("YYROOOOOOOO", fiveMinutesRow);
	}

	[Test]
	public void FiveMinutesRowReturnsYYRYYRYYRYYIn55()
	{
		string fiveMinutesRow = clock.GetFiveMinutesRow(55);
		Assert.AreEqual("YYRYYRYYRYY", fiveMinutesRow);
	}

	[Test]
	public void FiveMinutesRowReturnsYYRYYRYOOOOIn38()
	{
		string fiveMinutesRow = clock.GetFiveMinutesRow(38);
		Assert.AreEqual("YYRYYRYOOOO", fiveMinutesRow);
	}

	[Test]
	public void SingleHoursRowReturnsROOOIn1()
	{
		string singleHoursRow = clock.GetSingleHoursRow(1);
		Assert.AreEqual("ROOO", singleHoursRow);
	}

	[Test]
	public void FiveHoursRowReturnsROOOIn5()
	{
		string fiveHoursRow = clock.GetFiveHoursRow(5);
		Assert.AreEqual("ROOO", fiveHoursRow);
	}

	[Test]
	public void FiveHoursRowReturnsRRROIn15()
	{
		string fiveHoursRow = clock.GetFiveHoursRow(15);
		Assert.AreEqual("RRRO", fiveHoursRow);
	}

	[Test]
	public void FiveHoursRowReturnsRRRRIn23()
	{
		string fiveHoursRow = clock.GetFiveHoursRow(23);
		Assert.AreEqual("RRRR", fiveHoursRow);
	}

	[Test]
	public void FiveHoursRowReturnsOOOOIn3()
	{
		string fiveHoursRow = clock.GetFiveHoursRow(3);
		Assert.AreEqual("OOOO", fiveHoursRow);
	}

	[Test]
	public void FiveHoursRowReturnsRRROIn17()
	{
		string fiveHoursRow = clock.GetFiveHoursRow(17);
		Assert.AreEqual("RRRO", fiveHoursRow);
	}

	[Test]
	public void ParseTimeReturnsYOOOOOOOOOOOOOOOOOOOOOOOIn000000()
	{
		string time = clock.GetTime("00:00:00");
		Assert.AreEqual("Y-OOOO-OOOO-OOOOOOOOOOO-OOOO", time);
	}

	[Test]
	public void ParseTimeReturnsYRRROROOOYYRYYRYYRYOOOOOIn165006()
	{
		string time = clock.GetTime("16:50:06");
		Assert.AreEqual("Y-RRRO-ROOO-YYRYYRYYRYO-OOOO", time);
	}

	[Test]
	public void ParseTimeReturnsORRRRRRROYYRYYRYYRYYYYYYIn235959()
	{
		string time = clock.GetTime("23:59:59");
		Assert.AreEqual("O-RRRR-RRRO-YYRYYRYYRYY-YYYY", time);
	}

	[Test]
	public void ParseTimeReturnsORROOROOOYYRYYRYOOOOYYOOIn113701()
	{
		string time = clock.GetTime("11:37:01");
		Assert.AreEqual("O-RROO-ROOO-YYRYYRYOOOO-YYOO", time);
	}
}
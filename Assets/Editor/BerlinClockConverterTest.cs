using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class BerlinClockConverterTest
{
	private BerlinClockConverter converter;
	
	[SetUp]
	public void SetUp ()
	{
		converter = new BerlinClockConverter();
	}

	[Test]
	public void SingleMinutesRowReturns1InYOOO()
	{
		int singleMinutesRow = converter.GetSingleMinutesRow("YOOO");
		Assert.AreEqual(1, singleMinutesRow);
	}

	[Test]
	public void SingleMinutesRowReturns2InYYOO()
	{
		int singleMinutesRow = converter.GetSingleMinutesRow("YYOO");
		Assert.AreEqual(2, singleMinutesRow);
	}

	[Test]
	public void SingleMinutesRowReturns3InYYYO()
	{
		int singleMinutesRow = converter.GetSingleMinutesRow("YYYO");
		Assert.AreEqual(3, singleMinutesRow);
	}

	[Test]
	public void SingleMinutesRowReturns4InYYYY()
	{
		int singleMinutesRow = converter.GetSingleMinutesRow("YYYY");
		Assert.AreEqual(4, singleMinutesRow);
	}

	[Test]
	public void SingleMinutesRowReturns0InOOOO()
	{
		int singleMinutesRow = converter.GetSingleMinutesRow("OOOO");
		Assert.AreEqual(0, singleMinutesRow);
	}

	[Test]
	public void FiveMinutesRowReturns5InYOOOOOOOOOO()
	{
		int fiveMinutesRow = converter.GetFiveMinutesRow("YOOOOOOOOOO");
		Assert.AreEqual(5, fiveMinutesRow);
	}

	[Test]
	public void FiveMinutesRowReturns10InYYOOOOOOOOO()
	{
		int fiveMinutesRow = converter.GetFiveMinutesRow("YYOOOOOOOOO");
		Assert.AreEqual(10, fiveMinutesRow);
	}

	[Test]
	public void FiveMinutesRowReturns15InYYROOOOOOOO()
	{
		int fiveMinutesRow = converter.GetFiveMinutesRow("YYROOOOOOOO");
		Assert.AreEqual(15, fiveMinutesRow);
	}

	[Test]
	public void FiveMinutesRowReturns55InYYRYYRYYRYY()
	{
		int fiveMinutesRow = converter.GetFiveMinutesRow("YYRYYRYYRYY");
		Assert.AreEqual(55, fiveMinutesRow);
	}

	[Test]
	public void FiveMinutesRowReturns6InYOOOOOOOOOOYOOO()
	{
		int minutes = converter.GetMinutes("YOOOOOOOOOOYOOO");
		Assert.AreEqual(6, minutes);
	}

	[Test]
	public void FiveMinutesRowReturns7InYOOOOOOOOOOYYOO()
	{
		int minutes = converter.GetMinutes("YOOOOOOOOOOYYOO");
		Assert.AreEqual(7, minutes);
	}

	[Test]
	public void FiveMinutesRowReturns16InYYROOOOOOOOYOOO()
	{
		int minutes = converter.GetMinutes("YYROOOOOOOOYOOO");
		Assert.AreEqual(16, minutes);
	}

	[Test]
	public void FiveMinutesRowReturns59InYYRYYRYYRYYYYYY()
	{
		int minutes = converter.GetMinutes("YYRYYRYYRYYYYYY");
		Assert.AreEqual(59, minutes);
	}

	[Test]
	public void SingleHourRowReturns1InROOO()
	{
		int hours = converter.GetSingleHourRow("ROOO");
		Assert.AreEqual(1, hours);
	}

	[Test]
	public void SingleHourRowReturns2InRROO()
	{
		int hours = converter.GetSingleHourRow("RROO");
		Assert.AreEqual(2, hours);
	}

	[Test]
	public void SingleHourRowReturns3InRRRO()
	{
		int hours = converter.GetSingleHourRow("RRRO");
		Assert.AreEqual(3, hours);
	}

	[Test]
	public void SingleHourRowReturns4InRRRR()
	{
		int hours = converter.GetSingleHourRow("RRRR");
		Assert.AreEqual(4, hours);
	}

	[Test]
	public void FiveHourRowReturns5InROOO()
	{
		int hours = converter.GetFiveHourRow("ROOO");
		Assert.AreEqual(5, hours);
	}

	[Test]
	public void FiveHourRowReturns10InRROO()
	{
		int hours = converter.GetFiveHourRow("RROO");
		Assert.AreEqual(10, hours);
	}

	[Test]
	public void FiveHourRowReturns15InRRRO()
	{
		int hours = converter.GetFiveHourRow("RRRO");
		Assert.AreEqual(15, hours);
	}

	[Test]
	public void FiveHourRowReturns20InRRRR()
	{
		int hours = converter.GetFiveHourRow("RRRR");
		Assert.AreEqual(20, hours);
	}

	[Test]
	public void GetHoursReturns22InRRRRRROO()
	{
		int hours = converter.GetHours("RRRRRROO");
		Assert.AreEqual(22, hours);
	}

	[Test]
	public void GetHoursReturns18InRRRORRRO()
	{
		int hours = converter.GetHours("RRRORRRO");
		Assert.AreEqual(18, hours);
	}

	[Test]
	public void GetHoursReturns2InOOOORROO()
	{
		int hours = converter.GetHours("OOOORROO");
		Assert.AreEqual(2, hours);
	}

	[Test]
	public void GetHoursReturns18_32nYRRRORRROYYRYYROOOOOYYOO ()
	{
		string time = converter.GetTime("YRRRORRROYYRYYROOOOOYYOO");
		Assert.AreEqual("18:32", time);
	}

	[Test]
	public void GetHoursReturns18_32nRRRORRROYYRYYROOOOOYYOO ()
	{
		string time = converter.GetTime("RRRORRROYYRYYROOOOOYYOO");
		Assert.AreEqual("18:32", time);
	}

	[Test]
	public void GetHoursReturns00_00nOOOOOOOOOOOOOOOOOOOOOOOO ()
	{
		string time = converter.GetTime("OOOOOOOOOOOOOOOOOOOOOOOO");
		Assert.AreEqual("00:00", time);
	}

	[Test]
	public void GetHoursReturns23_59nRRRRRRROYYRYYRYYRYYYYYY ()
	{
		string time = converter.GetTime("RRRRRRROYYRYYRYYRYYYYYY");
		Assert.AreEqual("23:59", time);
	}
}

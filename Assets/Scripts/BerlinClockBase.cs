using UnityEngine;
using System.Collections;

public abstract class BerlinClockBase
{
	protected const string YELLOW = "Y";
	protected const string ORANGE = "O";
	protected const string RED = "R";

	public abstract string GetTime (string time);
}
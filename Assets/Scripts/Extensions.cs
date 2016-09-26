using System;
using UnityEngine;
using System.Collections;

public static class Extensions {

	public static IEnumerator DelayMethod(this MonoBehaviour self, float waitTime, Action action)
	{
		yield return new WaitForSeconds(waitTime);
		action();
	}

	public static IEnumerator TimerMethod(this MonoBehaviour self, 
		float waitTime, Action startAction, Action repetitionAction, Func<bool> exitConditionalFunc, Action exitAction)
	{
		startAction ();
		while(true){
			yield return new WaitForSeconds(waitTime);
			repetitionAction ();
			if (exitConditionalFunc () == true)
				break;
		}
		exitAction ();
	}
}

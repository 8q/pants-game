using UnityEngine;
using System.Collections;

public class ConstantValues  {
	public static RouteName ROUTE = RouteName.Mion;

	public static ProgressState PROGRESS = ProgressState.Opening;

	public enum RouteName {
		Airi,
		Mion,
		Umino,
	}

	public enum ProgressState {
		Opening,
		Stage1,
		Stage2,
		Stage3,
		Stage4,
	}
}

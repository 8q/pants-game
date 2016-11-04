using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Novel{
	
	public class RouteselectComponent : AbstractComponent {

		public RouteselectComponent(){
			//必須項目
			this.arrayVitalParam = new List<string> {
				"routename"
			};

			this.originalParam = new Dictionary<string,string> () {
				{ "routename","mion" },
			};
		}

		public override void start ()
		{
			string routeName = this.param ["routename"];

			if ("airi".Equals (routeName)) {
				Debug.Log("ConstantValues.ROUTE = ConstantValues.RouteName.Airi");
				ConstantValues.ROUTE = ConstantValues.RouteName.Airi;
			} else if ("mion".Equals (routeName)) {
				Debug.Log("ConstantValues.ROUTE = ConstantValues.RouteName.Mion");
				ConstantValues.ROUTE = ConstantValues.RouteName.Mion;
			} else if ("umino".Equals (routeName)) {
				Debug.Log("ConstantValues.ROUTE = ConstantValues.RouteName.Umino");
				ConstantValues.ROUTE = ConstantValues.RouteName.Umino;
			} else {
				Debug.Log("routename invalid value");
			}
			//次のシナリオに進む処理
			this.gameManager.nextOrder ();
		}
	}
}

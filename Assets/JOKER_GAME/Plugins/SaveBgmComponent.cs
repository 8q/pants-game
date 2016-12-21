using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Novel
{

    public class SavebgmComponent : AbstractComponent
    {

        public SavebgmComponent()
        {
            //必須項目
            this.arrayVitalParam = new List<string> {
                "sound"
            };

            this.originalParam = new Dictionary<string, string>() {
                { "sound","" },
            };
        }

        public override void start()
        {
            var bgmName = this.param["sound"];
            var soundTrack = (SoundTrack)System.Enum.Parse(typeof(SoundTrack),bgmName);
            

            AllPlayerPrefs.SaveSoundTrack(soundTrack);

            //次のシナリオに進む処理
            this.gameManager.nextOrder();
        }
    }
}

using UnityEngine;
using System.Collections;

public enum SoundTrack : int
{
    None = 0,

    /// <summary>
    /// 4nzu
    /// </summary>
    Opening = 1 << 0,

    /// <summary>
    /// 4nzu
    /// </summary>
    Stage1 = 1 << 1,

    /// <summary>
    /// D
    /// </summary>
    Stage2 = 1 << 2,

    /// <summary>
    /// nezumi
    /// </summary>
    Stage3 = 1 << 3,

    /// <summary>
    /// 4nzu
    /// </summary>
    ThemeMion = 1 << 4,

    /// <summary>
    /// 4nzu
    /// </summary>
    Stage4 = ThemeUmino,

    /// <summary>
    /// D
    /// </summary>
    ThemeAiri = 1 << 5,


    /// <summary>
    /// umino
    /// </summary>
    ThemeUmino = 1 << 6,
}



public static class AllPlayerPrefsExtentions{
    public static bool HasTrackFlag(this SoundTrack soundTrack, SoundTrack content)
    {
        return (soundTrack & content) == content;
    }
}


public class AllPlayerPrefs : MonoBehaviour
{

    const string SoundTrackKey = "SoundTrack";
    
    public static void SaveSoundTrack(SoundTrack soundTrack)
    {
        int flags = (int)(soundTrack | LoadSoundTrack());
        PlayerPrefs.SetInt(SoundTrackKey, flags);
        PlayerPrefs.Save();
    }

    public static SoundTrack LoadSoundTrack()
    {
        return (SoundTrack)PlayerPrefs.GetInt(SoundTrackKey, 0);
    }

    /*
    /// <summary>
    /// サウンドトラックが利用可能かを調べるためのユーティリティメソッド
    /// </summary>
    /// <param name="check">調査対象</param>
    /// <param name="content">これが含まれているかをチェック</param>
    /// <returns></returns>
    public static bool IsSoundTrackAvailable(SoundTrack check,SoundTrack content)
    {
        return (check & content) == content;
    }*/

    /// <summary>
    /// for Test
    /// </summary>
    public static void DeleteSoundTrack()
    {
        PlayerPrefs.DeleteKey(SoundTrackKey);
    }
}

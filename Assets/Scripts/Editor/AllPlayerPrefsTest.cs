using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;

public class AllPlayerPrefsTest {


    [Test]
	public void EditorTest()
	{
        var s1 = SoundTrack.None; 

        var s2 = AllPlayerPrefs.LoadSoundTrack();

        // テスト用の後始末（データ削除）
        AllPlayerPrefs.DeleteSoundTrack();

        //Assert
        Assert.AreEqual(s1,s2);
    }

    [Test]
    public void EditorTest2()
    {
        var s1 = SoundTrack.Opening;
        
        AllPlayerPrefs.SaveSoundTrack(s1);

        var s2 = AllPlayerPrefs.LoadSoundTrack();

        
        // テスト用の後始末（データ削除）
        AllPlayerPrefs.DeleteSoundTrack();

        //Assert
        Assert.AreEqual(s1, s2);
    }


    [Test]
    public void EditorTest3()
    {
        var s1 = SoundTrack.Stage4;
        
        AllPlayerPrefs.SaveSoundTrack(SoundTrack.ThemeMion);

        var s2 = AllPlayerPrefs.LoadSoundTrack();

        // テスト用の後始末（データ削除）
        AllPlayerPrefs.DeleteSoundTrack();

        //Assert
        Assert.AreEqual(s1, s2);
    }



    [Test]
    public void EditorTest4()
    {
        var s1 = SoundTrack.ThemeAiri;

        AllPlayerPrefs.SaveSoundTrack(SoundTrack.Opening | SoundTrack.ThemeAiri);

        var s2 = AllPlayerPrefs.LoadSoundTrack();

        // テスト用の後始末（データ削除）
        AllPlayerPrefs.DeleteSoundTrack();


        // ロードした s2 に s1(ThemeAiri)が含まれているか。
        // つまり 
        // var result = (s2 & SoundTrack.ThemeAiri) == (SoundTrack.ThemeAiri);
        // var result = (s2 & s1) == s1;
        var result = s2.HasTrackFlag(s1);

        //Assert
        // わかりやすいように IsTrue に変更
        // Assert.AreEqual(s1, s2 & s1);
        Assert.IsTrue(result);
    }


    [Test]
    public void EditorTest5()
    {
        var s1 = SoundTrack.ThemeUmino;

        AllPlayerPrefs.SaveSoundTrack(SoundTrack.Opening | SoundTrack.ThemeAiri);

        var s2 = AllPlayerPrefs.LoadSoundTrack();

        // テスト用の後始末（データ削除）
        AllPlayerPrefs.DeleteSoundTrack();


        // ロードした s2 に s1(ThemeAiri)が含まれているか。
        // つまり 
        // var result = (s2 & SoundTrack.ThemeAiri) == (SoundTrack.ThemeAiri);
        // var result = (s2 & s1) == s1;
        var result = s2.HasTrackFlag(s1);

        //Assert
        // わかりやすいように IsTrue に変更
        // Assert.AreEqual(s1, s2 & s1);
        Assert.IsFalse(result);
    }



    [Test]
    public void EditorDebugTest1()
    {
        var s1 = SoundTrack.Opening;
        
        var s2 = AllPlayerPrefs.LoadSoundTrack();

        // テスト用の後始末（データ削除）
     //   AllPlayerPrefs.DeleteSoundTrack();


        // ロードした s2 に s1(ThemeAiri)が含まれているか。
        // つまり 
        // var result = (s2 & SoundTrack.ThemeAiri) == (SoundTrack.ThemeAiri);
        // var result = (s2 & s1) == s1;
        var result = s2.HasTrackFlag(s1);

        Debug.Log(s2);

        //Assert
        // わかりやすいように IsTrue に変更
        // Assert.AreEqual(s1, s2 & s1);
        Assert.IsTrue(result);
    }

}

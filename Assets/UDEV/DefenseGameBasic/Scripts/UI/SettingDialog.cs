using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UDEV.DefenseBasic
{
    public class SettingDialog : Dialog, IComponentChecking
    {
        public Slider musicSlider;
        public Slider soundSlider;

        public bool IsComponentsNull()
        {
            return AudioController.Ins == null || musicSlider == null || soundSlider == null;
        }

        public override void Show(bool isShow)
        {
            base.Show(isShow);

            if (IsComponentsNull()) return;

            musicSlider.value = Pref.musicVol;
            soundSlider.value = Pref.soundVol;
        }

        public void OnMusicChange(float value)
        {
            if(IsComponentsNull()) return;

            AudioController.Ins.musicVol = value;
            AudioController.Ins.musicAus.volume = value;
            Pref.musicVol = value;
        }

        public void OnSoundChange(float value) 
        {
            if (IsComponentsNull()) return;

            AudioController.Ins.soundVol = value;
            AudioController.Ins.soundAus.volume = value;
            Pref.soundVol = value;
        }
        
    }
}


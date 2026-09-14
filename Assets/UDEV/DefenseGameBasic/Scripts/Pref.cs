using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDEV.DefenseBasic
{
    // Quản lý dữ liệu lưu bằng PlayerPrefs
    public static class Pref
    {
        // Điểm cao nhất
        public static int bestScore
        {
            set
            {
                // Lấy điểm cao nhất hiện tại
                int oldBestScore = PlayerPrefs.GetInt(Const.BEST_SCORE_PREF, 0);

                // Chỉ lưu nếu điểm mới cao hơn
                if (oldBestScore < value)
                    PlayerPrefs.SetInt(Const.BEST_SCORE_PREF, value);
            }

            // Lấy điểm cao nhất
            get => PlayerPrefs.GetInt(Const.BEST_SCORE_PREF, 0);
        }

        // ID nhân vật hiện tại
        public static int curPlayerId
        {
            set => PlayerPrefs.SetInt(Const.CUR_PLAYER_ID_PREF, value);
            get => PlayerPrefs.GetInt(Const.CUR_PLAYER_ID_PREF, 0);
        }

        // Số coin
        public static int coins
        {
            set => PlayerPrefs.SetInt(Const.COIN_PREF, value);
            get => PlayerPrefs.GetInt(Const.COIN_PREF, 0);
        }

        // Âm lượng nhạc
        public static float musicVol
        {
            set => PlayerPrefs.SetFloat(Const.MUSIC_VOL_PREF, value);
            get => PlayerPrefs.GetFloat(Const.MUSIC_VOL_PREF, 0.3f);
        }

        // Âm lượng hiệu ứng
        public static float soundVol
        {
            set => PlayerPrefs.SetFloat(Const.SOUND_VOL__PREF, value);
            get => PlayerPrefs.GetFloat(Const.SOUND_VOL__PREF, 1f);
        }

        // Lưu bool: true = 1, false = 0, lưu trạng thái
        public static void SetBool(string key, bool value)
        {
            if (value)
                PlayerPrefs.SetInt(key, 1);
            else
                PlayerPrefs.SetInt(key, 0);
        }

        // Đọc bool từ PlayerPrefs, đọc trạng thái
        public static bool GetBool(string key)
        {
            int check = PlayerPrefs.GetInt(key);

            if (check == 0)
                return false;
            else if (check == 1)
                return true;
            else
                return false;
        }
    }
}
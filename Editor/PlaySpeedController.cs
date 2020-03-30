using UnityEngine;
using UnityEditor;

namespace BrightLib.PlaySpeedTool
{
    public class PlaySpeedController
    {
        private const string WINDOW_TITLE = "Play Speed";
        private const bool WINDOW_UTILITY = false;

        [MenuItem("Tools/" + WINDOW_TITLE)]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<PlaySpeedWindow>(WINDOW_UTILITY, WINDOW_TITLE);
        }

        public  void ChangeTimeScale(float timeScaleDiff)
        {
            var timeScale = Time.timeScale;
            timeScale += timeScaleDiff;
            timeScale = Mathf.Max(0f, timeScale);
            Time.timeScale = timeScale;
        }

        public void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }
    }
}


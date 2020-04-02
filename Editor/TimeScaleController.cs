using UnityEngine;
using UnityEditor;

namespace BrightLib.TimeScale
{
    public class TimeScaleController
    {
        private const string _kWindowTitle = "Time Scale";
        private const bool _kIsUtilityWindow = false;

        [MenuItem("Tools/" + _kWindowTitle)]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<TimeScaleWindow>(_kIsUtilityWindow, _kWindowTitle);
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


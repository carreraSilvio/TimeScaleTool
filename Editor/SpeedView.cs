using UnityEngine;
using UnityEditor;

namespace BrightLib.PlaySpeedTool
{
    public class PlaySpeedWindow : EditorWindow
    {
        #region MenuItem

        private const string WINDOW_TITLE = "Play Speed";
        private const bool WINDOW_UTILITY = false;

        [MenuItem("Tools/" + WINDOW_TITLE)]
        public static void ShowWindow()
        {
            GetWindow<PlaySpeedWindow>(WINDOW_UTILITY, WINDOW_TITLE);
        }

        #endregion

        private void OnGUI()
        {
            StartGreyedOutArea(Application.isPlaying);

            EditorGUILayout.BeginVertical();
            {
                DrawLabelBold($"Time Scale is : {Time.timeScale.ToString("0.00")}");
                EditorGUILayout.BeginHorizontal();
                {
                    if (DrawButton("<<", width: 25f)) ChangeTimeScale(-0.25f);
                    if (DrawButton("<", width: 25f)) ChangeTimeScale(-0.1f);
                    if (DrawButton('\u25B6'.ToString(), width: 40f)) SetTimeScale(1f);
                    if (DrawButton(">", width: 25f)) ChangeTimeScale(0.1f);
                    if (DrawButton(">>", width: 25f)) ChangeTimeScale(0.25f);
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();

            EndGreyedOutArea();
        }

        private void ChangeTimeScale(float timeScaleDiff)
        {
            var timeScale = Time.timeScale;
            timeScale += timeScaleDiff;
            timeScale = Mathf.Max(0f, timeScale);
            Time.timeScale = timeScale;
        }

        private void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }

        public void DrawLabelBold(string text)
        {
            GUILayout.Label(text, EditorStyles.boldLabel);
        }

        public bool DrawButton(string text, float width = 60, float height = 20)
        {
            return GUILayout.Button(text, GUILayout.Width(width), GUILayout.Height(height));
        }

        public bool DrawButton(string text, params GUILayoutOption[] options)
        {
            return GUILayout.Button(text, options);
        }

        public bool DrawToggle(bool boolean, string text, float width = 60, float height = 20)
        {
            return GUILayout.Toggle(boolean, text, GUILayout.MinWidth(width), GUILayout.MinHeight(height));
        }

        public string TextFieldArea(string label, string text, params GUILayoutOption[] options)
        {
            EditorGUILayout.LabelField(label);
            return EditorGUILayout.TextArea(text, options);
        }

        public void StartGreyedOutArea(bool toggle)
        {
            GUI.enabled = toggle;
        }

        public void EndGreyedOutArea()
        {
            GUI.enabled = true;
        }
    }
}


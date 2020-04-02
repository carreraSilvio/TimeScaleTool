using UnityEngine;
using UnityEditor;
using System;

namespace BrightLib.TimeScale
{
    public class TimeScaleWindow : EditorWindow
    {
        public Action<float> onChangeClick;
        public Action<float> onResetClick;

        private TimeScaleController _controller;

        private void OnEnable()
        {
            _controller = new TimeScaleController();
            onChangeClick = _controller.ChangeTimeScale;
            onResetClick = _controller.SetTimeScale;
        }

        private void OnDisable()
        {
            onChangeClick = null;
            onResetClick = null;
        }


        private void OnGUI()
        {
            StartGreyedOutArea(Application.isPlaying);

            EditorGUILayout.BeginVertical();
            {
                DrawLabelBold($"Time Scale is : {Time.timeScale.ToString("0.00")}");
                EditorGUILayout.BeginHorizontal();
                {
                    if (DrawButton("<<", width: 25f)) onChangeClick.Invoke(-0.25f);
                    if (DrawButton("<", width: 25f)) onChangeClick.Invoke(-0.1f);
                   
                    if (DrawButton("1", width: 40f)) onResetClick.Invoke(1f);
                    
                    if (DrawButton(">", width: 25f)) onChangeClick.Invoke(+0.1f);
                    if (DrawButton(">>", width: 25f)) onChangeClick.Invoke(+0.25f);
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();

            EndGreyedOutArea();
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


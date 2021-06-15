#if UNITY_EDITOR && RITO_LIBRARY_PROJECT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Reflection;

// 날짜 : 2021-06-15 PM 3:53:26
// 작성자 : Rito

namespace Rito.Extensions.Debugs
{
    /// <summary> 
    /// [TestCompleted] 체크
    /// </summary>
    public class TestCompletionCheckerWindow : EditorWindow
    {
        private GUIStyle boldLabel;
        private static TestCompletionCheckerWindow window;

        [MenuItem("Window/Rito/Extensions/Checker Window")]
        private static void Open()
        {
            window = (TestCompletionCheckerWindow)GetWindow(typeof(TestCompletionCheckerWindow));
            window.Show();

            // 윈도우 타이틀 지정
            window.titleContent.text = "Extension Method Test Checker";
        }

        private void OnEnable()
        {
            if (window == null)
                Open();

            FindAllExtensionMethods();
        }

        private void OnGUI()
        {
            if (boldLabel == null)
            {
                boldLabel = new GUIStyle(EditorStyles.boldLabel);
                boldLabel.normal.textColor = Color.cyan;
            }

            if (GUILayout.Button("Refresh"))
            {
                FindAllExtensionMethods();
            }

            foreach (var pair in notCompletedDict)
            {
                EditorGUILayout.LabelField($"{pair.Key}", boldLabel);
                foreach (var methodName in pair.Value)
                {
                    EditorGUILayout.LabelField(methodName);
                }
                EditorGUILayout.Space(12f);
            }

            Rect lastRect = GUILayoutUtility.GetLastRect();
            window.minSize = new Vector2(100f, lastRect.yMax);
        }

        private Dictionary<string, List<string>> completedDict = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> notCompletedDict = new Dictionary<string, List<string>>();

        private void FindAllExtensionMethods()
        {
            BindingFlags bf = BindingFlags.Static | BindingFlags.Public;

            var types = Assembly.GetExecutingAssembly().GetTypes();
            var types2 = types.Where(t =>
            {
                string str =
                    t.ToString().Replace("Rito.Extensions", "");

                return
                    str.Contains("Extension") &&
                    !str.Contains("Test_");
            });
            //var mi = from t in types2
            //         from m in t.GetMethods(bf)
            //         select m;
            var mis = types2.SelectMany(t => t.GetMethods(bf));

            var miCompleted    = mis.Where(m =>  m.IsDefined(typeof(TestCompletedAttribute)));
            var miNotCompleted = mis.Where(m => !m.IsDefined(typeof(TestCompletedAttribute)));

            // 1. Completed
            completedDict.Clear();

            foreach (var m in miCompleted)
            {
                string className = m.DeclaringType.Name;
                string methodName = m.Name;
                string dateString;

                var tca = m.GetCustomAttribute(typeof(TestCompletedAttribute)) as TestCompletedAttribute;
                dateString = $"[{tca.Year}-{tca.Month}-{tca.Day}]";

                if (!completedDict.ContainsKey(className))
                    completedDict.Add(className, new List<string>());

                completedDict[className].Add($"{dateString} {methodName}");
            }

            // 2. Not Completed
            notCompletedDict.Clear();

            foreach (var m in miNotCompleted)
            {
                string className = m.DeclaringType.Name;

                System.Text.StringBuilder methodSign = new System.Text.StringBuilder();
                methodSign.Append($"{m.Name}").Append(" (");

                var param = m.GetParameters();
                for (int i = 0; i < param.Length; i++)
                {
                    string paramTypeName =
                        param[i].ParameterType.ToString()
                        .Replace("UnityEngine.", "")
                        .Replace("System.Single", "float")
                        .Replace("System.", "");

                    methodSign.Append(paramTypeName);

                    if (i < param.Length - 1)
                        methodSign.Append(", ");
                }
                methodSign.Append(")");

                if (!notCompletedDict.ContainsKey(className))
                    notCompletedDict.Add(className, new List<string>());

                notCompletedDict[className].Add(methodSign.ToString());
            }
        }
    }
}

#endif
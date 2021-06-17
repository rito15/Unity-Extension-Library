using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-15 AM 4:47:14
// 작성자 : Rito

namespace Rito.Extensions.Test
{
    public class Test_DebugExtension : MonoBehaviour
    {
        public string sValue = "ABC";
        public float fValue = 123.45f;

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(Test_DebugExtension))]
        private class CE : UnityEditor.Editor
        {
            private Test_DebugExtension m;
            private void OnEnable()
            {
                m = target as Test_DebugExtension;
            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                if (GUILayout.Button("Log"))
                {
                    123.Log();
                    "Number : ".Log(123, " ", 456, " ", 78.9);
                }
                if (GUILayout.Button("LogError"))
                {
                    123.LogError();
                    "Number : ".LogError(123, " ", 456, " ", 78.9);
                }
                if (GUILayout.Button("Assert"))
                {
                    m.sValue.Assert("ABC");
                    m.sValue.Assert("ABC ");
                    m.fValue.Assert(123.45f);
                    123.45f.Assert(m.fValue);
                    m.fValue.Assert(123.451f);
                }
            }
        }
#endif
    }
}
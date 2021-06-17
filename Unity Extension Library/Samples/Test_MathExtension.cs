using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-15 AM 4:47:14
// 작성자 : Rito

namespace Rito.Extensions.Test
{
    public class Test_MathExtension : MonoBehaviour
    {
        public float fValue1 = 12.34f;
        public float fValue2 = -12.34f;

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(Test_MathExtension))]
        private class CE : UnityEditor.Editor
        {
            private Test_MathExtension m;
            private void OnEnable()
            {
                m = target as Test_MathExtension;
            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                if (GUILayout.Button("Reset"))
                {
                    m.fValue1 = 12.34f;
                    m.fValue2 = -12.34f;
                }

                if (GUILayout.Button("InRange"))
                {
                    m.fValue1.InRange(12.34f, 13f).Log();
                    m.fValue1.InRange(10, 12).Log();

                    m.fValue2.InRange(-12.34f, 0f).Log();
                    m.fValue2.InRange(-13, -12).Log();
                }

                if (GUILayout.Button("ExRange"))
                {
                    m.fValue1.ExRange(12.34f, 13f).Log();
                    m.fValue1.ExRange(10, 13).Log();

                    m.fValue2.ExRange(-12.34f, 0f).Log();
                    m.fValue2.ExRange(-13, -12).Log();
                }

                if (GUILayout.Button("Clamp"))
                {
                    m.fValue1.Clamp(0f, 10f).Log();
                    m.fValue2.Clamp(0f, 10f).Log();
                }

                if (GUILayout.Button("ClampRef"))
                {
                    m.fValue1.ClampRef(0f, 10f);
                    m.fValue2.ClampRef(0f, 10f);
                }

                if (GUILayout.Button("Saturate"))
                {
                    m.fValue1.Saturate().Log();
                    m.fValue2.Saturate().Log();
                }

                if (GUILayout.Button("SaturateRef"))
                {
                    m.fValue1.SaturateRef();
                    m.fValue2.SaturateRef();
                }
            }
        }
#endif
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-15 AM 4:47:14
// 작성자 : Rito

namespace Rito.Extensions.Test
{
    public class Test_Vector3Extension : MonoBehaviour
    {
        public Vector3 vec = new Vector3(1f, 2f, 3f);

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(Test_Vector3Extension))]
        private class CE : UnityEditor.Editor
        {
            private Test_Vector3Extension m;
            private void OnEnable()
            {
                m = target as Test_Vector3Extension;
            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                if (GUILayout.Button("Multiply"))
                {
                    m.vec.Multiply(new Vector3(0f, -1f, 2f)).Log();
                    m.vec.Multiply(new Vector3(0.1f, 0.01f, 0.001f)).Log();
                }

                if (GUILayout.Button("Divide"))
                {
                    m.vec.Divide(new Vector3(5f, -10f, 15f)).Log();
                    m.vec.Divide(new Vector3(0.5f, 0.1f, 0.01f)).Log();
                }

                if (GUILayout.Button("Set"))
                {

                }
            }
        }
#endif
    }
}
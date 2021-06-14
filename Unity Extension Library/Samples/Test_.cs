using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-15 AM 4:47:14
// 작성자 : Rito

namespace Rito.Extensions.Test
{
    public class Test_ : MonoBehaviour
    {

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(Test_))]
        private class CE : UnityEditor.Editor
        {
            private Test_ m;
            private void OnEnable()
            {
                m = target as Test_;
            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                if (GUILayout.Button("Test"))
                {

                }
            }
        }
#endif
    }
}
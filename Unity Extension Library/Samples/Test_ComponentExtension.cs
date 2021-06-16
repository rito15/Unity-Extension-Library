using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-15 AM 4:47:14
// 작성자 : Rito

namespace Rito.Extensions.Test
{
    public class Test_ComponentExtension : MonoBehaviour
    {
        public Transform tr;
        public BoxCollider bCol;
        public SphereCollider descendantCollider;

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(Test_ComponentExtension))]
        private class CE : UnityEditor.Editor
        {
            private Test_ComponentExtension m;
            private void OnEnable()
            {
                m = target as Test_ComponentExtension;
            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                if (GUILayout.Button("Reset"))
                {
                    DestroyImmediate(m.bCol);

                    m.bCol = null;
                    m.tr = null;
                    m.descendantCollider = null;
                }
                if (GUILayout.Button("Get Existed Component"))
                {
                    m.tr = m.GetOrAddComponent<Transform>();
                }
                if (GUILayout.Button("Add New Component"))
                {
                    m.bCol = m.GetOrAddComponent<BoxCollider>();
                }
                if (GUILayout.Button("Get Component in Descendants"))
                {
                    m.descendantCollider = m.GetComponentInDescendants<SphereCollider>();
                }
            }
        }
#endif
    }
}
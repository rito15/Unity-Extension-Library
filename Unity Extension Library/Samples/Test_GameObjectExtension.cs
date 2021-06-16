using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-15 AM 4:47:14
// 작성자 : Rito

namespace Rito.Extensions.Test
{
    public class Test_GameObjectExtension : MonoBehaviour
    {
        public Transform tr;
        public BoxCollider bCol;

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(Test_GameObjectExtension))]
        private class CE : UnityEditor.Editor
        {
            private Test_GameObjectExtension m;
            private void OnEnable()
            {
                m = target as Test_GameObjectExtension;
            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                if (GUILayout.Button("Reset"))
                {
                    DestroyImmediate(m.bCol);

                    m.bCol = null;
                    m.tr = null;
                }
                if (GUILayout.Button("Get Existed Component"))
                {
                    m.tr = m.gameObject.GetOrAddComponent<Transform>();
                }
                if (GUILayout.Button("Add New Component"))
                {
                    m.bCol = m.gameObject.GetOrAddComponent<BoxCollider>();
                }
            }
        }
#endif
    }
}
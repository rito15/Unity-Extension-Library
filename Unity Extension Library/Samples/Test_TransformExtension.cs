using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-15 AM 4:47:14
// 작성자 : Rito

namespace Rito.Extensions.Test
{
    public class Test_TransformExtension : MonoBehaviour
    {
        public Transform[] trArray1;
        public Transform[] trArray2;
        public List<Transform> allDescendants;

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(Test_TransformExtension))]
        private class CE : UnityEditor.Editor
        {
            private Test_TransformExtension m;
            private void OnEnable()
            {
                m = target as Test_TransformExtension;
            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                if (GUILayout.Button("Reset"))
                {
                    m.allDescendants = null;
                }
                if (GUILayout.Button("Get Depth"))
                {
                    Debug.Log($"Depth : {m.transform.GetDepth()}");
                }
                if (GUILayout.Button("Has Same Parent?"))
                {
                    Debug.Log($"trArray1 : {m.trArray1.HasSameParent()}");
                    Debug.Log($"trArray2 : {m.trArray2.HasSameParent()}");
                }
                if (GUILayout.Button("Get All Descendants"))
                {
                    m.allDescendants = m.transform.GetAllDescendants();
                }
                if (GUILayout.Button("Get All Descendants (Include Self)"))
                {
                    m.allDescendants = m.transform.GetAllDescendants(true);
                }
            }
        }
#endif
    }
}
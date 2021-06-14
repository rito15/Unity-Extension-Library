using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-15 AM 4:47:14
// 작성자 : Rito

namespace Rito.Extensions.Test
{
    public class Test_CollectionExtension : MonoBehaviour
    {
        public int[] intArray = { 1, 2, 3, 4, 5 };
        public List<float> floatList = new List<float>() { 0.1f, 0.2f, 0.3f, 0.4f };

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(Test_CollectionExtension))]
        private class CE : UnityEditor.Editor
        {
            private Test_CollectionExtension m;
            private void OnEnable()
            {
                m = target as Test_CollectionExtension;
            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                if (GUILayout.Button("Log All Elements"))
                {
                    m.intArray.LogAllElements();
                    m.floatList.LogAllElements();

                    m.intArray.LogAllElements("\n");
                    m.floatList.LogAllElements("\n");

                    m.intArray.LogAllElements(showIndex: true);
                    m.floatList.LogAllElements(showIndex: true);

                    m.intArray.LogAllElements("\n", true);
                    m.floatList.LogAllElements("\n", true);
                }

                if (GUILayout.Button("Get Random Element"))
                {
                    m.intArray.GetRandomElement().Log();
                    m.floatList.GetRandomElement().Log();
                }

                if (GUILayout.Button("Get Random Elements"))
                {
                    m.intArray.GetRandomElements(3).LogAllElements();
                    m.floatList.GetRandomElements(4).LogAllElements();
                }

                if (GUILayout.Button("Clone"))
                {
                    m.intArray.Ex_Clone().LogAllElements();
                    m.floatList.Ex_Clone().LogAllElements();
                }

                if (GUILayout.Button("Shuffle"))
                {
                    m.intArray.Ex_Clone().Shuffle().LogAllElements();
                    m.floatList.Ex_Clone().Shuffle().LogAllElements();
                }
            }
        }
#endif
    }
}
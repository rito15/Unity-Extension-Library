using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-17 AM 12:23:33
// 작성자 : Rito

namespace Rito.Extensions
{
    /// <summary> 무한 루프 간편 방지 </summary>
    public static class InfiniteLoopDetector
    {
        private static string prevPoint = "";
        private static int detectionCount = 0;
        private const int DetectionThreshold = 100000;

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void Run(
            [System.Runtime.CompilerServices.CallerMemberName] string mn = "",
            [System.Runtime.CompilerServices.CallerFilePath] string fp = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int ln = 0
        )
        {
            string currentPoint = $"{fp}{ln} : {mn}()";

            if (prevPoint == currentPoint)
                detectionCount++;
            else
                detectionCount = 0;

            if (detectionCount > DetectionThreshold)
                throw new Exception($"Infinite Loop Detected: \n{currentPoint}\n\n");

            prevPoint = currentPoint;
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
        private static void Init()
        {
            UnityEditor.EditorApplication.update += () =>
            {
                detectionCount = 0;
            };
        }
#endif

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void PrintCount()
        {
            Debug.Log($"detectionCount : {detectionCount}");
        }
    }
}
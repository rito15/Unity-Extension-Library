#pragma warning disable CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-02-26 AM 5:10:04
// 작성자 : Rito

/*
    [작성 규칙]

    - 메소드 상단에 테스트 완료 날짜 작성
*/

namespace Rito.Extensions
{
    using static CommonDefinitions;

    public static class DebugExtension
    {
        /***********************************************************************
        *                               Log
        ***********************************************************************/
        #region .
        [System.Diagnostics.Conditional(ConditionalDebugKeyword)]
        public static void Log<T>(this T @this)
            => Debug.Log(@this);

        [System.Diagnostics.Conditional(ConditionalDebugKeyword)]
        public static void Log<T>(this T @this, string preString)
            => Debug.Log(preString + @this);

        #endregion
        /***********************************************************************
        *                               Assert
        ***********************************************************************/
        #region .
        /// <summary>
        /// 값을 평가하여, 틀릴 경우 콘솔 에러 출력
        /// </summary>
        [System.Diagnostics.Conditional(ConditionalDebugKeyword)]
        public static void Assert<T>(this T @this, T other)
        {
            if (!@this.Equals(other))
                Debug.Log($"Assertion Failed : [{@this}] must be [{other}]");
        }

        #endregion

    }
}
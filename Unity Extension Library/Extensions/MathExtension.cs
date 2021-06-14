using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-03-05 AM 3:22:50
// 작성자 : Rito

/*
    [작성 규칙]

    - 메소드 상단에 테스트 완료 날짜 작성
    - 값을 직접 수정하는 경우 리턴하지 않음, 메소드 접미어 Ref
*/

/*
    [목록]

    - InExclusiveRange(min, max) : 값이 열린 구간 범위에 있는지 검사
    - InInclusiveRange(min, max) : 값이 닫힌 구간 범위에 있는지 검사
    - Clamp(min, max) : 값의 범위 제한
    - Saturate() : 값을 0 ~ 1 사이로 제한
*/

namespace Rito.Extensions
{
    public static class MathExtension
    {
        /***********************************************************************
        *                               Range, Clamp
        ***********************************************************************/
        #region .
        /// <summary> (min &lt;= value &lt;= max) </summary>
        public static bool InclusiveRange(this float value, float min, float max)
            => min <= value && value <= max;

        /// <summary> (min &lt; value &lt; max) </summary>
        public static bool ExclusiveRange(this float value, float min, float max)
            => min < value && value < max;

        /// <summary> 값의 범위 제한 </summary>
        public static float Clamp(this float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        /// <summary> 값의 범위 제한 </summary>
        public static void ClampRef(ref this float value, float min, float max)
        {
            if (value < min) value = min;
            if (value > max) value = max;
        }

        /// <summary> 0 ~ 1 값으로 제한 </summary>
        public static float Saturate(this float value)
        {
            if (value < 0f) return 0f;
            if (value > 1f) return 1f;
            return value;
        }

        /// <summary> 0 ~ 1 값으로 제한 </summary>
        public static void SaturateRef(ref this float value)
        {
            if (value < 0f) value = 0f;
            if (value > 1f) value = 1f;
        }

        #endregion
    }
}
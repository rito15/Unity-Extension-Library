#pragma warning disable CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-02-26 AM 12:51:10
// 작성자 : Rito

/*
    [작성 규칙]

    - 메소드 상단에 테스트 완료 날짜 작성
*/

namespace Rito.Extensions
{
    public static class Vector3Extension
    {
        /***********************************************************************
        *                               Calculations
        ***********************************************************************/
        #region .
        /// <summary> (x1 * x2, y1 * y2, z1 * z2) </summary>
        public static Vector3 Multiply(this Vector3 @this, Vector3 other)
            => new Vector3(@this.x * other.x, @this.y * other.y, @this.z * other.z);

        /// <summary> (x1 / x2, y1 / y2, z1 / z2) </summary>
        public static Vector3 Divide(this Vector3 @this, Vector3 other)
            => new Vector3(@this.x / other.x, @this.y / other.y, @this.z / other.z);

        #endregion
        /***********************************************************************
        *                               Setters
        ***********************************************************************/
        #region .
        public static Vector3 SetX(this Vector3 @this, float x)
            => new Vector3(x, @this.y, @this.z);
        public static Vector3 SetY(this Vector3 @this, float y)
            => new Vector3(@this.x, y, @this.z);
        public static Vector3 SetZ(this Vector3 @this, float z)
            => new Vector3(@this.x, @this.y, z);

        public static Vector3 SetXY(this Vector3 @this, float x, float y)
            => new Vector3(x, y, @this.z);
        public static Vector3 SetYZ(this Vector3 @this, float y, float z)
            => new Vector3(@this.x, y, z);
        public static Vector3 SetXZ(this Vector3 @this, float x, float z)
            => new Vector3(x, @this.y, z);

        #endregion
    }
}
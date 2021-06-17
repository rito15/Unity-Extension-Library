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

/*
 * [TODO]
 * 
 * - Color처럼 각각 X, Y, Z에 대해 Add, Mul, Div
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
        [TestCompleted(2021, 06, 17)]
        public static Vector3 Multiply(in this Vector3 @this, in Vector3 other)
            => new Vector3(@this.x * other.x, @this.y * other.y, @this.z * other.z);

        /// <summary> (x1 / x2, y1 / y2, z1 / z2) </summary>
        [TestCompleted(2021, 06, 17)]
        public static Vector3 Divide(in this Vector3 @this, in Vector3 other)
            => new Vector3(@this.x / other.x, @this.y / other.y, @this.z / other.z);

        #endregion
        /***********************************************************************
        *                               Setters
        ***********************************************************************/
        #region .
        public static Vector3 SetX(in this Vector3 @this, in float x)
            => new Vector3(x, @this.y, @this.z);
        public static Vector3 SetY(in this Vector3 @this, in float y)
            => new Vector3(@this.x, y, @this.z);
        public static Vector3 SetZ(in this Vector3 @this, in float z)
            => new Vector3(@this.x, @this.y, z);

        public static Vector3 SetXY(in this Vector3 @this, in float x, in float y)
            => new Vector3(x, y, @this.z);
        public static Vector3 SetYZ(in this Vector3 @this, in float y, in float z)
            => new Vector3(@this.x, y, z);
        public static Vector3 SetXZ(in this Vector3 @this, in float x, in float z)
            => new Vector3(x, @this.y, z);

        #endregion
    }
}
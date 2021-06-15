using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-15 PM 3:26:00
// 작성자 : Rito

/*
    [작성 규칙]

    - 메소드 상단에 테스트 완료 날짜 작성
    - 기본 라이브러리의 메소드와 이름이 겹치는 경우, Ex_접두어 사용
*/

namespace Rito.Extensions
{
    public static class ColorExtension
    {
        /***********************************************************************
        *                               Add
        ***********************************************************************/
        #region .
        [TestCompleted(2021, 06, 15)]
        public static Color AddR(in this Color color, float r)
        {
            return new Color(color.r + r, color.g, color.b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color AddG(in this Color color, float g)
        {
            return new Color(color.r, color.g + g, color.b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color AddB(in this Color color, float b)
        {
            return new Color(color.r, color.g, color.b + b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color AddA(in this Color color, float a)
        {
            return new Color(color.r, color.g, color.b, color.a + a);
        }

        [TestCompleted(2021, 06, 15)]
        public static Color AddRG(in this Color color, float rg)
        {
            return new Color(color.r + rg, color.g + rg, color.b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color AddGB(in this Color color, float gb)
        {
            return new Color(color.r, color.g + gb, color.b + gb, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color AddRB(in this Color color, float rb)
        {
            return new Color(color.r + rb, color.g, color.b + rb, color.a);
        }

        [TestCompleted(2021, 06, 15)]
        public static Color AddRGB(in this Color color, float rgb)
        {
            return new Color(color.r + rgb, color.g + rgb, color.b + rgb, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color AddRGB(in this Color color, float r, float g, float b)
        {
            return new Color(color.r + r, color.g + g, color.b + b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color AddRGB(in this Color color, in Color other)
        {
            return new Color(color.r + other.r, color.g + other.g, color.b + other.b, color.a);
        }

        #endregion
        /***********************************************************************
        *                               Multiply
        ***********************************************************************/
        #region .
        [TestCompleted(2021, 06, 15)]
        public static Color MultiplyR(in this Color color, float r)
        {
            return new Color(color.r * r, color.g, color.b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color MultiplyG(in this Color color, float g)
        {
            return new Color(color.r, color.g * g, color.b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color MultiplyB(in this Color color, float b)
        {
            return new Color(color.r, color.g, color.b * b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color MultiplyA(in this Color color, float a)
        {
            return new Color(color.r, color.g, color.b, color.a * a);
        }

        [TestCompleted(2021, 06, 15)]
        public static Color MultiplyRG(in this Color color, float rg)
        {
            return new Color(color.r * rg, color.g * rg, color.b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color MultiplyGB(in this Color color, float gb)
        {
            return new Color(color.r, color.g * gb, color.b * gb, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color MultiplyRB(in this Color color, float rb)
        {
            return new Color(color.r * rb, color.g, color.b * rb, color.a);
        }

        [TestCompleted(2021, 06, 15)]
        public static Color MultiplyRGB(in this Color color, float rgb)
        {
            return new Color(color.r * rgb, color.g * rgb, color.b * rgb, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color MultiplyRGB(in this Color color, float r, float g, float b)
        {
            return new Color(color.r * r, color.g * g, color.b * b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color MultiplyRGB(in this Color color, in Color other)
        {
            return new Color(color.r * other.r, color.g * other.g, color.b * other.b, color.a);
        }

        #endregion
        /***********************************************************************
        *                               Set
        ***********************************************************************/
        #region .
        [TestCompleted(2021, 06, 15)]
        public static Color SetR(in this Color color, float r)
        {
            return new Color(r, color.g, color.b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color SetG(in this Color color, float g)
        {
            return new Color(color.r, g, color.b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color SetB(in this Color color, float b)
        {
            return new Color(color.r, color.g, b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color SetA(in this Color color, float a)
        {
            return new Color(color.r, color.g, color.b, a);
        }

        [TestCompleted(2021, 06, 15)]
        public static Color SetRG(in this Color color, float r, float g)
        {
            return new Color(r, g, color.b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color SetGB(in this Color color, float g, float b)
        {
            return new Color(color.r, g, b, color.a);
        }
        [TestCompleted(2021, 06, 15)]
        public static Color SetRB(in this Color color, float r, float b)
        {
            return new Color(r, color.g, b, color.a);
        }

        [TestCompleted(2021, 06, 15)]
        public static Color SetRGB(in this Color color, float r, float g, float b)
        {
            return new Color(r, g, b, color.a);
        }

        #endregion
    }
}
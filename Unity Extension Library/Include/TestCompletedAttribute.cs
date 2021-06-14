using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-15 AM 4:43:39
// 작성자 : Rito

namespace Rito.Extensions
{
    /// <summary> 
    /// 테스트 완료 날짜 기록
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TestCompletedAttribute : Attribute
    {
        public int Year { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }

        public TestCompletedAttribute(int year, int month, int day)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }
    }
}
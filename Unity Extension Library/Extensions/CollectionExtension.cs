using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-03-05 AM 3:48:12
// 작성자 : Rito

/*
    [작성 규칙]

    - 메소드 상단에 테스트 완료 날짜 작성
    - 기본 라이브러리의 메소드와 이름이 겹치는 경우, Ex_접두어 사용
*/

/*
    [목록]

    Ex_Clone() : 배열, 리스트의 내용을 동일하게 복제한 객체 생성
    LogAllElements() : 리스트, 배열 내의 모든 요소를 콘솔에 차례대로 출력
    GetRandomElement() : 리스트, 배열 내에서 무작위 요소 뽑아 리턴
    GetRandomElements(int n) : 리스트, 배열 내에서 중복되지 않게 무작위 요소 n개 뽑아 리턴
    Shuffle() : 리스트, 배열의 내용을 무작위로 섞기
*/

namespace Rito.Extensions
{
    using static CommonDefinitions;
    using Conditional = System.Diagnostics.ConditionalAttribute;

    public static class CollectionExtension
    {
        /***********************************************************************
        *                               Debug
        ***********************************************************************/
        #region .

        [TestCompleted(2021, 06, 15)]
        /// <summary> 디버그 로그 창에 배열의 모든 내용 출력
        /// <para/> seperator : 각 요소를 구분할 구분자(기본 : 공백 1칸)
        /// <para/> showIndex : 각 요소 앞에 [n] 표시할지 여부
        /// </summary>
        [Conditional(ConditionalDebugKeyword)]
        public static void LogAllElements<T>(this IEnumerable<T> @this, string seperator = " ", bool showIndex = false)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            int i = 0;
            foreach (var element in @this)
            {
                if(showIndex)
                    sb.Append($"[{i++}] ");
                sb.Append(element.ToString()).Append(seperator);
            }

            Debug.Log(sb);
        }

        #endregion
        /***********************************************************************
        *                               Clone
        ***********************************************************************/
        #region .
        [TestCompleted(2021, 06, 15)]
        /// <summary> 동일하게 복제 </summary>
        public static T[] Ex_Clone<T>(this T[] @this)
        {
            T[] copy = new T[@this.Length];
            Array.Copy(@this, copy, @this.Length);
            return copy;
        }

        [TestCompleted(2021, 06, 15)]
        /// <summary> 동일하게 복제 </summary>
        public static List<T> Ex_Clone<T>(this List<T> @this)
        {
            return new List<T>(@this);
        }
        
        #endregion
        /***********************************************************************
        *                           Random, Shuffle
        ***********************************************************************/
        #region .

        [TestCompleted(2021, 06, 15)]
        /// <summary> 리스트 내에서 무작위 요소 뽑아 리턴 </summary>
        public static T GetRandomElement<T>(this IList<T> @this)
        {
            if(@this.Count == 0) return default;
            if(@this.Count == 1) return @this[0];

            int ranNum = UnityEngine.Random.Range(0, @this.Count);
            return @this[ranNum];
        }

        [TestCompleted(2021, 06, 15)]
        /// <summary> 배열 내에서 무작위 요소 뽑아 리턴 </summary>
        public static T GetRandomElement<T>(this T[] @this)
        {
            if(@this.Length == 0) return default;
            if(@this.Length == 1) return @this[0];

            int ranNum = UnityEngine.Random.Range(0, @this.Length);
            return @this[ranNum];
        }

        [TestCompleted(2021, 06, 15)]
        /// <summary> 리스트 내에서 무작위 요소들을 지정 개수만큼 중복되지 않게 뽑아 리스트로 리턴 </summary>
        public static List<T> GetRandomElements<T>(this IList<T> @this, int count)
        {
            int len = @this.Count;
            if (len == 0) return null;
            if (count <= 0) return null;

            // 리스트 개수 범위 초과하여 지정하지 않도록 제한
            if(count > len)
                count = len;

            List<T> ranList = new List<T>(count);
            HashSet<int> indexSet = new HashSet<int>();

            // 1. 랜덤 인덱스 뽑기
            for (int i = 0; i < count; i++)
            {
                int ranNum = UnityEngine.Random.Range(0, len);

                while (indexSet.Contains(ranNum))
                {
                    ranNum = UnityEngine.Random.Range(0, len);
                }
                indexSet.Add(ranNum);
            }

            // 2. 결과 리스트 채우기
            foreach (var index in indexSet)
            {
                ranList.Add(@this[index]);
            }

            return ranList;
        }

        [TestCompleted(2021, 06, 15)]
        /// <summary> 배열 내에서 무작위 요소들을 지정 개수만큼 중복되지 않게 뽑아 리스트로 리턴 </summary>
        public static T[] GetRandomElements<T>(this T[] @this, int count)
        {
            int len = @this.Length;
            if (len == 0) return null;
            if (count <= 0) return null;

            // 리스트 개수 범위 초과하여 지정하지 않도록 제한
            if(count > len)
                count = len;

            T[] ranArray = new T[count];
            HashSet<int> indexSet = new HashSet<int>();

            // 1. 랜덤 인덱스 뽑기
            for (int i = 0; i < count; i++)
            {
                int ranNum = UnityEngine.Random.Range(0, len);

                while (indexSet.Contains(ranNum))
                {
                    ranNum = UnityEngine.Random.Range(0, len);
                }
                indexSet.Add(ranNum);
            }

            // 2. 결과 배열 채우기
            int j = 0;
            foreach (var index in indexSet)
            {
                ranArray[j++] = (@this[index]);
            }

            return ranArray;
        }

        [TestCompleted(2021, 06, 15)]
        /// <summary> 리스트의 내용을 무작위로 섞기 (Fisher-Yates shuffle 알고리즘) </summary>
        public static List<T> Shuffle<T>(this List<T> @this)
        {
            // Fisher-Yates shuffle 알고리즘
            // 선형 순환하며 자신을 포함한 모든 인덱스를 무작위로 뽑아 교체
            // 교체된 대상은 다시 교체되지 않음

            int n = @this.Count;
            while (n > 1)
            {
                n--;

                int k = UnityEngine.Random.Range(0, n + 1);

                // Swap list[n] <-> list[k]
                T value = @this[k];
                @this[k] = @this[n];
                @this[n] = value;
            }

            return @this;
        }

        [TestCompleted(2021, 06, 15)]
        /// <summary> 배열의 내용을 무작위로 섞기 (Fisher-Yates shuffle 알고리즘) </summary>
        public static T[] Shuffle<T>(this T[] @this)
        {
            int n = @this.Length;
            while (n > 1)
            {
                n--;

                int k = UnityEngine.Random.Range(0, n + 1);

                // Swap list[n] <-> list[k]
                T value = @this[k];
                @this[k] = @this[n];
                @this[n] = value;
            }

            return @this;
        }

        #endregion
    }
}
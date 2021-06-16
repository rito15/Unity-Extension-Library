#pragma warning disable CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-02-28 AM 4:46:07
// 작성자 : Rito

/*
    [작성 규칙]

    - 메소드 상단에 테스트 완료 날짜 작성
*/

/*
    [목록]

    - HasSameParent(Transform[]) : 모두 같은 부모 아래 있는지 검사

*/

namespace Rito.Extensions
{
    public static class TransformExtension
    {
        /***********************************************************************
        *                               Getters
        ***********************************************************************/
        #region .
        /// <summary> 조상이 몇 명인지 깊이 구하기 </summary>
        [TestCompleted(2021, 06, 16)]
        public static int GetDepth(this Transform @this)
        {
            int depth = 0;
            Transform current = @this;
            while (current.parent != null)
            {
                current = current.parent;
                depth++;
            }
            return depth;
        }

        /// <summary>
        /// 모든 자손 트랜스폼들 목록 가져오기(비활성화된 트랜스폼 포함)
        /// <para/> - includeSelf : 본인 트랜스폼 포함
        /// </summary>
        [TestCompleted(2021, 06, 16)]
        public static List<Transform> GetAllDescendants(this Transform @this, bool includeSelf = false)
        {
            List<Transform> trList = new List<Transform>(@this.childCount);
            if (includeSelf)
                trList.Add(@this);

            return GetTransformsRecursively(@this, trList);
        }

        private static List<Transform> GetTransformsRecursively(Transform tr, List<Transform> list)
        {
            int count = tr.childCount;

            for (int i = 0; i < count; i++)
            {
                Transform ctr = tr.GetChild(i);
                list.Add(ctr);
                GetTransformsRecursively(ctr, list);
            }
            return list;
        }

        #endregion
        /***********************************************************************
        *                       Transform Array Extensions
        ***********************************************************************/
        #region .
        private static readonly HashSet<Transform> sameParentSet = new HashSet<Transform>();

        /// <summary> 모두 같은 부모 아래 있는지 검사 </summary>
        [TestCompleted(2021, 06, 16)]
        public static bool HasSameParent(this Transform[] transforms)
        {
            if (transforms == null || transforms.Length == 0)
                return false;

            sameParentSet.Clear();
            foreach (var tr in transforms)
            {
                if(tr != null)
                    sameParentSet.Add(tr.parent);
            }

            return sameParentSet.Count == 1;
        }

        #endregion
    }
}
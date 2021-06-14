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

        #endregion
        /***********************************************************************
        *                       Transform Array Extensions
        ***********************************************************************/
        #region .
        
        /// <summary> 모두 같은 부모 아래 있는지 검사 </summary>
        public static bool HasSameParent(this Transform[] transforms)
        {
            List<string> parentIdList = new List<string>();
            foreach (var activeTr in transforms)
            {
                string id = "None";
                if (activeTr.parent != null) id = activeTr.parent.GetInstanceID().ToString();
                if (!parentIdList.Contains(id)) parentIdList.Add(id);
            }

            return parentIdList.Count <= 1;
        }

        #endregion
    }
}
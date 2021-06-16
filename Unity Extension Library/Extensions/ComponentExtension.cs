using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-03-14 PM 7:56:04
// 작성자 : Rito

/*
    [작성 규칙]

    - 메소드 상단에 테스트 완료 날짜 작성
*/

namespace Rito.Extensions
{
    public static class ComponentExtension
    {
        [TestCompleted(2021, 06, 16)]
        public static T GetOrAddComponent<T>(this Component @this)
            where T : Component
        {
            if (!@this.TryGetComponent(out T component))
            {
                component = @this.gameObject.AddComponent<T>();
            }

            return component;
        }

        /// <summary> 모든 후손 게임오브젝트(비활성화 포함)에서 컴포넌트 찾아오기 </summary>
        [TestCompleted(2021, 06, 16)]
        public static T GetComponentInDescendants<T>(this Component @this)
            where T : Component
        {
            List<Transform> allDes = @this.transform.GetAllDescendants();
            foreach (var tr in allDes)
            {
                if (tr.TryGetComponent(out T target))
                    return target;
            }

            return null;
        }
    }
}
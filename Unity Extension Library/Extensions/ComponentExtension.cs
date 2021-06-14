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
        public static T GetOrAddComponent<T>(Component @this)
            where T : Component
        {
            var component = @this.GetComponent<T>();
            if (component == null)
            {
                component = @this.gameObject.AddComponent<T>();
            }

            return component;
        }
    }
}
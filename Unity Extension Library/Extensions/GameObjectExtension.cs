using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-03-14 PM 7:54:51
// 작성자 : Rito

/*
    [작성 규칙]

    - 메소드 상단에 테스트 완료 날짜 작성
*/

namespace Rito.Extensions
{
    public static class GameObjectExtension
    {
        [TestCompleted(2021, 06, 16)]
        public static T GetOrAddComponent<T>(this GameObject @this)
            where T : Component
        {
            if (!@this.TryGetComponent(out T component))
            {
                component = @this.AddComponent<T>();
            }

            return component;
        }
    }
}
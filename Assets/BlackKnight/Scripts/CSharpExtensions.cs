using System;
using UnityEngine;

namespace BlackKnight.UniIEX {
    public static class CSharpExtensions {
        public static void TryInvoke<T>(this Action<T> action, T t) {
            if (action != null)
                action(t);
        }
    }
}

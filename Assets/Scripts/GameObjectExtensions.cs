using System.Collections;
using UnityEngine;

namespace CodeBrewery.Glime
{
    public static class GameObjectExtensions
    {
        public static string GetPath(this GameObject current)
        {
            return current.transform.GetPath();
        }

        public static string GetPath(this Transform current)
        {
            if(current.parent == null)
            {
                return "/" + current.name;
            }
            return current.parent.GetPath() + "/" + current.name;
        }
    }
}
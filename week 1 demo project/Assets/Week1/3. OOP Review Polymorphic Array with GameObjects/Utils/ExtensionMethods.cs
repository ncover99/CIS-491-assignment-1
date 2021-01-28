using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
//Source 1:https://learn.unity.com/tutorial/extension-methods#5c89416dedbc2a1410355318
//Source 2: https://answers.unity.com/questions/530178/how-to-get-a-component-from-an-object-and-add-it-t.html

    //It is common to create a class to contain all of your
    //extension methods. This class must be static.
    public static class ExtensionMethods
    {
        //Even though they are used like normal methods, extension
        //methods must be declared static. Notice that the first
        //parameter has the 'this' keyword followed by a Component or GameObject
        //variable. This variable denotes which class the extension
        //method becomes a part of.

        public static T GetCopyOf<T>(this Component comp, T other) where T : Component
        {
            Type type = comp.GetType();
            if (type != other.GetType()) return null; // type mis-match
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
            PropertyInfo[] pinfos = type.GetProperties(flags);
            foreach (var pinfo in pinfos)
            {
                if (pinfo.CanWrite)
                {
                    try
                    {
                        pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                    }
                    catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                }
            }
            FieldInfo[] finfos = type.GetFields(flags);
            foreach (var finfo in finfos)
            {
                finfo.SetValue(comp, finfo.GetValue(other));
            }
            return comp as T;
        }

        //Usage example of the above extension method:  var copy = myComp.GetCopyOf(someOtherComponent);

        public static T AddComponent<T>(this GameObject go, T toAdd) where T : Component
        {
            return go.AddComponent<T>().GetCopyOf(toAdd) as T;
        }

        //Usage example of the above method: Health myHealth = gameObject.AddComponent<Health>(enemy.health);



    }

// Code written by Gabriel Mailhot, 30/04/2023.

#region

using System;
using System.Reflection;

#endregion

namespace LogRaamJousting
{
   public static class LogRaamReflexion
   {
      /// <summary>
      ///   Returns a private Property Value from a given Object. Uses Reflection.
      ///   Throws a ArgumentOutOfRangeException if the Property is not found.
      /// </summary>
      /// <typeparam name="T">Type of the Property</typeparam>
      /// <param name="obj">Object from where the Property Value is returned</param>
      /// <param name="propName">Propertyname as string.</param>
      /// <returns>PropertyValue</returns>
      public static T GetPrivateFieldValue<T>(this object obj, string propName)
      {
         if (obj == null) throw new ArgumentNullException("obj");
         Type t = obj.GetType();
         FieldInfo fi = null;
         while (fi == null && t != null)
         {
            fi = t.GetField(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            t = t.BaseType;
         }

         if (fi == null) throw new ArgumentOutOfRangeException("propName", string.Format("Field {0} was not found in Type {1}", propName, obj.GetType().FullName));

         return (T) fi.GetValue(obj);
      }

      /// <summary>
      ///   Returns a _private_ Property Value from a given Object. Uses Reflection.
      ///   Throws a ArgumentOutOfRangeException if the Property is not found.
      /// </summary>
      /// <typeparam name="T">Type of the Property</typeparam>
      /// <param name="obj">Object from where the Property Value is returned</param>
      /// <param name="propName">Propertyname as string.</param>
      /// <returns>PropertyValue</returns>
      public static T GetPrivatePropertyValue<T>(this object obj, string propName)
      {
         if (obj == null) throw new ArgumentNullException("obj");
         PropertyInfo pi = obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

         if (pi == null) throw new ArgumentOutOfRangeException("propName", string.Format("Property {0} was not found in Type {1}", propName, obj.GetType().FullName));

         return (T) pi.GetValue(obj, null);
      }

      /// <summary>
      ///   Set a private Property Value on a given Object. Uses Reflection.
      /// </summary>
      /// <typeparam name="T">Type of the Property</typeparam>
      /// <param name="obj">Object from where the Property Value is returned</param>
      /// <param name="propName">Propertyname as string.</param>
      /// <param name="val">the value to set</param>
      /// <exception cref="ArgumentOutOfRangeException">if the Property is not found</exception>
      public static void SetPrivateFieldValue<T>(this object obj, string propName, T val)
      {
         if (obj == null) throw new ArgumentNullException("obj");
         Type t = obj.GetType();
         FieldInfo fi = null;
         while (fi == null && t != null)
         {
            fi = t.GetField(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.IgnoreCase | BindingFlags.Static);
            t = t.BaseType;
         }

         if (fi == null) throw new ArgumentOutOfRangeException("propName", string.Format("Field {0} was not found in Type {1}", propName, obj.GetType().FullName));
         fi.SetValue(obj, val);
      }


      public static void SetPrivatePropertyValue<T>(this object obj, string propName, BindingFlags bindingFlag, T val)
      {
         if (obj == null) throw new ArgumentNullException("obj");
         Type t = obj.GetType();
         PropertyInfo fi = null;

         while (fi == null && t != null)
         {
            fi = t.GetProperty(propName, bindingFlag);
            t = t.BaseType;
         }

         if (fi == null) throw new ArgumentOutOfRangeException("propName", string.Format("Field {0} was not found in Type {1}", propName, obj.GetType().FullName));
         fi.SetValue(obj, val);
      }


      /// <summary>
      ///   Sets a _private_ Property Value from a given Object. Uses Reflection.
      ///   Throws a ArgumentOutOfRangeException if the Property is not found.
      /// </summary>
      /// <typeparam name="T">Type of the Property</typeparam>
      /// <param name="obj">Object from where the Property Value is set</param>
      /// <param name="propName">Propertyname as string.</param>
      /// <param name="val">Value to set.</param>
      /// <returns>PropertyValue</returns>
      public static void SetPrivatePropertyValue<T>(this object obj, string propName, T val)
      {
         Type t = obj.GetType();

         if (t.GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.IgnoreCase | BindingFlags.Static) == null) throw new ArgumentOutOfRangeException("propName", string.Format("Property {0} was not found in Type {1}", propName, obj.GetType().FullName));

         t.InvokeMember(propName, BindingFlags.SetProperty | BindingFlags.Instance, null, obj, new object[] {val});
      }
   }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEditor;
using Object = UnityEngine.Object;

public  static class EditorUtilities
{


    public static List<Type> FindTypesOf(Type type, bool considerAbstracts)
    {
        //var allTypes = new List<Type>();
        //foreach(var assembly in CompilationPipeline.GetAssemblies())
        //{
        //    allTypes.AddRange(assembly..GetTypes())
        //}

        //var assembely = Assembly.GetExecutingAssembly();
        var allTypes = GetAllTypes(type);
        List<Type> targetTypes = new List<Type>();

        foreach (var t in allTypes)
        {
            if (type.IsAssignableFrom(t))
            {
                if (considerAbstracts)
                    targetTypes.Add(t);
                else if (!t.IsInterface && !t.IsAbstract)
                    targetTypes.Add(t);
            }
        }

        return targetTypes;
    }

    public static System.Type[] GetAllTypes(System.Type aType)
    {
        var result = new List<System.Type>();
        var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
            result.AddRange(assembly.GetTypes());

        return result.ToArray();
    }


    // TODO: Refactor this.
    public static Type GetType(string typeName)
    {
        if (string.IsNullOrEmpty(typeName))
            return null;

        var type = Type.GetType(typeName);
        if (type != null)
            return type;

        var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
            if (assembly.GetType(typeName) != null)
                return assembly.GetType(typeName);

        return null;
    }

}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public static class Core
{
    public static void StartCoroutine(this MonoBehaviour monoBehaviour, ref Coroutine thread, IEnumerator coroutine)
    {
        if (thread != null)
            monoBehaviour.StopCoroutine(thread);
        thread = monoBehaviour.StartCoroutine(coroutine);
    }

    public static void StopCoroutine(this MonoBehaviour monoBehaviour, ref Coroutine thread)
    {
        if (thread != null)
        {
            monoBehaviour.StopCoroutine(thread);
            thread = null;
        }
    }

    public static void Start(this Coroutine thread, MonoBehaviour monoBehaviour, IEnumerator coroutine)
    {
        if (thread != null)
            monoBehaviour.StopCoroutine(thread);
        thread = monoBehaviour.StartCoroutine(coroutine);
    }

    public static void Stop(this Coroutine thread, MonoBehaviour monoBehaviour)
    {
        if (thread != null)
        {
            monoBehaviour.StopCoroutine(thread);
            thread = null;
        }
    }
}

public static class BitwiseHelpers
{
    public static bool Contains(this Enum e, Enum bits)
    {
        ulong baseValue = Convert.ToUInt64(e);
        ulong flagValue = Convert.ToUInt64(bits);

        return (baseValue & flagValue) == flagValue;
    }
}


public static class Randoms
{
    public static Vector3 RandomVector3()
    {
        return new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
    }

    public static Vector3 RandomVector3(float min, float max)
    {
        return new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
    }
}

public static class Transforms
{
    public static Transform ReturnClosest(this Transform candidate, Transform competitor, Vector3 comparisonPoint)
    {
        if (candidate == null)
            return null;
        //Use square distance for lighter comparison
        //If the other one is null
        if (competitor == null || (candidate.position - comparisonPoint).sqrMagnitude > (competitor.position - comparisonPoint).sqrMagnitude)
            return candidate;
        else
            return competitor;
    }

    public static Collider ReturnClosest(this Collider candidate, Collider competitor, Vector3 comparisonPoint)
    {
        if (candidate == null)
            return null;
        //Use square distance for lighter comparison
        if (competitor == null || (candidate.transform.position - comparisonPoint).sqrMagnitude > (competitor.transform.position - comparisonPoint).sqrMagnitude)
            return candidate;
        else
            return competitor;
    }

    // Translations
    public static Vector3 WorldToLocalVector(this Transform t, Vector3 pointInWorldSpace)
        => t.worldToLocalMatrix.MultiplyPoint3x4(pointInWorldSpace);
    public static Vector3 LocalToWorldVector(this Transform t, Vector3 pointInLocalSpace)
        => t.localToWorldMatrix.MultiplyPoint3x4(pointInLocalSpace);

    // Rotations
    public static Quaternion WorldToLocalQuaternion(this Transform t, Quaternion rotation)
        => Quaternion.Inverse(t.rotation) * rotation;
    public static Quaternion LocalToWorldQuaternion(this Transform t, Quaternion rotation)
        => t.rotation * rotation;
}

public static class GameObjects
{

    public static void SetActive(this GameObject[] objects, bool activation)
    {
        for (int i = 0; i < objects.Length; i++)
            objects[i]?.SetActive(activation);
    }

    public static T EnsureComponent<T>(this GameObject g) where T : Component
    {
        T t = g.GetComponent<T>();
        if (t == null)
            t = g.AddComponent<T>();
        return t;
    }
}

public static class MaterialSwag
{

    public static void SetFloat(this Material[] mats, string s, float value)
    {
        for (int i = 0; i < mats.Length; i++)
            mats[i].SetFloat(s, value);
    }
}

public static class UIHelpers
{
    // Private fields
    private static Dictionary<Graphic, Color> m_savedGraphicStates;

    public static void OverrideColor(this Graphic g, Color color)
    {
        // Initialize the dictionary if null
        if (m_savedGraphicStates == null)
            m_savedGraphicStates = new Dictionary<Graphic, Color>();

        // If the dictionary doesn't contain the key, add it. Otherwise, just update the color
        if (!m_savedGraphicStates.ContainsKey(g))
            m_savedGraphicStates.Add(g, g.color);

        g.color = color;
    }

    public static void ResetColor(this Graphic g)
    {
        if (m_savedGraphicStates == null || m_savedGraphicStates.Count <= 0)
            return;

        if (m_savedGraphicStates.ContainsKey(g))
        {
            g.color = m_savedGraphicStates[g];
            m_savedGraphicStates.Remove(g);
        }
    }

    public static bool Raycast(RectTransform[] rectTransforms, Ray ray)
    {
        foreach (RectTransform r in rectTransforms)
        {
            Vector3[] corners = new Vector3[4];
            r.GetWorldCorners(corners);
            Plane plane = new Plane(corners[0], corners[1], corners[2]);

            plane.Raycast(ray, out float enter);

            Vector3 intersection = ray.GetPoint(enter);
            Vector3 bottomEdge = corners[3] - corners[0];
            Vector3 leftEdge = corners[1] - corners[0];
            float bottomDot = Vector3.Dot(intersection - corners[0], bottomEdge);
            float leftDot = Vector3.Dot(intersection - corners[0], leftEdge);
            if (bottomDot < bottomEdge.sqrMagnitude &&
                leftDot < leftEdge.sqrMagnitude &&
                    bottomDot >= 0 &&
                    leftDot >= 0)
                return true;
        }

        return false;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class EventBroadcaster
{
	// Events
	public delegate void EventCallback(string eventName, object arg);
	public static event EventCallback OnEventCalled;

	private static Dictionary<string, Action<object>> _registeredActions = new Dictionary<string, Action<object>>();

	/// <summary>
	/// Adds an action to an event
	/// </summary>
	/// <param name="eventName">Event that will call the action</param>
	/// <param name="action">Action to be mapped to the event</param>
	public static void AddActionToEvent(string eventName, Action<object> action)
	{
		if (eventName == "")
			throw new NullReferenceException("");
		// Add an action to the list. Do nothing if the action is already registered
		if (!_registeredActions.ContainsKey(eventName))
			_registeredActions.Add(eventName, action);
		else
			_registeredActions[eventName] = action;
	}

	/// <summary>
	/// Removes a specific event from the list (and any action assigned to this event)
	/// </summary>
	/// <param name="eventName">The event to be removed</param>
	public static void RemoveEvent(string eventName)
	{
		if (_registeredActions.ContainsKey(eventName))
			_registeredActions.Remove(eventName);
	}

	/// <summary>
	/// Call a specific event
	/// </summary>
	/// <param name="eventName">Event to be called</param>
	public static void Call(string eventName, object arg = null)
	{
		if (eventName == "")
			throw new ArgumentNullException("Don't call unnamed events");
		if (_registeredActions.ContainsKey(eventName))
		{
			_registeredActions[eventName]?.Invoke(arg);
			OnEventCalled?.Invoke(eventName, arg);
		}
	}
}
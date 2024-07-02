using System;
using System.Collections.Generic;

public static class ServiceLocator
{
	private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

	public static void Register<T>(T service)
	{
		var type = typeof(T);
		if (_services.ContainsKey(type))
		{
			throw new Exception($"Service {type} is already registered.");
		}
		_services[type] = service;
	}

	public static T Get<T>()
	{
		var type = typeof(T);
		if (!_services.ContainsKey(type))
		{
			throw new Exception($"Service {type} is not registered.");
		}
		return (T)_services[type];
	}

	public static void Clear()
	{
		_services.Clear();
	}
}

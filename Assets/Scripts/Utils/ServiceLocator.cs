
using System;
using System.Collections.Generic;

public class ServiceLocator<T> : IServiceLocator<T>
{
	protected Dictionary<Type, T> _services { get; }
	public ServiceLocator()
	{
		_services = new Dictionary<Type, T>();
	}
	public TP Get<TP>() where TP : T
	{
		var type = typeof(TP);

		if (!_services.ContainsKey(type))
		{
			throw new Exception($"Service {type} is not registered.");
		}
		return (TP)_services[type];
	}

	public TP Register<TP>(TP service) where TP : T
	{
		var type = service.GetType();
		if (_services.ContainsKey(type))
		{
			throw new Exception($"Service {type} is already registered.");
		}
		_services[type] = service;
		return service;
	}

	public void Unregister<TP>(TP service) where TP : T
	{
		var type = service.GetType();

		if (_services.ContainsKey(type))
		{
			_services.Remove(type);
		}
		else
		{
			throw new Exception($"Service {type} is not registered.");

		}
	}

	public void Clear()
	{
		_services.Clear();
	}
}

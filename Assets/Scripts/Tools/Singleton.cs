using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
	public static class Singleton
	{
		public static void SetPattern<T>(ref T storage, T data, GameObject target, bool alertMode)
		{
			if (storage is null)
			{
				storage = data;
				Object.DontDestroyOnLoad(target);
			}
			else
			{
				if (alertMode)
				{
					Debug.LogWarning(data.GetType() + " Setting Singleton pattern was Failed! Error Target Hash Code is " + data.GetHashCode()+", "+data.ToString());
				}
				Object.Destroy(target);
			}
		}
	}
}

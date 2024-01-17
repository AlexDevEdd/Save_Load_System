using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace _Project.Scripts.Tools
{
	public static class UnityExtensionMethods
	{
		public static void Activate(this GameObject go) => go.SetActive(true);
		public static void Deactivate(this GameObject go) => go.SetActive(false);

		public static T Activate<T>(this T component) where T : Component
		{
			component.gameObject.SetActive(true);
			return component;
		}

		public static bool IsActive<T>(this T component) where T : Component
		{
			return component.gameObject.activeInHierarchy;
		}

		public static T Deactivate<T>(this T component) where T : Component
		{
			component.gameObject.SetActive(false);
			return component;
		}

		public static T SetActive<T>(this T component, bool active) where T : Component
		{
			component.gameObject.SetActive(active);
			return component;
		}

		public static T Copy<T>(this T source,
		                        Transform parent = null,
		                        string name = "",
		                        bool activate = true) where T : Component
		{
			if (source != null) return source.gameObject.Copy(parent, name, activate).GetComponent<T>();
			Debug.LogError("Null prefab");
			return null;
		}

		public static GameObject Copy(this GameObject source,
		                              Transform parent = null,
		                              string name = "",
		                              bool activate = true)
		{
			if (source == null)
			{
				Debug.LogError("Null prefab");
				return null;
			}

			var obj = Object.Instantiate(source, parent != null ? parent : source.transform.parent, false);
			obj.SetActive(activate);

			if (!string.IsNullOrEmpty(name))
			{
				obj.name = name;
			}
			return obj;
		}

		public static T SetParent<T>(this T behaviour, Transform parent, bool worldPositionStays = true) where T : MonoBehaviour
		{
			behaviour.transform.SetParent(parent, worldPositionStays);
			return behaviour;
		}

		public static void Destroy(this GameObject go, float delay = 0f)
		{
			if (go == null)
			{
				Debug.LogError("Can't destroy null obj");
				return;
			}

			if (!Application.isPlaying)
			{
				Object.DestroyImmediate(go, true);
				return;
			}

			if (delay > 0f)
			{
				Object.Destroy(go, delay);
			}
			else
			{
				Object.Destroy(go);
			}
		}

		public static void Destroy<T>(this GameObject go, float delay = 0f) where T : Component
		{
			if (go == null)
			{
				Debug.LogError("Can't destroy null obj");
				return;
			}

			go.GetComponent<T>().DestroyComponent();
		}

		public static void DestroyComponent(this Component component, float delay = 0f)
		{
			if (component == null)
			{
				Debug.LogError("Can't destroy null obj");
				return;
			}

			if (!Application.isPlaying)
			{
				Object.DestroyImmediate(component);
				return;
			}

			if (delay > 0f)
			{
				Object.Destroy(component, delay);
			}
			else
			{
				Object.Destroy(component);
			}
		}

		public static void DestroyGO<T>(this T component, float delay = 0f) where T : Component
		{
			if (component == null)
			{
				Debug.LogError("Can't destroy null component");
				return;
			}
            component.gameObject.Destroy(delay);
		}

		public static List<GameObject> GetChilds(this GameObject gameObject)
		{
			var result = new List<GameObject>();
			foreach (Transform child in gameObject.transform)
			{
				result.Add(child.gameObject);
			}
			return result;
		}
		
		public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
		{
			return gameObject.TryGetComponent<T>(out T t) 
				? t 
				: gameObject.AddComponent<T>();
		}
		
		public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);
		
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Scenes {
	private static Dictionary<string, string> parameters;

	public static void Load(string scene, Dictionary<string, string> parameters = null) {
		Scenes.parameters = parameters;
		SceneManager.LoadScene (scene);
	}

	public static void Load(string scene, string paramKey, string paramValue) {
		Scenes.parameters = new Dictionary<string, string> ();
		Scenes.parameters.Add (paramKey, paramValue);
		SceneManager.LoadScene (scene);
	}

	public static Dictionary<string, string> getSceneParam() {
		return parameters;
	}

	public static string getParameter(string paramKey) {
		if (parameters == null)
			return "";
		return parameters [paramKey];
	}

	public static void setParameter(string paramKey, string paramValue) {
		if (parameters == null)
			parameters = new Dictionary<string, string> ();
		parameters.Add (paramKey, paramValue);
	}
}

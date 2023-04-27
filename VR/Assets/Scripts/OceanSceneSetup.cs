using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class OceanSceneSetup : MonoBehaviour
{

	[SerializeField]
	GameObject defaultPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneChanger.s_sceneSetupFilename != null && SceneChanger.s_sceneSetupFilename.Length > 0)
		{
			ParseSetupFile(SceneChanger.s_sceneSetupFilename);
		}
		else if (defaultPrefab != null)
		{
			Instantiate(defaultPrefab, transform);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void ParseSetupFile(string filename)
	{
		if (!File.Exists("Assets/Resources/Scene Data/" + filename)) return;

		StreamReader sr = new StreamReader("Assets/Resources/Scene Data/" + filename);
		string line;
		while ((line = sr.ReadLine()) != null)
		{
			if (line.StartsWith("//")) continue; // Ignore comments

			if (File.Exists("Assets/Resources/Prefabs/" + line + ".prefab"))
			{
				GameObject obj = Resources.Load<GameObject>("Prefabs/" + line);

				Instantiate(obj, transform);
			}
		}
	}
}
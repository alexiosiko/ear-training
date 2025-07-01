using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GlobalSettings : MonoBehaviour
{
	[SerializeField] TMP_Dropdown keyDropDown;
	[SerializeField] TMP_Dropdown scaleDropDown;
	void Start()
	{
		// Get saved values
		string savedKey = PlayerPrefs.GetString("Key", keyDropDown.options[0].text);
		string savedScale = PlayerPrefs.GetString("Scale", scaleDropDown.options[0].text);

		// Set dropdown values to match saved prefs
		int keyIndex = keyDropDown.options.FindIndex(o => o.text == savedKey);
		if (keyIndex >= 0) keyDropDown.value = keyIndex;

		int scaleIndex = scaleDropDown.options.FindIndex(o => o.text == savedScale);
		if (scaleIndex >= 0) scaleDropDown.value = scaleIndex;

		// Add listeners
		keyDropDown.onValueChanged.AddListener(i =>
		{
			PlayerPrefs.SetString("Key", keyDropDown.options[i].text);
		});
		scaleDropDown.onValueChanged.AddListener(i =>
		{
			PlayerPrefs.SetString("Scale", scaleDropDown.options[i].text);
		});
	}


	void Update()
	{
		print(PlayerPrefs.GetString("Key"));
	}
}

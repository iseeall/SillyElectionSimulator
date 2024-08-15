using UnityEngine.UI;
using UnityEngine;


[RequireComponent(typeof(ScrollRect))]
internal class ScrollRectSensitivityFix : MonoBehaviour
{
	private ScrollRect scrollRect;

	private void Awake()
	{
		this.scrollRect = this.GetComponent<ScrollRect>();
		switch (Application.platform)
		{
			case RuntimePlatform.WindowsEditor:
			case RuntimePlatform.WindowsPlayer:
			case RuntimePlatform.OSXEditor:
			case RuntimePlatform.OSXPlayer:
			case RuntimePlatform.LinuxEditor:
			case RuntimePlatform.LinuxPlayer:
				this.scrollRect.scrollSensitivity = 50f;
				break;
			default:
				this.scrollRect.scrollSensitivity = 1f;
				break;
		}
	}
}

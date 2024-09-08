// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System.Collections.Generic;
using UnityEngine;

namespace QuackleBit
{
	public class ForceChangeScreenResolution16by9 : MonoBehaviour
	{

		private readonly List<Resolution> possibleResolutionsForUsersMonitor = new List<Resolution>();
		// public TMP_Dropdown resolutionDropdown;

		private readonly List<Resolution> predefined16By9Resolutions = new List<Resolution>
		{
			new Resolution { width = 720, height = 400 },
			new Resolution { width = 1280, height = 720 },
			new Resolution { width = 1600, height = 900 },
			new Resolution { width = 1920, height = 1080 },
			new Resolution { width = 2560, height = 1440 },
			new Resolution { width = 3200, height = 1800 },
			new Resolution { width = 3840, height = 2160 }
		};

		private void Start()
		{
			PopulateResolutionDropdown();
		}

		private void PopulateResolutionDropdown()
		{
			// resolutionDropdown.ClearOptions();

			List<string> options = new List<string>();

			int currentResolutionIndex = 0;

			Vector2Int usersLargestResolution = GetLargestDisplaysResolution();
			int usersWidth = usersLargestResolution.x;
			int usersHeight = usersLargestResolution.y;


			for (int i = 0; i < predefined16By9Resolutions.Count; i++)
			{
				Resolution currentRes = predefined16By9Resolutions[i];

				if (usersWidth >= currentRes.width && usersHeight >= currentRes.height)
				{
					string option = currentRes.width + "x" + currentRes.height;
					options.Add(option);
					currentResolutionIndex = i;
					possibleResolutionsForUsersMonitor.Add(currentRes);

				}
				else
				{
					break;
				}
			}

			// resolutionDropdown.AddOptions(options);
			// resolutionDropdown.value = currentResolutionIndex;
			// resolutionDropdown.RefreshShownValue();

			SetResolution(currentResolutionIndex);
		}

		private void SetResolution(int resolutionIndex)
		{
			Resolution resolution = possibleResolutionsForUsersMonitor[resolutionIndex];
			Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
		}

		private Vector2Int GetLargestDisplaysResolution()
		{
			int largestResWidth = 0;
			int largestResHeight = 0;

			foreach (Display myDisplay in Display.displays)
			{
				int myWidth = myDisplay.systemWidth;
				int myHeight = myDisplay.systemHeight;

				if (myWidth <= largestResWidth || myHeight <= largestResHeight)
					continue;

				largestResWidth = myWidth;
				largestResHeight = myHeight;
			}

			return new Vector2Int(largestResWidth, largestResHeight);
		}
	}
}
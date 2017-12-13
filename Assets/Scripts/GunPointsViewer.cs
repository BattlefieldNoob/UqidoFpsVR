using UnityEngine;
using UnityEngine.UI;

public class GunPointsViewer : MonoBehaviour
{

	private Text _pointsText;
	
	void Start ()
	{
		_pointsText = GetComponentInChildren<Text>();
		
		EventManager.Instance.OnPointsUpdated.AddListener(OnPointsUpdated);
	}

	private void OnPointsUpdated(float actualPoints)
	{
		_pointsText.text = $"Points:{actualPoints}";
	}
}

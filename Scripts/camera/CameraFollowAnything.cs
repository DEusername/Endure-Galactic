using UnityEngine;
using System.Collections;

public class CameraFollowAnything : MonoBehaviour
{
	private Transform target_object;
	public float follow_tightness;
	Vector3 wanted_position;

	public GameObject prisonShip;
	public GameObject humanPlayer;
	public GameObject wifeShip;

	private bool followPrisonShip = true;

	// Use this for initialization
	void Start()
	{
		target_object = prisonShip.transform;
	}

    private void Update()
    {
		if(humanPlayer.activeSelf == true)
        {
			target_object = humanPlayer.transform;
        }

		if (wifeShip.activeSelf == true && humanPlayer.activeSelf == false)
        {
			target_object = wifeShip.transform;
        }
	}

    // Update is called once per frame
    void FixedUpdate()
	{

		if (target_object != null)
		{
			wanted_position = target_object.position;
			wanted_position.z = transform.position.z;
			transform.position = Vector3.Lerp(transform.position, wanted_position, Time.deltaTime * follow_tightness);
		}
	}



}

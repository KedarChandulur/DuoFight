using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] private Transform TurrentAMuzzle;
    [SerializeField] private Transform TurrentBMuzzle;

	[SerializeField] private Transform ParentTurrentAMuzzle;
	[SerializeField] private Transform ParentTurrentBMuzzle;

	[SerializeField] private Transform GreenBall;
    [SerializeField] private Transform PinkBall;

	void Update () {
		if(Input.GetMouseButtonDown(0) && TurrentAMuzzle != null)
        {
			if(TurrentAMuzzle.gameObject.activeSelf && ParentTurrentAMuzzle.gameObject.activeSelf)
            Instantiate(GreenBall, TurrentAMuzzle.position, Quaternion.identity);
        }
        if(Input.GetMouseButtonDown(1) && TurrentBMuzzle != null)
        {
			if (TurrentBMuzzle.gameObject.activeSelf && ParentTurrentBMuzzle.gameObject.activeSelf)
				Instantiate(PinkBall, TurrentBMuzzle.position, Quaternion.identity);
        }
	}
}

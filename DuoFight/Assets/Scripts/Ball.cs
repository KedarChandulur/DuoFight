using UnityEngine;

public class Ball : MonoBehaviour
{
	public string tag1;
	public string tag2;
	[SerializeField] private Vector3 direction;
	private Rigidbody rb;
	private float movementspeed = 25f;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		rb.velocity = direction * movementspeed;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == tag1)
		{
			BlockSpawner.count--;
			Destroy(collision.gameObject);
			Destroy(this.gameObject);
			if (BlockSpawner.count == 0)
			{
				BlockSpawner.InvokeRestart();
			}
		}
		if (collision.gameObject.tag == tag2)
		{
			BlockSpawner.InvokeRetry();
			collision.gameObject.SetActive(false);
			Destroy(this.gameObject);
		}
	}
}

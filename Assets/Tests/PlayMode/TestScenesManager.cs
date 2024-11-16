using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestScenesManager
{

	// A UnityTest behaves like a coroutine in Play Mode.
	// In Edit Mode you can use `yield return null;` to skip a frame.
	[UnityTest]
	public IEnumerator AllScenesCanBeOpened()
	{
		SceneManager.LoadScene("SampleScene");
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("EndScene");
		yield return new WaitForSeconds(1);

		Assert.Pass();
	}
}

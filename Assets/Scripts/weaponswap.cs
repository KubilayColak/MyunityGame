using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponswap : MonoBehaviour {

	public GameObject Weapon01;
	public GameObject Weapon02;
	public GameObject Weapon03;
	public GameObject Swat01;
	public GameObject Swat02;
	public GameObject Swat03;

	// Use this for initialization
	void Start () 
		{
			Weapon01.SetActive (true);
			Weapon02.SetActive (false);
			Weapon03.SetActive (false);
			Swat01.SetActive (true);
			Swat02.SetActive (false);
			Swat03.SetActive (false);

		}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown("1"))
		{
			Weapon01.SetActive (true);
			Weapon02.SetActive (false);	
			Weapon03.SetActive (false);
			Swat01.SetActive (true);
			Swat02.SetActive (false);
			Swat03.SetActive (false);
		}

		if (Input.GetKeyDown ("2")) 
		{
			Weapon01.SetActive (false);
			Weapon02.SetActive (true);
			Weapon03.SetActive (false);
			Swat01.SetActive (false);
			Swat02.SetActive (true);
			Swat03.SetActive (false);
		}

		if (Input.GetKeyDown ("3")) 
		{
			Weapon01.SetActive (false);
			Weapon02.SetActive (false);
			Weapon03.SetActive (true);
			Swat01.SetActive (false);
			Swat02.SetActive (false);
			Swat03.SetActive (true);
		}
}
}
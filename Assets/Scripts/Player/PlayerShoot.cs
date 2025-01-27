﻿using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
	public GameObject bullet, bmuzzle;
	public int bulletSpeed = 30;
	float shootSpeed = 1;
	float reloadTime = 2;
	bool reloading = false;
	RaycastHit hit;
	//public Animator anim;

	void Start()
	{
		hit = new RaycastHit();
		//anim = GetComponent<Animator>();
	}

	void Update()
	{
		if (MyData.curAmmo <= 0 && MyData.maxAmmo > 0 && !reloading || (MyData.curAmmo < 30 && MyData.maxAmmo > 0 && Input.GetKeyDown(KeyCode.R) && !reloading))
		{
			reloading = true;
			reloadTime = 0;
			//anim.SetBool("Reloading", true);
		} 
		if (reloading &&  reloadTime >= 2)
		{
			Reload();
			reloading = false;
			//anim.SetBool("Reloading", false);
		}
		if (Input.GetMouseButton(0) && !MyManager.isPause && !MyManager.isDead && EnemySpawner.Spawn && MyData.curAmmo > 0 && !reloading && shootSpeed >= 0.1)
		{
			Shoot();
		}
		shootSpeed += Time.deltaTime;
		reloadTime += Time.deltaTime;
	}

	void Reload()
	{
		int ammoRemainder;
		if (MyData.curAmmo > MyData.magSize)
		{
			ammoRemainder = MyData.curAmmo - MyData.magSize;
		}
		else
		{
			ammoRemainder = MyData.magSize - MyData.curAmmo;
		}
		MyData.curAmmo = 0;
		if (MyData.maxAmmo < 30)
		{
			MyData.curAmmo = MyData.maxAmmo;
		}
		else
		{
			MyData.curAmmo = MyData.magSize;
		}
		MyData.maxAmmo -= ammoRemainder;
	}

	void Shoot()
	{
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		if (Physics.Raycast(ray, out hit, 100.0f))
		{
			GameObject clone = (GameObject)Instantiate(bullet, bmuzzle.transform.position, bmuzzle.transform.rotation) as GameObject;
			clone.GetComponent<Rigidbody>().velocity = (hit.point - bmuzzle.transform.position).normalized * bulletSpeed;
			AudioSource M4A4 = bmuzzle.GetComponent<AudioSource>();
			M4A4.Play();
			if (hit.collider.gameObject.tag == "Enemy")
			{
				hit.transform.gameObject.GetComponent<EnemyHP>().TakeDamage(MyData.damage);
				hit.transform.gameObject.GetComponent<EnemyHP>().isHeadshot = false;
				print("BodyShot");
			}
			else if (hit.collider.gameObject.tag == "Head")
			{
				hit.transform.GetComponent<EnemyHP>().TakeDamage(MyData.damage * 2);
				hit.transform.GetComponent<EnemyHP>().isHeadshot = true;
				print("HeadShot");
			}
			else
			{
				if (hit.collider.gameObject.tag != "Bullet")
				{
					if (hit.collider.gameObject.tag != "Player")
					{
						Destroy(bullet);
					}
				}
			}
		}
		shootSpeed = 0;
		if (MyData.curAmmo != 0)
		{
			MyData.curAmmo--;
		}
	}
}
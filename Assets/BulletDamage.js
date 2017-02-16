var Damage = 100;

function OnCollisionEnter (info : Collision)
{
	info.transform.SendMessage("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
}

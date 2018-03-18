﻿using UnityEngine;

public class CollisionComponent : BaseComponent
{

	private Collider m_collider = null;

	// --------------------------------------------------------------------------------

	public override void OnAwake() 
	{
		m_collider = GetComponent<Collider>();
		Debug.Assert(m_collider != null, "[Collisioncomponent::OnAwake] GetComponent<Collider> failed\n");
	}

	// --------------------------------------------------------------------------------
	
	public override void OnStart()
	{
		;
	}

	// --------------------------------------------------------------------------------

	public override void OnUpdate()
	{
		;
	}

	// --------------------------------------------------------------------------------

	public override void Destroy()
	{
		;
	}

}
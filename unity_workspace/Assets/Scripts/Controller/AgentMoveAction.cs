﻿using UnityEngine;

public class AgentMoveAction : AgentAction
{

	[SerializeField]
	private MovementDirection m_direction = MovementDirection.Forward;

	[SerializeField, Range(-1, 1)]
	private int m_modifier = 1;

	// --------------------------------------------------------------------------------

	public override void Execute()
	{
		if (m_agentController == null)
		{
			return;
		}

		switch (m_direction)
		{
			case MovementDirection.Forward:
				m_agentController.MoveForward(m_modifier);
				break;

			case MovementDirection.Sideways:
				m_agentController.MoveSideways(m_modifier);
				break;
		}
	}

}
﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class BSPPartition : IComparable<BSPPartition>
{

	private Vector3 m_minBounds = Vector3.zero;
	public Vector3 MinBounds { get { return m_minBounds; } }

	private Vector3 m_maxBounds = Vector3.zero;
	public Vector3 MaxBounds { get { return m_maxBounds; } }

	private List<Agent> m_agents = new List<Agent>();
	public int AgentCount { get { return m_agents.Count; } }
	public List<Agent> Agents { get { return m_agents; } }

	// --------------------------------------------------------------------------------

	public BSPPartition(Vector3 minBounds, Vector3 maxBounds)
	{
		m_minBounds = minBounds;
		m_maxBounds = maxBounds;
	}

	// --------------------------------------------------------------------------------

	public void AddAgent(Agent agent)
	{
		Vector3 agentPosition = agent.Transform.position;
		Debug.AssertFormat(agentPosition.x >= m_minBounds.x, "[BSPPartition::AddAgent] Agent is not within minimum bounds (x) Agent.x: {0}, MinBounds.X: {1}\n", agentPosition.x, m_minBounds.x);
		Debug.AssertFormat(agentPosition.y >= m_minBounds.y, "[BSPPartition::AddAgent] Agent is not within minimum bounds (y) Agent.y: {0}, MinBounds.y: {1}\n", agentPosition.y, m_minBounds.y);
		Debug.AssertFormat(agentPosition.z >= m_minBounds.z, "[BSPPartition::AddAgent] Agent is not within minimum bounds (z) Agent.z: {0}, MinBounds.z: {1}\n", agentPosition.z, m_minBounds.z);
		Debug.AssertFormat(agentPosition.x <= m_minBounds.x, "[BSPPartition::AddAgent] Agent is not within maximum bounds (x) Agent.x: {0}, MaxBounds.X: {1}\n", agentPosition.x, m_maxBounds.x);
		Debug.AssertFormat(agentPosition.y <= m_minBounds.y, "[BSPPartition::AddAgent] Agent is not within maximum bounds (y) Agent.y: {0}, MaxBounds.y: {1}\n", agentPosition.y, m_maxBounds.y);
		Debug.AssertFormat(agentPosition.z <= m_minBounds.z, "[BSPPartition::AddAgent] Agent is not within maximum bounds (z) Agent.z: {0}, MaxBounds.z: {1}\n", agentPosition.z, m_maxBounds.z);
		Debug.Assert(m_agents.Contains(agent) == false, "[BSPPartition::AddAgent] Agent is already in this partition\n");

		m_agents.Add(agent);
	}

	// --------------------------------------------------------------------------------

	public void RemoveAgent(Agent agent)
	{
		Debug.Assert(m_agents.Contains(agent), "[BSPPartition::RemoveAgent] Agent is not in this partition\n");

		m_agents.Remove(agent);
	}

	// --------------------------------------------------------------------------------

	public bool ContainsAgent(Agent agent)
	{
		return m_agents.Contains(agent);
	}

	// --------------------------------------------------------------------------------

	public bool ContainsPoint(Vector3 point)
	{
		return point.x >= m_minBounds.x && point.x <= m_maxBounds.x &&
			point.y >= m_minBounds.y && point.y <= m_maxBounds.y &&
			point.z >= m_minBounds.z && point.z <= m_maxBounds.z;
	}

	// --------------------------------------------------------------------------------

	public void FlushAgents()
	{
		m_agents.Clear();
	}

	// --------------------------------------------------------------------------------

	public int CompareTo(BSPPartition other)
	{
		// #SteveD	>>> how to compare 2 partitions?
		return 0;
	}

}
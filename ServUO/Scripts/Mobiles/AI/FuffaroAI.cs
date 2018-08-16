using System;

//
// This is a first simple AI
//
//
namespace Server.Mobiles
{
	public class FuffaroAI : BaseAI
	{
		public FuffaroAI (BaseCreature m)
			: base(m)
		{
		}
		int fama=0;
		public override bool DoActionWander()
		{
			m_Mobile.DebugSay("I have no combatant");

			if (AcquireFocusMob(m_Mobile.RangePerception, m_Mobile.FightMode, false, false, true))
			{
				m_Mobile.DebugSay("I have detected {0}, attacking", m_Mobile.FocusMob.Name);

				m_Mobile.Combatant = m_Mobile.FocusMob;
				Mobile mob = m_Mobile.Combatant as Mobile;

				if ((int)mob.Fame>(int)(3*m_Mobile.Fame)) {
					fama = 1;
					base.DoActionFlee();
					m_Mobile.Say ("OMG it's {0}! Run for your lives!", m_Mobile.Combatant.Name);
					return true;
				} 
				else if (mob.Fame>=m_Mobile.Fame && Utility.RandomDouble>0.9) {
					fama = 1;
					base.DoActionFlee();
					m_Mobile.Say ("OMG it's {0}! Run for your lives!", m_Mobile.Combatant.Name);
					return true;
				} 
				else {
					Action = ActionType.Combat;
				}
					
			}
			else
			{
				if (fama==0) base.DoActionWander();
			}

			return true;
		}

		public override bool DoActionCombat()
		{
			IDamageable c = m_Mobile.Combatant;
			if (c == null || c.Deleted || c.Map != m_Mobile.Map || !c.Alive || (c is Mobile && ((Mobile)c).IsDeadBondedPet))
			{
				m_Mobile.DebugSay("My combatant is gone, so my guard is up");
				fama = 0;

				Action = ActionType.Guard;

				return true;
			}

			if (!m_Mobile.InRange(c, m_Mobile.RangePerception))
			{
				// They are somewhat far away, can we find something else?
				if (AcquireFocusMob(m_Mobile.RangePerception, m_Mobile.FightMode, false, false, true))
				{
					m_Mobile.Combatant = m_Mobile.FocusMob;
					m_Mobile.FocusMob = null;
				}
				else if (!m_Mobile.InRange(c, m_Mobile.RangePerception * 3))
				{
					m_Mobile.Combatant = null;
				}

				c = m_Mobile.Combatant;

				if (c == null)
				{
					m_Mobile.DebugSay("My combatant has fled, so I am on guard");
					Action = ActionType.Guard;

					return true;
				}
			}

			if ((MoveTo(c, true, m_Mobile.RangeFight)) && fama==0)
			{
				m_Mobile.Direction = m_Mobile.GetDirectionTo(c);
			}
			else if ((AcquireFocusMob(m_Mobile.RangePerception, m_Mobile.FightMode, false, false, true)) && fama==0)
			{
				m_Mobile.DebugSay("My move is blocked, so I am going to attack {0}", m_Mobile.FocusMob.Name);

				m_Mobile.Combatant = m_Mobile.FocusMob;
				Action = ActionType.Combat;

				return true;
			}
			else if (m_Mobile.GetDistanceToSqrt(c) > m_Mobile.RangePerception + 1)
			{
				m_Mobile.DebugSay("I cannot find {0}, so my guard is up", c.Name);

				Action = ActionType.Guard;

				return true;
			}
			else
			{
				m_Mobile.DebugSay("I should be closer to {0}", c.Name);
			}

			if (!m_Mobile.Controlled && !m_Mobile.Summoned && m_Mobile.CanFlee)
			{
				if (m_Mobile.Hits < m_Mobile.HitsMax * 20 / 100)
				{
					// We are low on health, should we flee?
					if (Utility.Random(100) <= Math.Max(10, 10 + c.Hits - m_Mobile.Hits))
					{
						m_Mobile.DebugSay("I am going to flee from {0}", c.Name);
						Action = ActionType.Flee;
					}
				}
			}

			return true;
		}

		public override bool DoActionGuard()
		{
			if ((AcquireFocusMob(m_Mobile.RangePerception, m_Mobile.FightMode, false, false, true) && fama==0))
			{
				m_Mobile.DebugSay("I have detected {0}, attacking", m_Mobile.FocusMob.Name);

				m_Mobile.Combatant = m_Mobile.FocusMob;
				Action = ActionType.Combat;
			}
			else
			{
				base.DoActionGuard();
			}

			return true;
		}

		public override bool DoActionFlee()
		{
			Mobile c = m_Mobile.Combatant as Mobile;

			if ((m_Mobile.Hits > (m_Mobile.HitsMax / 2)) && fama==0)
			{
				// If I have a target, go back and fight them
				if (c != null && m_Mobile.GetDistanceToSqrt(c) <= m_Mobile.RangePerception * 2)
				{
					m_Mobile.DebugSay("I am stronger now, reengaging {0}", c.Name);
					Action = ActionType.Combat;
				}
				else
				{
					m_Mobile.DebugSay("I am stronger now, my guard is up");
					Action = ActionType.Guard;
				}
			}
			else
			{
				base.DoActionFlee();
			}

			return true;
		}
	}
}

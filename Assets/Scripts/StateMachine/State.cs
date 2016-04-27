using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public abstract class State : MonoBehaviour {

		public virtual void Enter()
		{
			AddListeners();
		}
		
		public virtual void Exit()
		{
			RemoveListeners();
		}
		
		public virtual void OnDestroy()
		{
			RemoveListeners();
		}
		
		protected virtual void AddListeners()
		{
			
		}
		
		protected virtual void RemoveListeners()
		{
			
		}
		
	}
	
}

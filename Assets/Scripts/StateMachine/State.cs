using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public abstract class State : MonoBehaviour {

		public IEnumerator currentAction {
			get {return _currentState;}
			set 
			{
				if (value != _currentState)
				{
					if (_currentState != null)
						StopCoroutine(_currentState);

					_currentState = value;

					if (_currentState != null)
						StartCoroutine(_currentState);
				}
			}
		}
		IEnumerator _currentState;

		public virtual void Enter()
		{
			AddListeners();

			if (currentAction != null)
				StartCoroutine(currentAction);
		}
		
		public virtual void Exit()
		{
			RemoveListeners();

			if (currentAction != null)
				StopCoroutine(currentAction);
		}
		
		public virtual void OnDestroy()
		{
			Exit();
		}
		
		protected virtual void AddListeners()
		{
			
		}
		
		protected virtual void RemoveListeners()
		{
			
		}
		
	}
	
}

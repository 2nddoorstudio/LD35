using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public abstract class State : MonoBehaviour {

		public IEnumerator currentAction {
			get {return _currentAction;}
			set 
			{
				if (value != _currentAction)
				{
					if (_currentAction != null)
						StopCoroutine(_currentAction);

					_currentAction = value;

					if (_currentAction != null)
						StartCoroutine(_currentAction);
				}
			}
		}
		IEnumerator _currentAction;

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

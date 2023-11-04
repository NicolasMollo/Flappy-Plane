using System.Collections;
using UnityEngine;
using System;


namespace Commands
{

    [CreateAssetMenu(menuName = "Create Command/Deactivate object")]
    public class CommandBehaviour_DeactivateObject : CommandBehaviour
    {

        [Header("DATA")]

        [SerializeField]
        [Tooltip("if you want to deactivate the parent object")]
        private bool actOnParent = false;

        [SerializeField]
        [Range(0f, 10f)]
        [Tooltip("Waiting time before deactivating the object")]
        private float waitingTime = 0f;

        [SerializeField]
        [Tooltip("if you want to destroy the object after deactivating it")]
        private bool destroyObjectAfterDeactivateIt = false;



        public override void DoCommand(GameObject _self)
        {

            base.DoCommand(_self);

            _self.GetComponent<MonoBehaviour>().StartCoroutine(DeactivateObject(actOnParent ? _self.transform.parent.gameObject : _self));

            CurrentState = CBState.Completed;

        }

        private IEnumerator DeactivateObject(GameObject _object)
        {

            yield return new WaitForSeconds(waitingTime);

            bool activeness = false;
            _object.SetActive(activeness);

            if (destroyObjectAfterDeactivateIt)
            {
                Destroy(_object);
            }

        }

    }

}
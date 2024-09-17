using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Anim
{
    public class AnimatorBoolSwapper : MonoBehaviour
    {
        public AnimatorInvoker onTrue;
        public AnimatorInvoker onFalse;
        public Animator animator;
        public AnimatorAction boolValue;

        public void Swap()
        {
            bool b = animator.GetBool(boolValue.Value.Parameter.Name);
            if (b)
            {
                onFalse.InvokeDefault();
            }
            else
            {
                onTrue.InvokeDefault();
            }
        }

    }
}

﻿#region Mr. Advice
// Mr. Advice
// A simple post build weaving package
// https://github.com/ArxOne/MrAdvice
// Released under MIT license http://opensource.org/licenses/mit-license.php
#endregion

namespace ArxOne.MrAdvice.Advice
{
    using System.Reflection;

    /// <summary>
    /// Special terminal advice, which calls the final method
    /// </summary>
    internal class InnerMethodContext : AdviceContext
    {
        private readonly MethodInfo _innerMethod;

        public InnerMethodContext(AdviceValues adviceValues,  MethodInfo innerMethod)
            : base(adviceValues, null)
        {
            _innerMethod = innerMethod;
        }

        /// <summary>
        /// Invokes the current aspect (related to this instance).
        /// </summary>
        internal override void Invoke()
        {
            AdviceValues.ReturnValue = _innerMethod.Invoke(AdviceValues.Target, AdviceValues.Parameters);
        }
    }
}
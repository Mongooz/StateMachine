using System;
using System.Collections.Generic;
using System.Text;

namespace StateMachine.Library
{
    public class AllowedState<T>
    {
        private T value;
        public bool AllowAny { get; set; }

        public AllowedState(T value)
        {
            this.value = value;
        }
        
        public static AllowedState<T> Any()
        {
            return new AllowedState<T>(default) { AllowAny = true };
        }

        public static implicit operator T(AllowedState<T> state) => state.value;
        public static implicit operator AllowedState<T>(T state) => new AllowedState<T>(state);

        public override bool Equals(object obj)
        {
            return AllowAny || value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(value, AllowAny);
        }
    }
}

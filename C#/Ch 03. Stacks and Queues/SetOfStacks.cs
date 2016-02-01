using System;
using System.Collections.Generic;

namespace Ch_03.Stacks_and_Queues
{
    public class SetOfStacks<T> : Stack<T>
    {
        private readonly int _maxStackCapacity;
        private readonly int _maxStacks;
        private readonly Stack<Stack<T>> _stacks;

        public SetOfStacks(int maxStackCapacity, int maxStacks)
        {
            _maxStackCapacity = maxStackCapacity;
            _maxStacks = maxStacks;
            _stacks = new Stack<Stack<T>>(_maxStacks);
        }

        public new bool IsEmpty()
        {
            return _stacks.IsEmpty();
        }

        private void AddStackWithItem(T item)
        {
            Stack<T> newStack = new Stack<T>(_maxStackCapacity);
            newStack.Push(item);
            _stacks.Push(newStack);
        }
        public new void Push(T item)
        {
            if (_stacks.IsEmpty())
            {
                AddStackWithItem(item);
                return;
            }
            // assert _stacks.IsNotEmpty();

            Stack<T> stack = PeekStack();
            if (stack.Count == _maxStackCapacity)
            {
                if (_stacks.Count == _maxStacks)
                    throw new InvalidOperationException("Maximum number of stacks exceeded. The number: " + _maxStacks);
                AddStackWithItem(item);
                return;
            }
            // assert stack.IsNotEmpty();
            // assert stack < _maxStackCapacity
            stack.Push(item);
        }

        public new T Pop()
        {
            Stack<T> stack = PeekStack();
            T item = stack.Pop();
            if (stack.IsEmpty())
                _stacks.Pop();
            return item;
        }

        public new T Peek()
        {
            return PeekStack().Peek();
        }

        private Stack<T> PeekStack()
        {
            if (_stacks.IsEmpty())
                throw new InvalidOperationException();
            Stack<T> stack = _stacks.Peek();
            if (stack.IsEmpty())
                throw new InvalidStateException("Stack should never be empty!");

            // assert stack.IsNotEmpty();
            return stack;
        }
    }
}
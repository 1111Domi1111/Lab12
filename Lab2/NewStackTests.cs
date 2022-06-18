using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Lab1.Stack;

namespace ConsoleApp34.Lab2
{
    [TestFixture]
    public class NewStackTests
    {
        [Test]
        public void Init_DifferentTypes_NoException()
        {
            var stack = new NewStack<int>();
            var stack2 = new NewStack<string>();
            var stack3 = new NewStack<bool>();
            var stack4 = new NewStack<object>();
            var stack5 = new NewStack<NewStack<object>>();

            Assert.Pass();
        }

        #region Count tests
        [Test]
        public void Count_EmptyStack_Zero()
        {
            var stack = new NewStack<int>();

            Assert.AreEqual(0, stack.Count);
        }

        [Test]
        public void Count_OneItem_One()
        {
            var stack = new NewStack<int>();
            stack.Push(1);

            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void Count_PushThreePopOne_Two()
        {
            var stack = new NewStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();

            Assert.AreEqual(2, stack.Count);
        }
        #endregion

        #region Push tests
        [Test]
        public void Push_MuslitpleItmes_NoException()
        {
            var stack = new NewStack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            Assert.Pass();
        }

        [Test]
        public void Push_WrongType_Exception()
        {
            Assert.Throws<Microsoft.CSharp.RuntimeBinder.RuntimeBinderException>(() =>
            {
                var stack = new NewStack<int>();
                dynamic data = "string";
                stack.Push(data);
            });
        }

        [Test]
        public void Push_MultipleItems_RightOrder()
        {
            var stack = new NewStack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            var current = stack.Count - 1;

            foreach (int num in stack)
            {
                Assert.AreEqual(num, current--);
            }
        }

        [Test]
        public void Push_NullItem_Exception()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var stack = new NewStack<object>();
                stack.Push(null!);
            });
        }


        #endregion

        #region Pop tests
        [Test]
        public void Pop_EmptyStack_Exception()
        {
            var stack = new NewStack<int>();
            Assert.Throws<InvalidOperationException>(() =>
            {
                stack.Pop();
            });
        }

        [Test]
        public void Pop_MultipleItems_RightOrder()
        {
            var stack = new NewStack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            for (int i = 9; i >= 0; i--)
            {
                Assert.AreEqual(i, stack.Pop());
            }
        }

        #endregion

        #region Peek test
        [Test]
        public void Peek_EmptyStack_Exception()
        {
            var stack = new NewStack<int>();
            Assert.Throws<InvalidOperationException>(() =>
            {
                stack.Peek();
            });
        }

        [Test]
        public void Peek_MultipleTimes_NoChange()
        {
            var stack = new NewStack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            for (int i = 9; i >= 0; i--)
            {
                Assert.AreEqual(9, stack.Peek());
            }
        }

        [Test]
        public void Peek_PopOnce_Change()
        {
            var stack = new NewStack<int>();

            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());

            stack.Pop();
            Assert.AreEqual(1, stack.Peek());
        }
        #endregion

        #region Contains test
        [Test]
        public void Contains_EmptyStack_False()
        {
            var stack = new NewStack<int>();
            Assert.IsFalse(stack.Contains(1));
        }

        [Test]
        public void Contains_MultipleItems_True()
        {
            var stack = new NewStack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            Assert.IsTrue(stack.Contains(9));
            Assert.IsTrue(stack.Contains(3));
        }

        [Test]
        public void Contains_MultipleItems_False()
        {
            var stack = new NewStack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            Assert.IsFalse(stack.Contains(11));
        }
        #endregion

        #region Clear tests
        [Test]
        public void Clear_EmptyStack_NoException()
        {
            var stack = new NewStack<int>();
            stack.Clear();
            Assert.Pass();
        }

        [Test]
        public void Clear_MultipleItems_NoException()
        {
            var stack = new NewStack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            stack.Clear();
            Assert.Pass();
        }

        [Test]
        public void Clear_Event_SuccessfulCall()
        {
            var stack = new NewStack<int>();
            bool called = false;
            stack.OnClear += () => { called = true; };
            stack.Clear();
            Assert.IsTrue(called);
        }
        #endregion
    }
}
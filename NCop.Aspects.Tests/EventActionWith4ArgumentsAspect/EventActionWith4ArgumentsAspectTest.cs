﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.EventActionWith4ArgumentsAspect.Subjects;
using NCop.Aspects.Tests.Extensions;
using NCop.Core.Extensions;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class EventActionWith4ArgumentsAspectTest : AbstractAspectTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and EventActionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void EventActionWith4Arguments_AnnotatedWithOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var firstArg1List = new List<AspectJoinPoints>();
            var firstArg2List = new List<AspectJoinPoints>();
            var firstArg3List = new List<AspectJoinPoints>();
            var firstArg4List = new List<AspectJoinPoints>();
            var secondArg1List = new List<AspectJoinPoints>();
            var secondArg2List = new List<AspectJoinPoints>();
            var secondArg3List = new List<AspectJoinPoints>();
            var secondArg4List = new List<AspectJoinPoints>();
            var instance = container.Resolve<IEventActionWith4ArgumentsComposite>();
            var joinPoints = new EventInterceptionAspectOrderedJoinPoints();
            Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> action = (l1, l2, l3, l4) => instance.Values.Append(AspectJoinPoints.Intercepted);

            instance.InterceptionAspect += action;
            instance.RaiseInterceptionAspect(firstArg1List, firstArg2List, firstArg3List, firstArg4List);
            instance.InterceptionAspect -= action;
            instance.RaiseInterceptionAspect(secondArg1List, secondArg2List, secondArg3List, secondArg4List);

            CollectionAssertExt.AreAllEqual(new EventInterceptionInvokeAspectOrderedJoinPoints(), firstArg1List, firstArg2List, firstArg3List, firstArg4List);
            CollectionAssertExt.AreAllEqual(AspectOrderedJoinPoints.Empty, secondArg1List, secondArg2List, secondArg3List, secondArg4List);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
        }

        [TestMethod]
        public void EventActionWith4Arguments_AnnotatedWithMultipleOnEventInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var firstArg1List = new List<AspectJoinPoints>();
            var firstArg2List = new List<AspectJoinPoints>();
            var firstArg3List = new List<AspectJoinPoints>();
            var firstArg4List = new List<AspectJoinPoints>();
            var secondArg1List = new List<AspectJoinPoints>();
            var secondArg2List = new List<AspectJoinPoints>();
            var secondArg3List = new List<AspectJoinPoints>();
            var secondArg4List = new List<AspectJoinPoints>();
            var instance = container.Resolve<IEventActionWith4ArgumentsComposite>();
            var joinPoints = new MultipleEventInterceptionAspectOrderedJoinPoints();
            Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> action = (l1, l2, l3, l4) => instance.Values.Append(AspectJoinPoints.Intercepted);

            instance.MultipleInterceptionAspects += action;
            instance.RaiseMultipleInterceptionAspect(firstArg1List, firstArg2List, firstArg3List, firstArg4List);
            instance.MultipleInterceptionAspects -= action;
            instance.RaiseMultipleInterceptionAspect(secondArg1List, secondArg2List, secondArg3List, secondArg4List);

            CollectionAssertExt.AreAllEqual(new EventMultipleInterceptionInvokeAspectOrderedJoinPoints(), firstArg1List, firstArg2List, firstArg3List, firstArg4List);
            CollectionAssertExt.AreAllEqual(AspectOrderedJoinPoints.Empty, secondArg1List, secondArg2List, secondArg3List, secondArg4List);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
        }

        [TestMethod]
        public void EventActionWith4Arguments_AnnotatedWithMultipleOnEventInterceptionAspectWhichCallsInvokeHanlder_IgnoresAllFollowingAspectsAndReturnsTheCorrectValue() {
            var firstArg1List = new List<AspectJoinPoints>();
            var firstArg2List = new List<AspectJoinPoints>();
            var firstArg3List = new List<AspectJoinPoints>();
            var firstArg4List = new List<AspectJoinPoints>();
            var secondArg1List = new List<AspectJoinPoints>();
            var secondArg2List = new List<AspectJoinPoints>();
            var secondArg3List = new List<AspectJoinPoints>();
            var secondArg4List = new List<AspectJoinPoints>();
            var instance = container.Resolve<IEventActionWith4ArgumentsComposite>();
            var joinPoints = new MultipleIgnoredEventInterceptionAspectOrderedJoinPoints();
            Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> action = (l1, l2, l3, l4) => instance.Values.Append(AspectJoinPoints.Intercepted);

            instance.MultipleIgnoredInterceptionAspects += action;
            instance.RaiseMultipleIgnoredInterceptionAspects(firstArg1List, firstArg2List, firstArg3List, firstArg4List);
            instance.MultipleIgnoredInterceptionAspects -= action;
            instance.RaiseMultipleIgnoredInterceptionAspects(secondArg1List, secondArg2List, secondArg3List, secondArg4List);

            CollectionAssertExt.AreAllEqual(new EventInterceptionInvokeAspectOrderedJoinPoints(), firstArg1List, firstArg2List, firstArg3List, firstArg4List);
            CollectionAssertExt.AreAllEqual(AspectOrderedJoinPoints.Empty, secondArg1List, secondArg2List, secondArg3List, secondArg4List);
            CollectionAssert.AreEqual(instance.Values, joinPoints);
        }
    }
}
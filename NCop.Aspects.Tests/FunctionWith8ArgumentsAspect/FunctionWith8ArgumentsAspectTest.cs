﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.FunctionWith8ArgumentsAspect.Subjects;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class FunctionWith8ArgumentsAspectTest : AbstractAspectTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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
        public void FunctionWith8Arguments_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var joinPoints = new OnMethodBoundaryAspectOrderedJoinPoints();
            var result = instance.OnMethodBoundaryAspect(first, second, third, fourth, fifth, sixth, seventh, eighth);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eighth, joinPoints);
            CollectionAssert.DoesNotContain(first, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(second, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(third, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fourth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fifth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(sixth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(seventh, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(eighth, AspectJoinPoints.OnException);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith8Arguments_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var joinPoints = new InterceptionAspectOrderedJoinPoints();
            var result = instance.InterceptionAspect(first, second, third, fourth, fifth, sixth, seventh, eighth);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eighth, joinPoints);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith8Arguments_AnnotatedWithMultipleInterceptionAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var joinPoints = new MultipleInterceptionAspectOrderedJoinPoints();
            var result = instance.MultipleInterceptionAspects(first, second, third, fourth, fifth, sixth, seventh, eighth);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eighth, joinPoints);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith8Arguments_AnnotatedWithMultipleOnMethodBoundaryAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var joinPoints = new MultipleOnMethodBoundaryAspectOrderedJoinPoints();
            var result = instance.MultipleOnMethodBoundaryAspects(first, second, third, fourth, fifth, sixth, seventh, eighth);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eighth, joinPoints);
            CollectionAssert.DoesNotContain(first, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(second, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(third, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fourth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fifth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(sixth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(seventh, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(eighth, AspectJoinPoints.OnException);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith8Arguments_AnnotatedWithAllAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithInterceptionAspect();
            var result = instance.AllAspectsStartingWithInterception(first, second, third, fourth, fifth, sixth, seventh, eighth);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eighth, joinPoints);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith8Arguments_AnnotatedWithAllAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();
            var result = instance.AllAspectsStartingWithOnMethodBoundary(first, second, third, fourth, fifth, sixth, seventh, eighth);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eighth, joinPoints);
            CollectionAssert.DoesNotContain(first, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(second, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(third, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fourth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fifth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(sixth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(seventh, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(eighth, AspectJoinPoints.OnException);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith8Arguments_AnnotatedWithAlternateAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect();
            var result = instance.AlternatelAspectsStartingWithInterception(first, second, third, fourth, fifth, sixth, seventh, eighth);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eighth, joinPoints);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith8Arguments_AnnotatedWithAlternateAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();
            var result = instance.AlternateAspectsStartingWithOnMethodBoundary(first, second, third, fourth, fifth, sixth, seventh, eighth);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eighth, joinPoints);
            CollectionAssert.DoesNotContain(first, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(second, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(third, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fourth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(fifth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(sixth, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(seventh, AspectJoinPoints.OnException);
            CollectionAssert.DoesNotContain(eighth, AspectJoinPoints.OnException);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FunctionWith8Arguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var joinPoints = new MultipleOnMethodBoundaryAspectOrderedJoinPoints();
            
            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth, sixth, seventh, eighth);
        }

        [TestMethod]
        public void FunctionWith8Arguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitsTheOnSuccessAdvice() {
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var joinPoints = new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints();
            var result = instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(first, second, third, fourth, fifth, sixth, seventh, eighth);

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eighth, joinPoints);
            Assert.AreEqual(result, joinPoints.ToString());
        }

        [TestMethod]
        public void FunctionWith8Arguments_AnnotatedWithATryFinallyOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocation_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            string result = null;
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var joinPoints = new TryFinallyWithExceptionOnMethodBoundaryAspectOrderedJoinPoints();

            try {
                result = instance.TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth, sixth, seventh, eighth);
            }
            catch (Exception) {
                CollectionAssert.AreEqual(first, joinPoints);
                CollectionAssert.AreEqual(second, joinPoints);
                CollectionAssert.AreEqual(third, joinPoints);
                CollectionAssert.AreEqual(fourth, joinPoints);
                CollectionAssert.AreEqual(fifth, joinPoints);
                CollectionAssert.AreEqual(sixth, joinPoints);
                CollectionAssert.AreEqual(seventh, joinPoints);
                CollectionAssert.AreEqual(eighth, joinPoints);
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void FunctionWith8Arguments_OnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithoutTryFinally_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            string result = null;
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var joinPoints = new OnMethodBoundaryAspectWithExceptionAndWithoutTryFinallyOrderedJoinPoints();

            try {
                result = instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(first, second, third, fourth, fifth, sixth, seventh, eighth);
            }
            catch (Exception) {
                CollectionAssert.AreEqual(first, joinPoints);
                CollectionAssert.AreEqual(second, joinPoints);
                CollectionAssert.AreEqual(third, joinPoints);
                CollectionAssert.AreEqual(fourth, joinPoints);
                CollectionAssert.AreEqual(fifth, joinPoints);
                CollectionAssert.AreEqual(sixth, joinPoints);
                CollectionAssert.AreEqual(seventh, joinPoints);
                CollectionAssert.AreEqual(eighth, joinPoints);
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void FunctionWith8Arguments_OnMethodBoundaryAspectWithOnlyOnEntryAdvice_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var result = instance.OnMethodBoundaryAspectWithOnlyOnEntryAdvide(first, second, third, fourth, fifth, sixth, seventh, eighth);
            var joinPoints = new OnMethodBoundaryAspectWithOnlyOnEntryAdviceOrderedJoinPoints();

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eighth, joinPoints);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith8Arguments_AnnotatedWithAllAspectsStartingFromInterceptionAspectThatCallsTheInvokeMethodOfTheArgs_ReturnsTheInMethodAdviceAndIgnoresAllOtherAspects() {
            var instance = container.Resolve<IFunctionWith8ArgumentsComposite>();
            var first = new List<AspectJoinPoints>();
            var second = new List<AspectJoinPoints>();
            var third = new List<AspectJoinPoints>();
            var fourth = new List<AspectJoinPoints>();
            var fifth = new List<AspectJoinPoints>();
            var sixth = new List<AspectJoinPoints>();
            var seventh = new List<AspectJoinPoints>();
            var eighth = new List<AspectJoinPoints>();
            var result = instance.InterceptionAspectUsingInvoke(first, second, third, fourth, fifth, sixth, seventh, eighth);
            var joinPoints = new InterceptionAspectUsingInvokeOrderedJoinPoints();

            CollectionAssert.AreEqual(first, joinPoints);
            CollectionAssert.AreEqual(second, joinPoints);
            CollectionAssert.AreEqual(third, joinPoints);
            CollectionAssert.AreEqual(fourth, joinPoints);
            CollectionAssert.AreEqual(fifth, joinPoints);
            CollectionAssert.AreEqual(sixth, joinPoints);
            CollectionAssert.AreEqual(seventh, joinPoints);
            CollectionAssert.AreEqual(eighth, joinPoints);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }
    }
}
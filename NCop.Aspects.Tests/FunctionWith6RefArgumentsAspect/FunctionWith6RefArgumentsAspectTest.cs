﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCop.Aspects.Tests.FunctionWith6RefArgumentsAspect.Subjects;
using NCop.Composite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Tests
{
    [TestClass]
    public class FunctionWith6RefArgumentsAspectTest : AbstractAspectTest
    {
        private int i = 0;
        private int j = 0;
        private int k = 0;
        private int l = 0;
        private int m = 0;
        private int n = 0;
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

        [TestInitialize()]
        public void InitializeAllprivateVariablesForEachTest() {
            n = m = l = k = j = i = 0;
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.OnMethodBoundaryAspect(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new OnMethodBoundaryAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(k, calculated);
            Assert.AreEqual(l, calculated);
            Assert.AreEqual(m, calculated);
            Assert.AreEqual(n, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.InterceptionAspect(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new InterceptionAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(k, calculated);
            Assert.AreEqual(l, calculated);
            Assert.AreEqual(m, calculated);
            Assert.AreEqual(n, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithMultipleInterceptionAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.MultipleInterceptionAspects(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new MultipleInterceptionAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(k, calculated);
            Assert.AreEqual(l, calculated);
            Assert.AreEqual(m, calculated);
            Assert.AreEqual(n, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithMultipleOnMethodBoundaryAspects_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.MultipleOnMethodBoundaryAspects(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new MultipleOnMethodBoundaryAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(k, calculated);
            Assert.AreEqual(l, calculated);
            Assert.AreEqual(m, calculated);
            Assert.AreEqual(n, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithAllAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.AllAspectsStartingWithInterception(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithInterceptionAspect();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(k, calculated);
            Assert.AreEqual(l, calculated);
            Assert.AreEqual(m, calculated);
            Assert.AreEqual(n, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithAllAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.AllAspectsStartingWithOnMethodBoundary(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new AllAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(k, calculated);
            Assert.AreEqual(l, calculated);
            Assert.AreEqual(m, calculated);
            Assert.AreEqual(n, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithAlternateAspectsStartingWithInterceptionAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.AlternatelAspectsStartingWithInterception(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithInterceptionAspect();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(k, calculated);
            Assert.AreEqual(l, calculated);
            Assert.AreEqual(m, calculated);
            Assert.AreEqual(n, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithAlternateAspectsStartingWithOnMethodBoundaryAspect_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.AlternateAspectsStartingWithOnMethodBoundary(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new AlternateAspectOrderedJoinPointsStartingWithOnMethodBoundaryAspect();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(k, calculated);
            Assert.AreEqual(l, calculated);
            Assert.AreEqual(m, calculated);
            Assert.AreEqual(n, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FunctionWith6RefArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithDefaultFlowBehaviour_ThrowsException() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();

            instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithContinueFlowBehaviour_OmitsTheOnSuccessAdvice() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new WithExceptionFlowBehaviourContinueOnMethodBoundaryAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(k, calculated);
            Assert.AreEqual(l, calculated);
            Assert.AreEqual(m, calculated);
            Assert.AreEqual(n, calculated);
            Assert.AreEqual(result, joinPoints.ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithATryFinallyOnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocation_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            string result = null;
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var joinPoints = new TryFinallyWithExceptionOnMethodBoundaryAspectOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            try {
                result = instance.TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n);
            }
            catch (Exception) {
                Assert.AreEqual(i, calculated);
                Assert.AreEqual(j, calculated);
                Assert.AreEqual(k, calculated);
                Assert.AreEqual(l, calculated);
                Assert.AreEqual(m, calculated);
                Assert.AreEqual(n, calculated);
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void FunctionWith6RefArguments_OnMethodBoundaryAspectThatRaisesAnExceptionInMethodInvocationWithoutTryFinally_OmitsTheOnSuccessAdviceAndReturnsTheCorrectSequenceOfAdvices() {
            string result = null;
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var joinPoints = new OnMethodBoundaryAspectWithExceptionAndWithoutTryFinallyOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            try {
                result = instance.OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref i, ref j, ref k, ref l, ref m, ref n);
            }
            catch (Exception) {
                Assert.AreEqual(i, calculated);
                Assert.AreEqual(j, calculated);
                Assert.AreEqual(k, calculated);
                Assert.AreEqual(l, calculated);
                Assert.AreEqual(m, calculated);
                Assert.AreEqual(n, calculated);
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void FunctionWith6RefArguments_OnMethodBoundaryAspectWithOnlyOnEntryAdvice_ReturnsTheCorrectSequenceOfAdvices() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new OnMethodBoundaryAspectWithOnlyOnEntryAdviceOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(k, calculated);
            Assert.AreEqual(l, calculated);
            Assert.AreEqual(m, calculated);
            Assert.AreEqual(n, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }

        [TestMethod]
        public void FunctionWith6RefArguments_AnnotatedWithAllAspectsStartingFromInterceptionAspectThatCallsTheInvokeMethodOfTheArgs_ReturnsTheInMethodAdviceAndIgnoresAllOtherAspects() {
            var instance = container.Resolve<IFunctionWith6RefArgumentsComposite>();
            var result = instance.InterceptionAspectUsingInvoke(ref i, ref j, ref k, ref l, ref m, ref n);
            var joinPoints = new InterceptionAspectUsingInvokeOrderedJoinPoints();
            var calculated = joinPoints.Calculate();

            Assert.AreEqual(i, calculated);
            Assert.AreEqual(j, calculated);
            Assert.AreEqual(k, calculated);
            Assert.AreEqual(l, calculated);
            Assert.AreEqual(m, calculated);
            Assert.AreEqual(n, calculated);
            Assert.AreEqual(result, new ReturnValueAspectOrderedJoinPoints(joinPoints).ToString());
        }
    }
}
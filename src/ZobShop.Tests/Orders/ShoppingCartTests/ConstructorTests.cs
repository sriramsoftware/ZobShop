﻿using System;
using Moq;
using NUnit.Framework;
using ZobShop.Factories;
using ZobShop.Orders;
using ZobShop.Orders.Contracts;
using ZobShop.Orders.Factories;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Orders.ShoppingCartTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            var mockedService = new Mock<IProductService>();
            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            Assert.Throws<ArgumentNullException>(() =>
            new ShoppingCart(null, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object));
        }

        [Test]
        public void TestConstructor_PassServiceNull_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            Assert.Throws<ArgumentNullException>(() =>
            new ShoppingCart(mockedFactory.Object, null, mockedOrderService.Object, mockedOrderFactory.Object));
        }

        [Test]
        public void TestConstructor_PassOrderServiceNull_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedService = new Mock<IProductService>();

            Assert.Throws<ArgumentNullException>(() =>
            new ShoppingCart(mockedFactory.Object, mockedService.Object, null, mockedOrderFactory.Object));
        }
        
        [Test]
        public void TestConstructor_PassOrderFactoryNull_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderService = new Mock<IOrderService>();
            var mockedService = new Mock<IProductService>();

            Assert.Throws<ArgumentNullException>(() =>
            new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object,null));
        }

        [Test]
        public void TestConstructor_PassCorrectly_ShouldNotThrow()
        {
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object);
        }

        [Test]
        public void TestConstructor_PassCorrectly_ShouldInitialiseCartLinesCorrectly()
        {
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object);

            Assert.IsNotNull(cart.CartLines);
        }

        [Test]
        public void TestConstructor_ShouldBeInstanceOfIShoppingCart()
        {
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object);

            Assert.IsInstanceOf<IShoppingCart>(cart);
        }
    }
}

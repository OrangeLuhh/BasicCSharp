using System;
using Services;
using Moq;
using api.Controllers;
using System.Collections.Generic;
using Xunit;

namespace TestDoubleMock
{
    public class CartControllerTest
    {
        private CartController controller;
        private Mock<IPaymentService> paymentServiceMock;
        private Mock<ICartService> cartServiceMock;

        private Mock<IShipmentService> shipmentServiceMock;
        private Mock<ICard> cardMock;
        private Mock<IAddressInfo> addressInfoMock;
        private List<CartItem> items;

        public CartControllerTest()
        {
            cartServiceMock = new Mock<ICartService>();
            paymentServiceMock = new Mock<IPaymentService>();
            shipmentServiceMock = new Mock<IShipmentService>();

            // arrange
            cardMock = new Mock<ICard>();
            addressInfoMock = new Mock<IAddressInfo>();

            // 
            var cartItemMock = new Mock<CartItem>();
            cartItemMock.Setup(item => item.Price).Returns(10);

            items = new List<CartItem>()
            {
              cartItemMock.Object
            };

            cartServiceMock.Setup(c => c.Items()).Returns(items);

            controller = new CartController(cartServiceMock.Object, paymentServiceMock.Object, shipmentServiceMock.Object);
        }


        [Fact]
        public void ShouldReturnCharged()
        {
            paymentServiceMock.Setup(p => p.Charge(It.IsAny<double>(), cardMock.Object)).Returns(true);

            // act
            var result = controller.CheckOut(cardMock.Object, addressInfoMock.Object);

            // assert
            shipmentServiceMock.Verify(s => s.Ship(addressInfoMock.Object, items), Times.Once());

            Assert.Equal("charged", result);
        }

        [Fact]
        public void ShouldReturnNotCharged()
        {
            paymentServiceMock.Setup(p => p.Charge(It.IsAny<double>(), cardMock.Object)).Returns(false);

            // act
            var result = controller.CheckOut(cardMock.Object, addressInfoMock.Object);

            // assert
            shipmentServiceMock.Verify(s => s.Ship(addressInfoMock.Object, items), Times.Never());
            Assert.Equal("not charged", result);
        }
    }
}

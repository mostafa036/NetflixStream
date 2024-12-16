using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NetflixStream.Application.Interfaces;
using NetflixStream.Domain.UserIdentity;
using NetflixStream.Infrastructure.Services;
using NetflixStream.Persistence.Data.Contexts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.FunctionalTests.Payment
{
    [TestFixture]
    internal class PaymentServiceTests
    {
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<UserManagementContext> _mockContext;
        private PaymentService _paymentService;

        [SetUp]
        public void Setup()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockContext = new Mock<UserManagementContext>(new DbContextOptions<UserManagementContext>()); // Setup options as needed
            _paymentService = new PaymentService(_mockConfiguration.Object, _mockContext.Object);
        }
        [Test]
        public async Task CreatePaymentIntentAsync_ValidPaymentMethod_ReturnsPaymentIntent()
        {
            var email = "test@example.com";
            var amount = 100m;
            var currency = "usd";
            var paymentMethodId = 1;

            var paymentMethod = new PaymentMethod
            {
                PaymentMethodId = paymentMethodId,
                IsActive = true,
                ProcessingFee = 2 // 2%
            };

            //_mockContext.Setup(c => c.PaymentMethods.FirstOrDefaultAsync(It.IsAny<Expression<Func<PaymentMethod, bool>>>()))
            //    .ReturnsAsync(paymentMethod);

            _mockConfiguration.Setup(c => c["StripeSettings:SecretKey"]).Returns("your_secret_key");

            var result = await _paymentService.CreatePaymentIntentAsync(email, amount, currency, paymentMethodId);

            Assert.IsNotNull(result);
            Assert.AreEqual((long)((amount + (amount * 0.02m)) * 100), result.Amount); // Validate amount calculation
        }


    }
}

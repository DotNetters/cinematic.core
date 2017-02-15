﻿using NUnit.Framework;
using System;
using FluentAssertions;

namespace Cinematic.Domain.Tests
{
    [TestFixture]
    [Category("Cinematic.PriceManager")]
    public class PriceManagerTests
    {
        #region Ctor tests

        [Test]
        public void PriceManager_Ctor_Right()
        {
            //Arrange
            //Act
            var target = new PriceManager();

            //Assert
            target.Should().NotBeNull();
        }

        #endregion

        #region GetTicketPrice tests

        [Test]
        public void PriceManager_GetTicketPrice()
        {
            //Arrange
            var target = new PriceManager();

            var session = new Session() { Id = 0, Status = SessionStatus.Open, TimeAndDate = DateTime.Now };

            //Act
            var result = target.GetTicketPrice(session, 1, 1);

            //Assert
            result.Should().Be(5.00);

        }

        #endregion
    }
}

using BrouwerService.Controllers;
using BrouwerService.Models;
using BrouwerService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BrouwerServiceUnitTests {
    [TestClass]
    public class BrouwerControllerTest {
        private BrouwerController controller;
        private Mock<IBrouwerRepository> mock;
        private Brouwer brouwer7;
        private Brouwer brouwer9;
    }
}

using FizzWare.NBuilder;
using HangfireExample.Application.Implementation;
using HangfireExample.Application.Services.Interfaces;
using HangfireExample.Domain.Entities;
using HangfireExample.Domain.Interfaces.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Moq;
using System.Runtime;
using Xunit;

namespace HangfireExample.Test.UnitTests
{
    public class FileServiceTest
    {
        private readonly IFileService fileService;
        private readonly Mock<ILocationRepository>  locationRepository;
        private readonly Mock<ISettings> settings;
        private readonly Mock<ILogger> logger;
        public FileServiceTest()
        {
            settings = new Mock<ISettings>();
            locationRepository = new Mock<ILocationRepository>();
            this.fileService = new FileService(settings.Object, locationRepository.Object);
            logger = new Mock<ILogger>();
        }

        [Fact]
        public async Task ReadSaveFile_Sucess()
        {
            var locations = Builder<Location>.CreateListOfSize(3).Build(); 
            
            locationRepository.Setup(x => x.AddAsync(locations, logger.Object)).ReturnsAsync(true);
            settings.SetupGet(x => x.FileName).Returns("location.txt");

            var result = await fileService.ReadAndSave(logger.Object);
         
            Assert.True(result > 0);
        }

        [Fact]
        public async Task ReadSaveFile_Failed()
        {
            var locations = Builder<Location>.CreateListOfSize(3).Build();

            locationRepository.Setup(x => x.AddAsync(locations, logger.Object)).ReturnsAsync(true);
            settings.SetupGet(x => x.FileName).Returns("");

            var result = await fileService.ReadAndSave(logger.Object);

            Assert.True(result == 0);
        }
    }
}

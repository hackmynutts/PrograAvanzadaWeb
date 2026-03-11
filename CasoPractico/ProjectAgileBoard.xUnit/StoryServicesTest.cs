using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ProjectAgileBoard.API.DTO;
using ProjectAgileBoard.API.Repository;
using ProjectAgileBoard.API.Services;

namespace ProjectAgileBoard.xUnit
{
    public class StoryServicesTest
    {
        //pruebas sobre creacion de story
        [Fact]
        public async Task CreateStory_ShouldReturnStoryDTO()
        {
            //preparar el entorno de prueba
            // Arrange
            var mockService = new Mock<IStoryServices>();

            mockService.Setup(s => s.CreateStoryAsync(It.IsAny<StoryDTO>())).Returns((Task<StoryDTO>)Task.CompletedTask);
            var mockEstimation = new Mock<EstimationClientApi>(new Mock<IHttpClientFactory>().Object);
            mockEstimation.Setup(e => e.GetEstimationAsync(It.IsAny<CancellationToken>())).ReturnsAsync(5);
            var service = new StoryServices(mockService.Object, mockEstimation.Object);
            var storyDto = new StoryDTO
            {
                Title = "Test Story",
                Description = "This is a test story",
                AssignedTo = "Tester"
            };
            //realizar la accion a probar
            // Act
            var result = await service.CreateStoryAsync(storyDto);
            //verificar los resultados
            // Assert
            Assert.NotNull(result);
            Assert.Equal(storyDto.Title, result.Title);
            Assert.Equal(storyDto.Description, result.Description);
            Assert.Equal(storyDto.AssignedTo, result.AssignedTo);
            Assert.Equal(storyDto.Estimacion, result.Estimacion);
            Assert.Equal("Backlog", result.Status);

            Mock.

        }
    }
}

using Moq;
using System.Threading.Tasks;
using Xunit;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LibraryManagementSystem.Repositories;



namespace LibraryManagementSystem.Tests
{
    public class AuthorServiceTests
    {
        private readonly AuthorService _authorService;
        private readonly Mock<IAuthorRepository> _mockAuthorRepository;

        public AuthorServiceTests()
        {
            _mockAuthorRepository = new Mock<IAuthorRepository>();
            _authorService = new AuthorService(_mockAuthorRepository.Object);
        }

        [Fact]
        public async Task AddAuthorAsync_ShouldCallAddAuthorAsyncOnRepository()
        {
            // Arrange
            var author = new Author
            {
                Id = 1,
                FirstName = "Markas",
                LastName = "Tvenas",
                BirthYear = 1880
            };

            // Act
            await _authorService.AddAuthorAsync(author);

            // Assert
            _mockAuthorRepository.Verify(repo => repo.AddAuthorAsync(author), Times.Once);
        }

        [Fact]
        public async Task GetAuthorByIdAsync_ShouldReturnAuthor_WhenAuthorExists()
        {
            // Arrange
            var author = new Author
            {
                Id = 1,
                FirstName = "Markas",
                LastName = "Tvenas",
                BirthYear = 1880
            };

            _mockAuthorRepository.Setup(repo => repo.GetAuthorByIdAsync(author.Id)).ReturnsAsync(author);

            // Act
            var result = await _authorService.GetAuthorByIdAsync(author.Id);

            // Assert
            Assert.Equal(author, result);
        }

        [Fact]
        public async Task GetAuthorByIdAsync_ShouldReturnNull_WhenAuthorDoesNotExist()
        {
            // Arrange
            _mockAuthorRepository.Setup(repo => repo.GetAuthorByIdAsync(It.IsAny<int>())).ReturnsAsync((Author)null);

            // Act
            var result = await _authorService.GetAuthorByIdAsync(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteAuthorAsync_ShouldCallDeleteAuthorAsyncOnRepository()
        {
            // Arrange
            var authorId = 1;

            // Act
            await _authorService.DeleteAuthorAsync(authorId);

            // Assert
            _mockAuthorRepository.Verify(repo => repo.DeleteAuthorAsync(authorId), Times.Once);
        }
    }
}


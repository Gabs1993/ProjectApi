using AutoMapper;
using BasicApi.Repositorios;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectApi.Data;
using ProjectApi.Data.DTOs.JogadorDTO;
using ProjectApi.Models;


namespace TestProjectApi.JogadorTests
{
    public class JogadorTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<Context> _contextMock;
        private readonly JogadorRepository _repository;

        public JogadorTests()
        {
            _mapperMock = new Mock<IMapper>();

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _contextMock = new Mock<Context>(options);
            _repository = new JogadorRepository(_contextMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void TestJogadorMenorQue16()
        {
            // Arrange
            var createJogadorDTO = new CreateJogadorDTO { Idade = 15 };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => _repository.CriarJogador(createJogadorDTO));
            Assert.Equal("Jogador não pode ser cadastrato, tem que ser maior de 16 anos!", exception.Message);
            _contextMock.Verify(c => c.Add(It.IsAny<CreateJogadorDTO>()), Times.Never);
            _contextMock.Verify(c => c.SaveChanges(), Times.Never);
        }

        [Fact]
        public void TestCriarJogador()
        {
            // Arrange
            var createJogadorDTO = new CreateJogadorDTO { Idade = 18 };
            var jogador = new Jogador("Gabriel Conceição dos Santos", "Atacante", 18);

            _mapperMock.Setup(m => m.Map<Jogador>(createJogadorDTO)).Returns(jogador);

            // Act
            var result = _repository.CriarJogador(createJogadorDTO);

            // Assert
            Assert.Equal(jogador, result);
            _contextMock.Verify(c => c.Add(It.IsAny<Jogador>()), Times.Once);
            _contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public void TestExcluirJogador()
        {
            // Arrange
            var jogadorId = Guid.NewGuid();
            var nome =  "Gabriel Conceição dos Santos";
            var posicao = "Atacante";
            var idade = 31;
            var jogador = new Jogador(nome, posicao, idade) { Id = jogadorId };
            var jogadores = new List<Jogador> { jogador }.AsQueryable();
            var mockSet = new Mock<DbSet<Jogador>>();

            mockSet.As<IQueryable<Jogador>>().Setup(m => m.Provider).Returns(jogadores.Provider);
            mockSet.As<IQueryable<Jogador>>().Setup(m => m.Expression).Returns(jogadores.Expression);
            mockSet.As<IQueryable<Jogador>>().Setup(m => m.ElementType).Returns(jogadores.ElementType);
            mockSet.As<IQueryable<Jogador>>().Setup(m => m.GetEnumerator()).Returns(jogadores.GetEnumerator());

            _contextMock.Setup(c => c.Jogadores).Returns(mockSet.Object);

            // Act
            _repository.ExcluirJogadorPorId(jogadorId);

            // Assert
            mockSet.Verify(m => m.Remove(It.Is<Jogador>(j => j.Id == jogadorId)), Times.Once);
            _contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}

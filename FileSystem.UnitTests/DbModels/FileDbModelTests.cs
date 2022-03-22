using FileSystem.EF.DbModels;
using NSubstitute;
using System;
using Xunit;

namespace FileSystem.UnitTests.DbModels
{
    public class FileDbModelTests
    {


        public FileDbModelTests()
        {

        }

        private FileDbModel CreateFileDbModel()
        {
            return new FileDbModel("File", new FolderDbModel("folder"));
        }

        [Fact]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var fileDbModel = this.CreateFileDbModel();

            // Act
            fileDbModel.Delete();

            // Assert
            Assert.True(fileDbModel.IsDeleted);
        }
    }
}

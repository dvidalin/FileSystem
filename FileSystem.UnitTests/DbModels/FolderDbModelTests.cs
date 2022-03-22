using FileSystem.EF.DbModels;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Linq;
using Xunit;

namespace FileSystem.UnitTests.DbModels
{
    public class FolderDbModelTests
    {


        public FolderDbModelTests()
        {

        }

        private FolderDbModel CreateFolderDbModel()
        {
            return new FolderDbModel("Test folder", HierarchyId.GetRoot());
        }

        [Fact]
        public void AddSubfolder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var folderDbModel = CreateFolderDbModel();
            string folderName = "New Folder";

            // Act
            var result = folderDbModel.AddSubfolder(
                folderName);

            // Assert
            Assert.Equal(1, folderDbModel.Subfolders.Count);
        }

        [Fact]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var root = CreateFolderDbModel();
            var sut = root.AddSubfolder("child");
            var sutSibling = root.AddSubfolder("child2");
            var sutChild = sut.AddSubfolder("granchild");
            var sutSiblingChild = sutSibling.AddSubfolder("granchild2");

            var rootFile = root.CreateFile("file");
            var sutChildFile = sutChild.CreateFile("file");
            var sutSiblingChildFile = sutSiblingChild.CreateFile("f3");

            // Act
            sut.Delete();

            // Assert

            Assert.False(root.IsDeleted);

            Assert.True(sut.IsDeleted);

            Assert.False(sutSibling.IsDeleted);

            Assert.True(sutChild.IsDeleted);

            Assert.False(sutSiblingChild.IsDeleted);

            Assert.False(rootFile.IsDeleted);
            Assert.True(sutChildFile.IsDeleted);
            Assert.False(sutSiblingChildFile.IsDeleted);


        }

        [Fact]
        public void CreateFile_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var folderDbModel = CreateFolderDbModel();
            string fileName = "newfile";

            // Act
            var result = folderDbModel.CreateFile(fileName);

            // Assert
            Assert.Equal(1, folderDbModel.Files.Count);
            Assert.False(result.IsDeleted);
            Assert.Equal(result, folderDbModel.Files.First());
        }

        [Fact]
        public void GetNewChildNode_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var root = CreateFolderDbModel();
            var sut = root.AddSubfolder("Novi");
            var sutChild = sut.AddSubfolder("Novi");
            var sutSibling = root.AddSubfolder("Novi");         

            // Act
            var result = sut.GetNewChildNode();

            // Assert
            Assert.True(result.IsDescendantOf(root.Node));
            Assert.True(result.IsDescendantOf(sut.Node));
            
            Assert.False(result.IsDescendantOf(sutChild.Node));
            Assert.False(result.IsDescendantOf(sutSibling.Node));
        }

        [Fact]
        public void IsRoot_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var root = CreateFolderDbModel();
            var child = root.AddSubfolder("321");
            var granChild = child.AddSubfolder("123");
            
            // Assert
            Assert.True(root.IsRoot());
            Assert.False(child.IsRoot());
            Assert.False(granChild.IsRoot());
        }
    }
}

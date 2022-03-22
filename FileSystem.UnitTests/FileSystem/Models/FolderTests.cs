using AutoFixture;
using FileSystem.Core.Exceptions;
using FileSystem.Core.FileSystem.Models;
using NSubstitute;
using System;
using Xunit;

namespace FileSystem.UnitTests.FileSystem.Models;

public class FolderTests 
{
    private readonly IFixture _fixture = new Fixture();

    public FolderTests()
    {
    }

    private static Folder CreateFolder() => new ("TestFolder");

    #region ADD_SUBFOLDER
    [Theory]
    [InlineData("MojNoviFolder")]
    [InlineData("Moj novi folder132")]
    [InlineData("Moj novi folder  ")]
    public void AddSubfolder_HappyPath(string folderName)
    { 
        Folder folder = CreateFolder();

        Folder newFolder = folder.AddSubfolder(folderName);

        Assert.Equal(1, folder.Subfolders.Count);
        Assert.Equal(folderName, newFolder.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("    ")]
    public void AddSubfolder_InputEmptyOrWhiteSpace_Should_Throw_ArgumentException(string folderName)
    {
        // Arrange
        Folder folder = CreateFolder();

        Assert.Throws<ArgumentException>(() => folder.AddSubfolder(folderName));
    }

    [Fact]
    public void AddSubfolder_InputNull_Should_Throw_ArgumentNullException()
    {
        // Arrange
        var folder = CreateFolder();

        string folderName = null;

        Assert.Throws<ArgumentNullException>(() => folder.AddSubfolder(folderName));
    }

    [Theory]
    [InlineData("Fo|der")]
    [InlineData("Fol:*\\fdsf")]
    [InlineData("Fol//der")]
    public void AddSubfolder_InputInvalidCharacter_Should_Throw_InvalidCharacterException(string folderName)
    {
        Folder folder = CreateFolder();

        Assert.Throws<InvalidCharacterException>(() => folder.AddSubfolder(folderName));
    }
    #endregion

    #region CREATE_FILE
    [Theory]
    [InlineData("MojNoviFile")]
    [InlineData("Moj file")]
    [InlineData("Moj novi folder  ")]
    public void CreateFile_HappyPath(string fileName)
    {
        var folder = CreateFolder();

        var newFile = folder.CreateFile(fileName);

        Assert.Equal(1, folder.Files.Count);
        Assert.Equal(fileName, newFile.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("    ")]

    public void CreateFile_InputEmptyOrWhiteSpace_Should_Throw_ArgumentException(string fileName)
    {
        // Arrange
        var folder = CreateFolder();

        Assert.Throws<ArgumentException>(() => folder.CreateFile(fileName));

    }


    [Theory]
    [InlineData("Folder\"")]
    [InlineData("Fol<ds")]
    public void CreateFile_InputInvalidCharacter_Should_Throw_InvalidCharacterException(string fileName)
    {
        // Arrange
        var folder = CreateFolder();

        Assert.Throws<InvalidCharacterException>(() => folder.CreateFile(fileName));

    }

    [Fact]
    public void CreateFile_InputNull_Should_Throw_ArgumentNullException()
    {
        // Arrange
        var folder = CreateFolder();

        string fileName = null;

        Assert.Throws<ArgumentNullException>(() => folder.CreateFile(fileName));

    }


    #endregion


    [Fact]
    public void DeleteFile_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var folder = CreateFolder();
        FileModel file = folder.CreateFile("file");

        // Act
        folder.DeleteFile(
            file);

        // Assert
        Assert.Equal(0, folder.Files.Count);
        Assert.False(folder.Files.Contains(file));
    }

}

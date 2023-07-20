using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Security.Authentication;
using Songbook.Infrastructure.Services.v1.Utils;
using Songbook.Domain.Exceptions.v1.Common;
using Songbook.Domain.Exceptions.v1.Messages;

namespace Songbook.Infratructure.Test;

public class SongUtilsServiceTests
{
    [Theory]
    [InlineData("(verse)[none]Questa[g] è una[a] prova;[a]Cosa ne [b][c][e] pensi(chours)[none]Molto [a]interessante", "(", ")", 2)]
    [InlineData("[none]Questa[g] è una[a] prova;[a]Cosa ne [b][c][e] pensi", ";", "", 2)]
    [InlineData("[none]Molto [a]interessante", ";", "", 1)]
    [InlineData("[none]Questa[g] è una[a] prova", "[", "]", 3)]
    [InlineData("[a]Cosa ne [b][c][e] pensi", "[", "]",4)]
    public void CreateSongParts_MustRun(string content, string splitter, string delimiter, int number)
    {
        var result = SongUtilsService.CreateSongParts(content, splitter, delimiter);
        Assert.True(result.ToList().Count == number);
    }

    [Theory]
    [InlineData("", "(", ")", SongReaderServiceErrorMessages.EMPTY_CONTENT)]
    public void CreateSongParts_MustThrow(string content, string splitter, string delimiter, string message)
    {
        var exception = Assert.Throws<GenericApiException>(() => SongUtilsService.CreateSongParts(content, splitter, delimiter));
        Assert.Equal(message, exception.Message);
    }
}

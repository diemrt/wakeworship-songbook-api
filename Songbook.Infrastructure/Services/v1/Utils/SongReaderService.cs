using System;
using Songbook.Domain.Exceptions.v1.Common;
using System.Net;
using Songbook.Domain.Exceptions.v1.Messages;
using Songbook.Domain.DTOs.v1.Songs;

namespace Songbook.Infrastructure.Services.v1.Utils
{
	public static class SongReaderService
	{
		public static string SerializeHeader(List<string> pairOfStrings)
		{
			if (pairOfStrings.Count > 2 || pairOfStrings.Count < 0)
                throw new GenericApiException($"{SongReaderServiceErrorMessages.FORMATTING_ERROR} {SongReaderServiceErrorMessages.SERIALIZATION_HERADER_ERROR}")
				{ Code = (int)HttpStatusCode.InternalServerError };

			return pairOfStrings.First();
        }

        public static IEnumerable<GenericStringItemDTO> CreateSongParts(string content, string splitter, string delimiter = "")
        {
            var result = new List<GenericStringItemDTO>();
            if (string.IsNullOrEmpty(content))
                throw new GenericApiException(SongReaderServiceErrorMessages.EMPTY_CONTENT) { Code = (int)HttpStatusCode.BadRequest };

            var parts = content.Split(splitter).ToList();
            if (parts.Count < 1)
                throw new GenericApiException(SongReaderServiceErrorMessages.INVALID_PARTS) { Code = (int)HttpStatusCode.BadRequest };

            foreach (var part in parts)
            {
                if (!string.IsNullOrEmpty(delimiter))
                    result.Add(CreateSongSubparts(part, delimiter));
            }

            return result;
        }

        public static GenericStringItemDTO CreateSongSubparts(string part, string delimiter)
        {
            var result = new GenericStringItemDTO();
            var subpart = part.Split(delimiter).ToList();

            if (subpart.Count < 1 || subpart.Count > 2)
                throw new GenericApiException(SongReaderServiceErrorMessages.INVALID_SUBPARTS) { Code = (int)HttpStatusCode.BadRequest };
            else if (subpart.Count == 2)
                result.AfterDelimiter = subpart[1];

            result.BeforeDelimiter = subpart[0];
            return result;
        }
    }
}


using System;
using Songbook.Domain.Exceptions.v1.Common;
using System.Net;
using Songbook.Domain.Exceptions.v1.Messages;

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
	}
}


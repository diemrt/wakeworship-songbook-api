using System;
namespace Songbook.Domain.Exceptions.v1.Messages
{
	public class SongReaderServiceErrorMessages
	{
		public const string FORMATTING_ERROR = "Il formato del testo non rispetta lo standard definito.";
        public const string SERIALIZATION_HERADER_ERROR = "La serializzazione dell'intestazione ha prodotto un risultato inatteso.";
    }
}


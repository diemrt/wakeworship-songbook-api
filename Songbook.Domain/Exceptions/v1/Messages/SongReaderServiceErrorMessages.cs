using System;
namespace Songbook.Domain.Exceptions.v1.Messages
{
	public class SongReaderServiceErrorMessages
	{
		public const string EMPTY_CONTENT = "Errore di contenuto, il contenuto del brano è vuoto.";
		public const string INVALID_PARTS = "Errore di formattazione del contenuto, controllare i caratteri di separazione.";
        public const string EMPTY_SUBCONTENT = "Errore di contenuto, parti mancanti nelle sezioni sottostanti.";
        public const string INVALID_SUBPARTS = "Errore di formattazione del contenuto, controllare i caratteri di delimitazione.";
        public const string FORMATTING_ERROR = "Il formato del testo non rispetta lo standard definito.";
        public const string SERIALIZATION_HERADER_ERROR = "La serializzazione dell'intestazione ha prodotto un risultato inatteso.";
    }
}


using System;
namespace Songbook.Domain.Exceptions.v1.Messages
{
	public class SongReaderServiceErrorMessages
	{
		public const string EMPTY_CONTENT = "Errore di contenuto, il contenuto del brano è vuoto.";
		public const string INVALID_PARTS = "Errore di formattazione del contenuto, controllare i caratteri di separazione.";
        public const string INVALID_SUBPARTS = "Errore di formattazione del contenuto, controllare i caratteri di delimitazione.";
    }
}


using System;

namespace EjemploReal.Api.Data
{
    public class Message
    {
        public int Id { get; set; }

        public DateTime DateUtc { get; set; }

        public string Text { get; set; }

        public string User { get; set; }
    }
}
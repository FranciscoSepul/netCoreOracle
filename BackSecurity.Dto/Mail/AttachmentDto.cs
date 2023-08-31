using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Mail
{
    public class AttachmentDto
    {
        public enum AttachmentType
        {
            Json,
            Text
        }

        public AttachmentDto(string fileName, object content)
        {
            Content = content;
            FileName = fileName;
            Type = AttachmentType.Text;
        }

        public object Content { get; set; }
        public string FileName { get; set; }
        public AttachmentType Type { get; set; }

        public async Task<MemoryStream> ContentToStreamAsync()
        {
            string text = Type switch
            {
                AttachmentType.Json => Newtonsoft.Json.JsonConvert.SerializeObject(Content),
                AttachmentType.Text => Content.ToString(),
                _ => throw new ArgumentOutOfRangeException("Type", "AttachmentType not allowed"),
            };
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream, Encoding.UTF8);
            await writer.WriteAsync(text);
            await writer.FlushAsync();
            stream.Position = 0;
            return stream;
        }
    }
}

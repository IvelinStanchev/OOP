using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public interface IDocument
{
	string Name { get; }
	string Content { get; }
	void LoadProperty(string key, string value);
	void SaveAllProperties(IList<KeyValuePair<string, object>> output);
	string ToString();
}

public abstract class Document : IDocument
{
    public string Name { get; private set; }
    public string Content { get; set; }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }

        if (key == "content")
        {
            this.Content = value;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();

        output.Append(this.GetType().Name);
        output.Append("[");
        IList<KeyValuePair<string, object>> attributes = new List<KeyValuePair<string, object>>();
        var sortedAttributes = attributes.OrderBy(x => x.Key);
        SaveAllProperties(attributes);
        foreach (var attribute in sortedAttributes)
        {
            if (attribute.Value != null)
            {
                output.Append(attribute.Key);
                output.Append("=");
                output.Append(attribute.Value);
                output.Append(";");
            }
        }
        output.Length--;
        output.Append("]");

        return output.ToString();
    }
}

public class TextDocument : Document, IEditable
{
    public string Charset { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "charset")
        {
            this.Charset = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("charset", this.Charset));
        base.SaveAllProperties(output);
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
}

public abstract class BinaryDocument : Document
{
    public long? Size { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "size")
        {
            this.Size = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("size", this.Size));
        base.SaveAllProperties(output);
    }
}

public class PDFDocument : EncryptableDocument
{
    public long? Pages { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "page")
        {
            this.Pages = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        base.SaveAllProperties(output);
    }
}

public class WordDocument : OfficeDocument, IEditable
{
    public long? Chars { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
        {
            this.Chars = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("chars", this.Chars));
        base.SaveAllProperties(output);
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
}

public class ExcelDocument : OfficeDocument
{
    public long? Rows { get; private set; }
    public long? Cols { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "rows")
        {
            this.Rows = long.Parse(value);
        }
        else if (key == "cols")
        {
            this.Cols = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("rows", this.Rows));
        output.Add(new KeyValuePair<string, object>("cols", this.Cols));
        base.SaveAllProperties(output);
    }
}

public class AudioDocument : MultimediaDocument
{
    public long? SampleRate { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "samplerate")
        {
            this.SampleRate = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        base.SaveAllProperties(output);
    }
}

public class VideoDocument : MultimediaDocument
{
    public long? FrameRate { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "framerate")
        {
            this.FrameRate = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        base.SaveAllProperties(output);
    }
}

public abstract class OfficeDocument : EncryptableDocument
{
    public string Version { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "version")
        {
            this.Version = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("version", this.Version));
        base.SaveAllProperties(output);
    }
}

public abstract class MultimediaDocument : BinaryDocument
{
    public long? Length { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "length")
        {
            this.Length = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("length", this.Length));
        base.SaveAllProperties(output);
    }
}

public abstract class EncryptableDocument : BinaryDocument, IEncryptable
{
    public bool IsEncrypted { get; private set;  }

    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }

    public override string ToString()
    {
        if (this.IsEncrypted)
        {
            return this.GetType().Name + "[encrypted]";
        }
        else
        {
            return base.ToString();
        }
    }
}

public interface IEditable
{
	void ChangeContent(string newContent);
}

public interface IEncryptable
{
	bool IsEncrypted { get; }
	void Encrypt();
	void Decrypt();
}

public class DocumentSystem
{
    private static IList<IDocument> documents = new List<IDocument>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddDocument(IDocument doc, string[] attributes)
    {
        foreach (var attribute in attributes)
        {
            string[] tokens = attribute.Split('=');
            string propertyName = tokens[0];
            string propertyValue = tokens[1];
            doc.LoadProperty(propertyName, propertyValue);
        }
        if (doc.Name != null)
        {
            documents.Add(doc);
            Console.WriteLine("Document added: " + doc.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }
  
    private static void AddTextDocument(string[] attributes)
    {
        AddDocument(new TextDocument(), attributes);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        AddDocument(new PDFDocument(), attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        AddDocument(new WordDocument(), attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AddDocument(new ExcelDocument(), attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AddDocument(new AudioDocument(), attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AddDocument(new VideoDocument(), attributes);
    }

    private static void ListDocuments()
    {
        if (documents.Count == 0)
        {
            Console.WriteLine("No documents found");
        }
        else
        {
            foreach (var doc in documents)
            {
                Console.WriteLine(doc);
            }
        }
    }

    private static void EncryptDocument(string name)
    {
        bool found = false;
        foreach (var document in documents)
        {
            if (document.Name == name)
            {
                found = true;
                if (document is IEncryptable)
                {
                    ((IEncryptable)document).Encrypt();
                    Console.WriteLine("Document encrypted: " + document.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: " + document.Name);
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool found = false;
        foreach (var document in documents)
        {
            if (document.Name == name)
            {
                found = true;
                if (document is IEncryptable)
                {
                    ((IEncryptable)document).Decrypt();
                    Console.WriteLine("Document decrypted: " + document.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: " + document.Name);
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool foundEncryptable = false;
        foreach (var document in documents)
        {
            
            if (document is IEncryptable)
            {
                foundEncryptable = true;
                ((IEncryptable)document).Decrypt();
            }
        }
        if (!foundEncryptable)
        {
            Console.WriteLine("No encryptable documents found");
        }
        else
        {
            Console.WriteLine("All documents encrypted");
        }
    }

    private static void ChangeContent(string name, string newContent)
    {
        bool found = false;
        foreach (var document in documents)
        {
            if (document.Name == name)
            {
                found = true;
                if (document is IEditable)
                {
                    ((IEditable)document).ChangeContent(newContent);
                    Console.WriteLine("Document content changed: " + document.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: " + document.Name);
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }
}

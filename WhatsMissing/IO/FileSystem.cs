namespace WhatsMissing.IO
{
    using System.IO;

    public class FileSystem : IFileSystem
    {
        public Stream OpenFile(string filePath, FileMode mode)
        {
            return File.Open(filePath, mode);
        }

        public Stream OpenFile(string filePath, FileMode mode, FileAccess access)
        {
            return File.Open(filePath, mode, access);
        }

        public Stream OpenFile(string filePath, FileMode mode, FileAccess access, FileShare share)
        {
            return File.Open(filePath, mode, access, share);
        }
    }
}

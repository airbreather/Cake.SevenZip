using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.SevenZip
{
    /// <summary>
    /// Contains settings used by <see cref="SevenZipExtractRunner"/>.
    /// </summary>
    public sealed class SevenZipExtractSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets the path to the archive to extract.
        /// </summary>
        /// <value>
        /// The path to the archive to extract.
        /// </value>
        public FilePath ArchivePath { get; set; }

        /// <summary>
        /// Gets or sets the path to the directory to extract to.
        /// </summary>
        /// <value>
        /// The path to the directory to extract to.
        /// </value>
        public DirectoryPath OutputPath { get; set; }
    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.SevenZip
{
    /// <summary>
    /// Runner for SevenZipExtract.
    /// </summary>
    public sealed class SevenZipExtractRunner : Tool<SevenZipExtractSettings>
    {
        private static readonly ReadOnlyCollection<string> ToolExecutableNames = new ReadOnlyCollection<string>(new string[] { "7za.exe" });

        private readonly IFileSystem fileSystem;

        private readonly ICakeEnvironment environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="SevenZipExtractRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">
        /// The file system.
        /// </param>
        /// <param name="environment">
        /// The environment.
        /// </param>
        /// <param name="processRunner">
        /// The process runner.
        /// </param>
        /// <param name="toolLocator">
        /// The tool locator.
        /// </param>
        public SevenZipExtractRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator toolLocator)
            : base(fileSystem, environment, processRunner, toolLocator)
        {
            this.fileSystem = fileSystem.ValidateNotNull(nameof(fileSystem));
            this.environment = environment.ValidateNotNull(nameof(environment));
        }

        /// <summary>
        /// Extracts a 7-zip archive.
        /// </summary>
        /// <param name="settings">
        /// The settings.
        /// </param>
        public void Run(SevenZipExtractSettings settings)
        {
            settings.ValidateNotNull(nameof(settings));
            this.Run(settings, this.BuildProcessArguments(settings));
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>
        /// The tool executable name.
        /// </returns>
        protected override IEnumerable<string> GetToolExecutableNames() => ToolExecutableNames;

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>
        /// The name of the tool.
        /// </returns>
        protected override string GetToolName() => "SevenZipExtract";

        private ProcessArgumentBuilder BuildProcessArguments(SevenZipExtractSettings settings)
        {
            FilePath absoluteArchivePath = settings.ArchivePath?.MakeAbsolute(this.environment);
            DirectoryPath absoluteOutputPath = settings.OutputPath?.MakeAbsolute(this.environment);

            if (absoluteArchivePath == null)
            {
                throw new CakeException("Archive path is unset.");
            }

            if (absoluteOutputPath == null)
            {
                throw new CakeException("Output path is unset.");
            }

            if (!this.fileSystem.Exist(absoluteArchivePath))
            {
                throw new CakeException("Archive path points to a file that doesn't exist.");
            }

            if (!this.fileSystem.Exist(absoluteOutputPath))
            {
                ////throw new CakeException("Output path points to a folder that doesn't exist.");
                this.fileSystem.GetDirectory(absoluteOutputPath).Create();
            }

            return new ProcessArgumentBuilder()
                .Append("x")
                .AppendQuoted(absoluteArchivePath.FullPath)
                .AppendQuoted("-o" + absoluteOutputPath);
        }
    }
}

using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.SevenZip
{
    /// <summary>
    /// <para>Contains aliases related to <see href="http://www.7-zip.org/">7-zip</see>.</para>
    /// <para>
    /// In order to use the commands for this addin, you will need to include the following in your
    /// build.cake file to download and reference from NuGet.org:
    /// <code>
    /// #tool sevenzip
    /// </code>
    /// In addition, you will need to include the following:
    /// <code>
    /// #addin Cake.SevenZip
    /// </code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("SevenZip")]
    public static class SevenZipExtractAliases
    {
        /// <summary>
        /// Extracts an archive using 7-zip.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="archivePath">
        /// The path to the archive to extract.
        /// </param>
        /// <param name="outputPath">
        /// The path to the directory where the archive will be extracted.
        /// </param>
        /// <example>
        /// <code>
        /// SevenZipExtract(@"C:\Path\To\Archive.7z", @"C:\Some\Directory");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void SevenZipExtract(this ICakeContext context, string archivePath, string outputPath) => SevenZipExtract(context, new SevenZipExtractSettings { ArchivePath = archivePath, OutputPath = outputPath });

        /// <summary>
        /// Extracts an archive using 7-zip.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <example>
        /// <code>
        /// SevenZipExtract(new CoverallsIoSettings
        /// {
        ///     ArchivePath = @"C:\Path\To\Archive.7z",
        ///     OutputPath = @"C:\Some\Directory"
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void SevenZipExtract(this ICakeContext context, SevenZipExtractSettings settings)
        {
            context.ValidateNotNull(nameof(context));
            new SevenZipExtractRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools).Run(settings);
        }
    }
}

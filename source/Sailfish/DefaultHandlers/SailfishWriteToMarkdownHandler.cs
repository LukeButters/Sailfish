﻿using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sailfish.Contracts.Private;
using Sailfish.Presentation;
using Sailfish.Presentation.Markdown;

namespace Sailfish.DefaultHandlers;

internal class SailfishWriteToMarkdownHandler : INotificationHandler<WriteToMarkDownNotification>
{
    private readonly IMarkdownWriter markdownWriter;

    public SailfishWriteToMarkdownHandler(IMarkdownWriter markdownWriter)
    {
        this.markdownWriter = markdownWriter;
    }

    public async Task Handle(WriteToMarkDownNotification notification, CancellationToken cancellationToken)
    {
        var fileName = DefaultFileSettings.AppendTagsToFilename(DefaultFileSettings.DefaultPerformanceResultsFileNameStem(notification.TimeStamp) + ".md", notification.Tags);
        var filePath = Path.Combine(notification.OutputDirectory, fileName);
        await markdownWriter.Write(notification.Content, filePath, notification.Settings, cancellationToken).ConfigureAwait(false);
    }
}
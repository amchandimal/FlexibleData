namespace FlexibleDataApplication.Services.Util
{
    public class BackgroundLongRunningService : BackgroundService
    {
        private readonly BackgroundWorkerQueue queue;

        public BackgroundLongRunningService(BackgroundWorkerQueue queue)
        {
            this.queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var workItem = await queue.DequeueAsync(stoppingToken);

                await workItem(stoppingToken);
            }
        }
    }
}

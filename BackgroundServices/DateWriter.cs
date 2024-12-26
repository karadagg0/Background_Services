
namespace BackgroundServices_IHostedService.BackgroundServices
{
    public class DateWriter : IHostedService,IDisposable
    {
        private Timer? _timer;
        private SystemHealthChecker? _healthChecker;
        public  Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(DateWriter)} service started");
            //_timer = new Timer(WriteDate, null, TimeSpan.Zero, TimeSpan.FromSeconds(1)); 
            _healthChecker = new SystemHealthChecker();
            _timer = new Timer(WriteSystemHealth, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }
        private void WriteSystemHealth(object? state)
        {
            _healthChecker?.CheckSystemHealth();
        }
        private void WriteDate(object state)
        {
            Console.WriteLine($"DateTime :  {DateTime.Now.ToLongTimeString()}");
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            Console.WriteLine($"{nameof(DateWriter)} service stopped");
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer = null;
            _healthChecker = null;
        }
    }


    public class DateWriter2 : BackgroundService
    {
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}

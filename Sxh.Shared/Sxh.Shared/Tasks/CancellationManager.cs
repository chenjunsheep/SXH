using System.Threading;

namespace Sxh.Shared.Tasks
{
    public class CancellationManager
    {
        public CancellationTokenSource Souce { get; set; }
        public CancellationToken Token { get; set; }
        public bool IsCancelled
        {
            get { return Souce == null; }
        }

        public CancellationManager()
        {
            Activate();
        }

        public void Activate()
        {
            Souce = new CancellationTokenSource();
            Token = Souce.Token;
        }

        public void Cancel()
        {
            if (Souce != null && Souce.Token.CanBeCanceled)
            {
                Souce.Cancel();
            }
        }

        public void Dispose()
        {
            if (Souce != null)
            {
                Souce.Dispose();
                Souce = null;
            }
        }
    }
}

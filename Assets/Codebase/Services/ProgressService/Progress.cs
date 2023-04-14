namespace Codebase.Services.ProgressService
{
    public class Progress
    {
        public int HighScore => _highScore;
        private int _highScore;

        public Progress(int highScore)
        {
            _highScore = highScore;
        }
    }
}
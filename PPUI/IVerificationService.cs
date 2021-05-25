namespace PPUI
{
    public interface IVerificationService
    {
        /// <summary>
        /// Takes in a prompt, and keeps asking that prompt till the end user returns a valid string
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        string VerifyString(string prompt);
        int VerifyInt(string prompt);
    }
}
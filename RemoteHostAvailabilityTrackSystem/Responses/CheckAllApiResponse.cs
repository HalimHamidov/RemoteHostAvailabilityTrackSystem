namespace RemoteHostAvailabilityTrackSystem.Responses
{
    /// <summary>
    /// Ответ получения всех проверок.
    /// </summary>
    public class CheckAllApiResponse
    {
        /// <summary>
        /// ответ получения всех служб.
        /// </summary>
        public string Api { get; set; }
        /// <summary>
        /// флаг правильности
        /// </summary>
        public bool IsValid { get; set; }
    }
}
